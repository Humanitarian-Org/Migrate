using System;

namespace Beneficiary.Domain.Contracts.Events
{
    public class BeneficiaryRegistrationCompleted : Beneficiary.Domain.Contracts.IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string BeneficiaryId { get; set; }
        public string PersonId { get; set; }
        public string OfficeId { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string DocId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}