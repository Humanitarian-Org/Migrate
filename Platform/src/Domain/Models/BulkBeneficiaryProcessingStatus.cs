using System;
using System.Collections.Generic;

namespace Platform.Domain.Models
{
    public class BulkBeneficiaryProcessingStatus
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecords { get; set; }
        public int ProcessedRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public List<BeneficiaryProcessingResult> Results { get; set; } = new List<BeneficiaryProcessingResult>();
        public bool IsComplete => ProcessedRecords >= TotalRecords;
        public DateTimeOffset LastUpdated { get; set; }
    }

    public class BeneficiaryProcessingResult
    {
        public string BeneficiaryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; } // "Success", "Failed", "Pending"
        public string Error { get; set; }
        public DateTimeOffset ProcessedAt { get; set; }
    }
}