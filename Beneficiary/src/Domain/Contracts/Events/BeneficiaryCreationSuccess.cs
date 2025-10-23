using System;

namespace Beneficiary.Domain.Contracts.Events
{
    public class BeneficiaryCreationSuccess
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public string RecordId { get; set; } // GUID to identify specific beneficiary record
        public string BeneficiaryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ProcessedBy { get; set; } = "Beneficiary.Endpoint";
    }
}