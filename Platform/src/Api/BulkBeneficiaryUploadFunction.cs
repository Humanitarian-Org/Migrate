using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Platform.Domain.Managers;
using Platform.Domain.Models;
using Platform.Domain.Contracts.Events;
using NServiceBus;

namespace Api
{
    public class BulkBeneficiaryUploadFunction
    {
        private readonly ILogger _logger;
        private readonly IBulkBeneficiaryUploadManager _bulkBeneficiaryUploadManager;
        private readonly IFunctionEndpoint _functionEndpoint;

        public BulkBeneficiaryUploadFunction(ILoggerFactory loggerFactory, IBulkBeneficiaryUploadManager bulkBeneficiaryUploadManager, IFunctionEndpoint functionEndpoint)
        {
            _logger = loggerFactory.CreateLogger<BulkBeneficiaryUploadFunction>();
            _bulkBeneficiaryUploadManager = bulkBeneficiaryUploadManager;
            _functionEndpoint = functionEndpoint;
        }

        [Function("BulkBeneficiaryUpload")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "beneficiary/bulk-upload")] HttpRequestData req, 
            FunctionContext executionContext)
        {
            try
            {
                _logger.LogInformation("Processing bulk beneficiary upload request");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                
                if (string.IsNullOrWhiteSpace(requestBody))
                {
                    var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequest.WriteStringAsync("Request body is empty");
                    return badRequest;
                }

                // Deserialize the request
                var uploadRequest = JsonSerializer.Deserialize<BulkBeneficiaryUploadRequest>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (uploadRequest?.Records == null || uploadRequest.Records.Length == 0)
                {
                    var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequest.WriteStringAsync("No beneficiary records provided");
                    return badRequest;
                }

                _logger.LogInformation($"Processing bulk upload with {uploadRequest.Records.Length} records");

                // Process the bulk upload
                var bulkUpload = await _bulkBeneficiaryUploadManager.ProcessBulkBeneficiaryUpload(uploadRequest);

                // Publish the event
                await _functionEndpoint.Publish(new BulkBeneficiaryUploadStarted
                {
                    CorrelationId = bulkUpload.CorrelationId,
                    UploadId = bulkUpload.UploadId,
                    TotalRecordsCount = bulkUpload.TotalRecordsCount,
                    StartedAt = bulkUpload.StartedAt,
                    UserId = bulkUpload.UserId,
                    FileName = bulkUpload.FileName,
                    DocId = bulkUpload.id
                }, executionContext);

                _logger.LogInformation($"Published BulkBeneficiaryUploadStarted event for upload {bulkUpload.UploadId}");

                // Return success response
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(new
                {
                    uploadId = bulkUpload.UploadId,
                    totalRecords = bulkUpload.TotalRecordsCount,
                    startedAt = bulkUpload.StartedAt,
                    status = "Processing"
                });

                return response;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Invalid JSON in request body");
                var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequest.WriteStringAsync("Invalid JSON format");
                return badRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing bulk beneficiary upload");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Internal server error occurred while processing the upload");
                return errorResponse;
            }
        }

        [Function("GetBulkBeneficiaryUploadStatus")]
        public async Task<HttpResponseData> GetStatus(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "beneficiary/bulk-upload/status/{correlationId}")] HttpRequestData req,
            string correlationId,
            FunctionContext executionContext)
        {
            try
            {
                _logger.LogInformation($"Getting bulk beneficiary upload status for correlation ID: {correlationId}");

                if (string.IsNullOrWhiteSpace(correlationId))
                {
                    var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequest.WriteStringAsync("Correlation ID is required");
                    return badRequest;
                }

                // Get processing status
                var processingStatus = await _bulkBeneficiaryUploadManager.GetBulkBeneficiaryProcessingStatus(correlationId);

                if (processingStatus == null)
                {
                    var notFound = req.CreateResponse(HttpStatusCode.NotFound);
                    await notFound.WriteStringAsync($"No bulk upload found for correlation ID: {correlationId}");
                    return notFound;
                }

                _logger.LogInformation($"Retrieved processing status for {correlationId}: {processingStatus.ProcessedRecords}/{processingStatus.TotalRecords} processed");

                // Return the processing status
                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");
                
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                
                var jsonString = JsonSerializer.Serialize(processingStatus, jsonOptions);
                await response.WriteStringAsync(jsonString);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting bulk beneficiary upload status for correlation ID: {correlationId}");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Internal server error occurred while retrieving the upload status");
                return errorResponse;
            }
        }
    }
}