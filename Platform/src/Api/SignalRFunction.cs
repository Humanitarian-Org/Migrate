using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using Microsoft.Azure.Functions.Worker.Extensions.SignalRService;
using System.Net;

namespace Api
{
    public class SignalRFunction
    {
        private readonly ILogger _logger;

        public SignalRFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SignalRFunction>();
        }

        [Function("negotiate")]
        public async Task<HttpResponseData> GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", "options")] HttpRequestData req,
            [SignalRConnectionInfoInput(HubName = "bulkUploadHub")] SignalRConnectionInfo connectionInfo)
        {
            _logger.LogInformation("Client requesting SignalR connection info");
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            
            // Add CORS headers
            response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            response.Headers.Add("Access-Control-Allow-Credentials", "true");
            
            // Handle preflight OPTIONS request
            if (req.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
            {
                return response;
            }
            
            // Log the connection info for debugging
            if (connectionInfo == null)
            {
                _logger.LogError("SignalR connection info is null");
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                response.Headers.Add("Access-Control-Allow-Credentials", "true");
                await response.WriteStringAsync("SignalR connection info is null");
                return response;
            }
            
            _logger.LogInformation($"SignalR connection info: URL={connectionInfo.Url}, AccessToken length={connectionInfo.AccessToken?.Length ?? 0}");
            
            await response.WriteAsJsonAsync(connectionInfo);
            return response;
        }

        [Function("SendUploadStarted")]
        [SignalROutput(HubName = "bulkUploadHub")]
        public async Task<SignalRMessageAction> SendUploadStarted(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            try
            {
                var requestBody = await req.ReadAsStringAsync();
                var uploadStarted = JsonSerializer.Deserialize<UploadStartedMessage>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (uploadStarted?.CorrelationId == null)
                {
                    _logger.LogWarning("Received upload started message without correlation ID");
                    return null;
                }

                _logger.LogInformation($"Broadcasting upload started message for correlation ID: {uploadStarted.CorrelationId}");

                // Send to specific user group based on correlation ID
                return new SignalRMessageAction("uploadStarted")
                {
                    Arguments = new object[] { uploadStarted },
                    GroupName = $"upload_{uploadStarted.CorrelationId}"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting upload started message");
                return null;
            }
        }

        [Function("SendUploadProgress")]
        [SignalROutput(HubName = "bulkUploadHub")]
        public async Task<SignalRMessageAction> SendUploadProgress(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            try
            {
                var requestBody = await req.ReadAsStringAsync();
                var uploadProgress = JsonSerializer.Deserialize<UploadProgressMessage>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (uploadProgress?.CorrelationId == null)
                {
                    _logger.LogWarning("Received upload progress message without correlation ID");
                    return null;
                }

                _logger.LogInformation($"Broadcasting upload progress message for correlation ID: {uploadProgress.CorrelationId}");

                return new SignalRMessageAction("uploadProgress")
                {
                    Arguments = new object[] { uploadProgress },
                    GroupName = $"upload_{uploadProgress.CorrelationId}"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting upload progress message");
                return null;
            }
        }

        [Function("SendUploadCompleted")]
        [SignalROutput(HubName = "bulkUploadHub")]
        public async Task<SignalRMessageAction> SendUploadCompleted(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            try
            {
                var requestBody = await req.ReadAsStringAsync();
                var uploadCompleted = JsonSerializer.Deserialize<UploadCompletedMessage>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (uploadCompleted?.CorrelationId == null)
                {
                    _logger.LogWarning("Received upload completed message without correlation ID");
                    return null;
                }

                _logger.LogInformation($"Broadcasting upload completed message for correlation ID: {uploadCompleted.CorrelationId}");

                return new SignalRMessageAction("uploadCompleted")
                {
                    Arguments = new object[] { uploadCompleted },
                    GroupName = $"upload_{uploadCompleted.CorrelationId}"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting upload completed message");
                return null;
            }
        }

        [Function("SendUploadTimedOut")]
        [SignalROutput(HubName = "bulkUploadHub")]
        public async Task<SignalRMessageAction> SendUploadTimedOut(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            try
            {
                var requestBody = await req.ReadAsStringAsync();
                var uploadTimedOut = JsonSerializer.Deserialize<UploadTimedOutMessage>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (uploadTimedOut?.CorrelationId == null)
                {
                    _logger.LogWarning("Received upload timeout message without correlation ID");
                    return null;
                }

                _logger.LogInformation($"Broadcasting upload timeout message for correlation ID: {uploadTimedOut.CorrelationId}");

                return new SignalRMessageAction("uploadTimedOut")
                {
                    Arguments = new object[] { uploadTimedOut },
                    GroupName = $"upload_{uploadTimedOut.CorrelationId}"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting upload timeout message");
                return null;
            }
        }

        [Function("JoinGroup")]
        [SignalROutput(HubName = "bulkUploadHub")]
        public async Task<object> JoinGroupHttp(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", "options")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            
            // Add CORS headers
            response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            response.Headers.Add("Access-Control-Allow-Credentials", "true");
            
            // Handle preflight OPTIONS request
            if (req.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
            {
                return response;
            }
            
            try
            {
                var requestBody = await req.ReadAsStringAsync();
                var joinRequest = JsonSerializer.Deserialize<JoinGroupRequest>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (string.IsNullOrEmpty(joinRequest?.ConnectionId) || string.IsNullOrEmpty(joinRequest?.CorrelationId))
                {
                    _logger.LogWarning("Invalid join group request - missing connection ID or correlation ID");
                    return null;
                }

                var groupName = $"upload_{joinRequest.CorrelationId}";
                _logger.LogInformation($"Adding connection {joinRequest.ConnectionId} to group {groupName}");

                // Return SignalR group action
                return new SignalRGroupAction(SignalRGroupActionType.Add)
                {
                    ConnectionId = joinRequest.ConnectionId,
                    GroupName = groupName
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining group");
                return null;
            }
        }
    }

    public class UploadStartedMessage
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecordsCount { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public string DocId { get; set; }
    }

    public class UploadProgressMessage
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int ProcessedRecords { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public double PercentageComplete { get; set; }
        public string CurrentStatus { get; set; }
    }

    public class UploadCompletedMessage
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string Status { get; set; }
        public string[] Errors { get; set; }
    }

    public class UploadTimedOutMessage
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public DateTimeOffset TimedOutAt { get; set; }
        public string Status { get; set; }
    }

    public class JoinGroupRequest
    {
        public string ConnectionId { get; set; }
        public string CorrelationId { get; set; }
    }
}