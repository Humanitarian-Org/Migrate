namespace Beneficiary.Domain.Managers.Services.BeneficiaryIntegrationDb
{
    using System;
    using System.Text.Json;

    public class BeneficiaryMessage
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public BeneficiaryMessageMetadata Metadata { get; set; }
        public BeneficiaryRegistrationMessage BeneficiaryRegistration { get; set; }
    }

    public class BeneficiaryMessageMetadata
    {
        public string MessageType { get; set; }
        public DateTime ReceivedUtc { get; set; }
        public string SourceSystem { get; set; }
        public string BeneficiaryId { get; set; }
        public string CorrelationId { get; set; }
    }

    public class BeneficiaryRegistrationMessage
    {
        public BeneficiaryMessageMetadata Metadata { get; set; }
        public JsonElement Message { get; set; }
    }
}