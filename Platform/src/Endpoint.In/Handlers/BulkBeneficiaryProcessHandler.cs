using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Platform.Domain.Contracts.Events;
using Platform.Domain.Contracts.Commands;
using Platform.Domain.Managers;

namespace Endpoint.In.Handlers
{
    public class BulkBeneficiaryProcessHandler : IHandleMessages<BulkBeneficiarySagaStarted>
    {
        private readonly ILogger<BulkBeneficiaryProcessHandler> _logger;
        private readonly IBulkBeneficiaryUploadManager _bulkBeneficiaryUploadManager;

        public BulkBeneficiaryProcessHandler(
            ILogger<BulkBeneficiaryProcessHandler> logger,
            IBulkBeneficiaryUploadManager bulkBeneficiaryUploadManager)
        {
            _logger = logger;
            _bulkBeneficiaryUploadManager = bulkBeneficiaryUploadManager;
        }

        public async Task Handle(BulkBeneficiarySagaStarted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[BulkBeneficiaryProcessHandler] Starting to process bulk beneficiary upload | CorrelationId: {message.CorrelationId} | DocId: {message.DocId}");

            try
            {
                // Get the document from CosmosDB using the BulkBeneficiaryUploadManager
                var bulkUploadDoc = await _bulkBeneficiaryUploadManager.GetBulkBeneficiaryUpload(message.DocId, message.CorrelationId);
                
                if (bulkUploadDoc == null)
                {
                    _logger.LogError($"[BulkBeneficiaryProcessHandler] Could not find bulk upload document | DocId: {message.DocId} | CorrelationId: {message.CorrelationId}");
                    return;
                }

                _logger.LogInformation($"[BulkBeneficiaryProcessHandler] Retrieved bulk upload document | Records count: {bulkUploadDoc.Records?.Length ?? 0}");

                var commandsSent = 0;
                var totalRecords = bulkUploadDoc.Records?.Length ?? 0;

                // Parse each beneficiary record and send individual commands
                if (bulkUploadDoc.Records != null)
                {
                    foreach (var record in bulkUploadDoc.Records)
                    {
                        try
                        {
                            var command = new CreateBeneficiaryCommand
                            {
                                CorrelationId = message.CorrelationId,
                                UploadId = message.UploadId,
                                RecordId = record.RecordId, // Pass the GUID to track individual processing
                                FirstName = record.FirstName,
                                LastName = record.LastName,
                                DateOfBirth = record.DateOfBirth,
                                Nationality = record.Nationality,
                                DocumentType = record.DocumentType,
                                DocumentNumber = record.DocumentNumber,
                                Email = record.Email,
                                Phone = record.Phone,
                                Address = record.Address,
                                City = record.City,
                                Country = record.Country,
                                EmergencyContact = record.EmergencyContact,
                                EmergencyPhone = record.EmergencyPhone,
                                MedicalConditions = record.MedicalConditions,
                                SpecialNeeds = record.SpecialNeeds,
                                CaseStatus = record.CaseStatus,
                                CaseWorker = record.CaseWorker,
                                Notes = record.Notes
                            };

                            // Send command to the Beneficiary domain endpoint
                            var sendOptions = new SendOptions();
                            sendOptions.SetDestination("ASBBeneficiaryMessageWorker");
                            await context.Send(command, sendOptions);
                            
                            commandsSent++;
                            
                            _logger.LogDebug($"[BulkBeneficiaryProcessHandler] Sent CreateBeneficiaryCommand for {command.FirstName} {command.LastName} | CorrelationId: {message.CorrelationId}");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"[BulkBeneficiaryProcessHandler] Failed to process beneficiary record | CorrelationId: {message.CorrelationId}");
                        }
                    }
                }

                // Publish completion event
                var completionEvent = new BulkBeneficiaryParsedAndSent
                {
                    CorrelationId = message.CorrelationId,
                    UploadId = message.UploadId,
                    TotalRecordsParsed = totalRecords,
                    CommandsSent = commandsSent,
                    CompletedAt = DateTimeOffset.UtcNow,
                    Status = commandsSent == totalRecords ? "All commands sent successfully" : $"Sent {commandsSent} of {totalRecords} commands"
                };

                _logger.LogInformation($"[BulkBeneficiaryProcessHandler] Publishing BulkBeneficiaryParsedAndSent event | CorrelationId: {completionEvent.CorrelationId} | CommandsSent: {commandsSent}");
                await context.Publish(completionEvent);

                _logger.LogInformation($"[BulkBeneficiaryProcessHandler] Completed processing bulk beneficiary upload | CorrelationId: {message.CorrelationId} | CommandsSent: {commandsSent}/{totalRecords}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[BulkBeneficiaryProcessHandler] Failed to process bulk beneficiary upload | CorrelationId: {message.CorrelationId}");
                
                // Publish completion event with error status
                var errorEvent = new BulkBeneficiaryParsedAndSent
                {
                    CorrelationId = message.CorrelationId,
                    UploadId = message.UploadId,
                    TotalRecordsParsed = 0,
                    CommandsSent = 0,
                    CompletedAt = DateTimeOffset.UtcNow,
                    Status = $"Failed to process: {ex.Message}"
                };

                _logger.LogInformation($"[BulkBeneficiaryProcessHandler] Publishing error BulkBeneficiaryParsedAndSent event | CorrelationId: {errorEvent.CorrelationId}");
                await context.Publish(errorEvent);
            }
        }


    }
}