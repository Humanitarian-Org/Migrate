using System;

namespace Platform.Domain.Contracts.Events
{
    public class BulkBeneficiaryUploadCompleted : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string Status { get; set; }
        public string[] Errors { get; set; }
        public string UserId { get; set; }
    }
}