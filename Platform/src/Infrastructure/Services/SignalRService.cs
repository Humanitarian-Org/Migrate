using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Platform.Domain.Contracts.Events;
using Platform.Domain.Services;

namespace Platform.Infrastructure.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SignalRService> _logger;
        private readonly string _baseUrl;

        public SignalRService(HttpClient httpClient, IConfiguration configuration, ILogger<SignalRService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _baseUrl = configuration["SignalRFunctionBaseUrl"] ?? "http://localhost:7071/api";
        }

        public async Task SendUploadStartedAsync(BulkBeneficiaryUploadStarted uploadStarted)
        {
            try
            {
                var message = new
                {
                    correlationId = uploadStarted.CorrelationId,
                    uploadId = uploadStarted.UploadId,
                    totalRecordsCount = uploadStarted.TotalRecordsCount,
                    startedAt = uploadStarted.StartedAt,
                    userId = uploadStarted.UserId,
                    fileName = uploadStarted.FileName,
                    docId = uploadStarted.DocId
                };

                await SendSignalRMessageAsync("SendUploadStarted", message);
                _logger.LogInformation($"Sent upload started SignalR message for correlation ID: {uploadStarted.CorrelationId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send upload started SignalR message for correlation ID: {uploadStarted.CorrelationId}");
            }
        }

        public async Task SendUploadProgressAsync(string correlationId, string uploadId, int processedRecords, int totalRecords, int successfulRecords, int failedRecords, string status)
        {
            try
            {
                var message = new
                {
                    correlationId,
                    uploadId,
                    processedRecords,
                    totalRecords,
                    successfulRecords,
                    failedRecords,
                    percentageComplete = totalRecords > 0 ? (double)processedRecords / totalRecords * 100 : 0,
                    currentStatus = status
                };

                await SendSignalRMessageAsync("SendUploadProgress", message);
                _logger.LogInformation($"Sent upload progress SignalR message for correlation ID: {correlationId} ({processedRecords}/{totalRecords}) - Success: {successfulRecords}, Failed: {failedRecords}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send upload progress SignalR message for correlation ID: {correlationId}");
            }
        }

        public async Task SendUploadCompletedAsync(string correlationId, string uploadId, int totalRecords, int successfulRecords, int failedRecords, string status, string[] errors = null)
        {
            try
            {
                var message = new
                {
                    correlationId,
                    uploadId,
                    totalRecords,
                    successfulRecords,
                    failedRecords,
                    completedAt = DateTimeOffset.UtcNow,
                    status,
                    errors = errors ?? Array.Empty<string>()
                };

                await SendSignalRMessageAsync("SendUploadCompleted", message);
                _logger.LogInformation($"Sent upload completed SignalR message for correlation ID: {correlationId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send upload completed SignalR message for correlation ID: {correlationId}");
            }
        }

        public async Task SendUploadTimedOutAsync(string correlationId, string uploadId, DateTimeOffset timedOutAt)
        {
            try
            {
                var message = new
                {
                    correlationId,
                    uploadId,
                    timedOutAt,
                    status = "Timed Out"
                };

                await SendSignalRMessageAsync("SendUploadTimedOut", message);
                _logger.LogInformation($"Sent upload timeout SignalR message for correlation ID: {correlationId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send upload timeout SignalR message for correlation ID: {correlationId}");
            }
        }

        private async Task SendSignalRMessageAsync(string endpoint, object message)
        {
            var json = JsonSerializer.Serialize(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{_baseUrl}/{endpoint}";

            _logger.LogDebug($"Sending SignalR message to {url}: {json}");

            var response = await _httpClient.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"SignalR message failed with status {response.StatusCode}: {responseContent}");
            }
        }
    }
}