using System;

namespace Beneficiary.Domain.Contracts.Commands
{
    public class RegisterBeneficiaryCommand : Beneficiary.Domain.Contracts.IProvideCorrelationId
    {
        public string CorrelationId { get; set; }

        public string BeneficiaryId { get; set; }
        public string PersonId { get; set; }
        public string OfficeId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string DocId { get; set; }
    }
}