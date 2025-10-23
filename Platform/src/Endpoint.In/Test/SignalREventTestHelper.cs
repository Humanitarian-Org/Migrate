using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Platform.Domain.Contracts.Events;

namespace Endpoint.In.Test
{
    /// <summary>
    /// Simple test class to demonstrate event publishing and handling.
    /// This can be used for manual testing or as a base for unit tests.
    /// </summary>
    public class SignalREventTestHelper
    {
        private readonly ILogger<SignalREventTestHelper> _logger;

        public SignalREventTestHelper(ILogger<SignalREventTestHelper> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a sample BulkBeneficiaryUploadStarted event for testing.
        /// </summary>
        public BulkBeneficiaryUploadStarted CreateSampleUploadStartedEvent()
        {
            var correlationId = Guid.NewGuid().ToString();
            var uploadId = Guid.NewGuid().ToString();
            
            return new BulkBeneficiaryUploadStarted
            {
                CorrelationId = correlationId,
                UploadId = uploadId,
                TotalRecordsCount = 100,
                StartedAt = DateTimeOffset.UtcNow,
                UserId = "test-user",
                FileName = "test-beneficiaries.csv",
                DocId = Guid.NewGuid().ToString()
            };
        }

        /// <summary>
        /// Creates a sample BulkBeneficiaryUploadProgress event for testing.
        /// </summary>
        public BulkBeneficiaryUploadProgress CreateSampleUploadProgressEvent(string correlationId, string uploadId)
        {
            return new BulkBeneficiaryUploadProgress
            {
                CorrelationId = correlationId,
                UploadId = uploadId,
                ProcessedRecords = 50,
                TotalRecords = 100,
                SuccessfulRecords = 48,
                FailedRecords = 2,
                Status = "Processing in progress",
                UpdatedAt = DateTimeOffset.UtcNow
            };
        }

        /// <summary>
        /// Creates a sample BulkBeneficiaryUploadCompleted event for testing.
        /// </summary>
        public BulkBeneficiaryUploadCompleted CreateSampleUploadCompletedEvent(string correlationId, string uploadId)
        {
            return new BulkBeneficiaryUploadCompleted
            {
                CorrelationId = correlationId,
                UploadId = uploadId,
                TotalRecords = 100,
                SuccessfulRecords = 95,
                FailedRecords = 5,
                CompletedAt = DateTimeOffset.UtcNow,
                Status = "Completed with some errors",
                Errors = new[] { "Invalid date format in row 10", "Missing required field in row 25" },
                UserId = "test-user"
            };
        }

        /// <summary>
        /// Logs information about event processing for testing purposes.
        /// </summary>
        public void LogEventProcessing(string eventType, string correlationId)
        {
            _logger.LogInformation($"[SignalREventTestHelper] Processing {eventType} event | CorrelationId: {correlationId}");
        }
    }
}