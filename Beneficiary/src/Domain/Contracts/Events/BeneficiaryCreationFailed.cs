using System;

namespace Beneficiary.Domain.Contracts.Events
{
    public class BeneficiaryCreationFailed
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public string RecordId { get; set; } // GUID to identify specific beneficiary record
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Error { get; set; }
        public DateTimeOffset FailedAt { get; set; }
        public bool IsRetryable { get; set; } // TODO: Implement logic to distinguish technical vs business exceptions
        public string ProcessedBy { get; set; } = "Beneficiary.Endpoint";
    }
}