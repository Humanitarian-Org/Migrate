using System;

namespace Platform.Domain.Contracts.Events
{
    public class BulkBeneficiaryUploadProgress : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int ProcessedRecords { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public string Status { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}