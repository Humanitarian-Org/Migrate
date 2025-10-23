namespace Platform.Domain.Managers
{
#nullable enable
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Platform.Domain.Managers.Services.PlatformIntegrationDb;
    using Platform.Domain.Managers.Services.CosmosService;
    using System.Collections.Generic;

    public class BulkBeneficiaryUploadManager : IBulkBeneficiaryUploadManager
    {
        private readonly IPlatformRepository _repository;
        private readonly CosmosRepository _cosmosRepository;
        private readonly ILogger<BulkBeneficiaryUploadManager> _logger;

        public BulkBeneficiaryUploadManager(IPlatformRepository repository, CosmosRepository cosmosRepository, ILogger<BulkBeneficiaryUploadManager> logger)
        {
            _repository = repository;
            _cosmosRepository = cosmosRepository;
            _logger = logger;
        }

        public async Task<PlatformMessage> Intake(string jsonPayload)
        {
            // Save as a PlatformMessage with SystemConfiguration property populated
            var jsonDoc = JsonDocument.Parse(jsonPayload);
            string? systemId = null;
            try
            {
                var root = jsonDoc.RootElement.GetProperty("ConfigureSystemRequest");
                var identifiers = root.GetProperty("SystemIdentifierList").GetProperty("SystemIdentifier");
                foreach (var identifier in identifiers.EnumerateArray())
                {
                    if (identifier.GetProperty("Type").GetString() == "IOMGID")
                    {
                        systemId = identifier.GetProperty("Value").GetString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                // handle or log error if needed
                systemId = null;
            }

            var payloadElement = JsonSerializer.Deserialize<JsonElement>(jsonPayload);

            var platformMessage = new PlatformMessage
            {
                id = systemId,
                Metadata = new PlatformMessageMetadata
                {
                    MessageType = "PLT001",
                    ReceivedUtc = DateTime.UtcNow,
                    SourceSystem = "API",
                    SystemId = systemId ?? "unknown",
                    CorrelationId = Guid.NewGuid().ToString()
                },
                SystemConfiguration = new SystemConfigurationMessage
                {
                    Metadata = new PlatformMessageMetadata
                    {
                        MessageType = "PLT001",
                        ReceivedUtc = DateTime.UtcNow,
                        SourceSystem = "API",
                        SystemId = systemId ?? "unknown",
                        CorrelationId = Guid.NewGuid().ToString()
                    },
                    Message = payloadElement
                }
            };

            await _repository.SaveMessageAsync(platformMessage);

            return platformMessage;
        }

        public async Task<BulkBeneficiaryUpload> ProcessBulkBeneficiaryUpload(Models.BulkBeneficiaryUploadRequest request)
        {
            var bulkUpload = new BulkBeneficiaryUpload
            {
                UploadId = request.UploadId ?? Guid.NewGuid().ToString(),
                FileName = request.FileName,
                UserId = request.UserId,
                TotalRecordsCount = request.Records?.Length ?? 0,
                StartedAt = DateTimeOffset.UtcNow,
                Records = request.Records,
                CorrelationId = request.CorrelationId
            };

            try
            {
                // Persist to Cosmos
                await _cosmosRepository.UpsertAsync(bulkUpload);
                _logger.LogInformation($"Successfully saved bulk beneficiary upload {bulkUpload.UploadId} with {bulkUpload.TotalRecordsCount} records");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to upsert BulkBeneficiaryUpload {bulkUpload.UploadId} to Cosmos");
                throw;
            }

            return bulkUpload;
        }

        public async Task<BulkBeneficiaryUpload?> GetBulkBeneficiaryUpload(string docId, string correlationId)
        {
            try
            {
                var response = await _cosmosRepository.ReadAsync<BulkBeneficiaryUpload>(docId, correlationId);
                return response.Resource;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to retrieve BulkBeneficiaryUpload {docId} with CorrelationId {correlationId} from Cosmos");
                return null;
            }
        }

        public async Task UpdateBeneficiaryStatus(string correlationId, string recordId, string status, string? beneficiaryId = null, string? errorMessage = null)
        {
            try
            {
                _logger.LogInformation($"[BulkBeneficiaryUploadManager] Updating beneficiary status | CorrelationId: {correlationId} | RecordId: {recordId} | Status: {status}");
                
                // Find the BulkBeneficiaryUpload document to update
                // Since we don't have the document ID directly, we need to query for it
                var bulkUploadDocs = _cosmosRepository.QueryPartitionAsync<BulkBeneficiaryUpload>(correlationId, true);
                
                await foreach (var doc in bulkUploadDocs)
                {
                    try
                    {
                        // Use atomic patch operation to update only the specific record's Result object
                        await _cosmosRepository.PatchBeneficiaryRecordStatusAsync<BulkBeneficiaryUpload>(
                            doc.id, 
                            correlationId, 
                            recordId, 
                            status, 
                            beneficiaryId, 
                            errorMessage);
                        
                        _logger.LogInformation($"[BulkBeneficiaryUploadManager] Successfully updated beneficiary status | DocId: {doc.id} | RecordId: {recordId} | Status: {status}");
                        return; // Exit after successful update
                    }
                    catch (InvalidOperationException ex) when (ex.Message.Contains("Could not find beneficiary record"))
                    {
                        // Continue to next document if record not found in this one
                        _logger.LogDebug($"[BulkBeneficiaryUploadManager] RecordId {recordId} not found in document {doc.id}, trying next document");
                        continue;
                    }
                }
                
                _logger.LogWarning($"[BulkBeneficiaryUploadManager] Could not find document with RecordId: {recordId} in CorrelationId: {correlationId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[BulkBeneficiaryUploadManager] Failed to update beneficiary status | CorrelationId: {correlationId} | RecordId: {recordId} | Status: {status}");
                throw;
            }
        }

        public async Task<Models.BulkBeneficiaryProcessingStatus?> GetBulkBeneficiaryProcessingStatus(string correlationId)
        {
            try
            {
                _logger.LogInformation($"Retrieving bulk beneficiary processing status | CorrelationId: {correlationId}");
                
                // Query for the BulkBeneficiaryUpload document by correlation ID
                var bulkUploadDocs = _cosmosRepository.QueryPartitionAsync<Services.CosmosService.BulkBeneficiaryUpload>(correlationId, true);
                
                await foreach (var bulkUpload in bulkUploadDocs)
                {
                    // Calculate processing status from individual record results
                    int totalRecords = bulkUpload.Records?.Length ?? 0;
                    int processedRecords = 0;
                    int successfulRecords = 0;
                    int failedRecords = 0;
                    
                    var results = new List<Models.BeneficiaryProcessingResult>();
                    
                    if (bulkUpload.Records != null)
                    {
                        foreach (var record in bulkUpload.Records)
                        {
                            if (record.Result != null)
                            {
                                switch (record.Result.Status?.ToLower())
                                {
                                    case "success":
                                        processedRecords++;
                                        successfulRecords++;
                                        break;
                                    case "failed":
                                        processedRecords++;
                                        failedRecords++;
                                        break;
                                    // "pending" or null means not yet processed
                                }
                                
                                results.Add(new Models.BeneficiaryProcessingResult
                                {
                                    BeneficiaryId = record.Result.BeneficiaryId ?? record.RecordId,
                                    FirstName = record.FirstName,
                                    LastName = record.LastName,
                                    Status = record.Result.Status ?? "Pending",
                                    Error = record.Result.ErrorMessage,
                                    ProcessedAt = record.Result.ProcessedAt ?? DateTimeOffset.MinValue
                                });
                            }
                            else
                            {
                                // No result means still pending
                                results.Add(new Models.BeneficiaryProcessingResult
                                {
                                    BeneficiaryId = record.RecordId,
                                    FirstName = record.FirstName,
                                    LastName = record.LastName,
                                    Status = "Pending",
                                    Error = null,
                                    ProcessedAt = DateTimeOffset.MinValue
                                });
                            }
                        }
                    }
                    
                    _logger.LogInformation($"Processing status calculated | CorrelationId: {correlationId} | Total: {totalRecords} | Processed: {processedRecords} | Success: {successfulRecords} | Failed: {failedRecords}");
                    
                    return new Models.BulkBeneficiaryProcessingStatus
                    {
                        CorrelationId = correlationId,
                        UploadId = bulkUpload.UploadId,
                        TotalRecords = totalRecords,
                        ProcessedRecords = processedRecords,
                        SuccessfulRecords = successfulRecords,
                        FailedRecords = failedRecords,
                        Results = results,
                        LastUpdated = DateTimeOffset.UtcNow
                    };
                }
                
                _logger.LogWarning($"No BulkBeneficiaryUpload document found for CorrelationId: {correlationId}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to retrieve bulk beneficiary processing status | CorrelationId: {correlationId}");
                return null;
            }
        }
    }
}