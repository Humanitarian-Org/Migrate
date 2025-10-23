using System;
using System.Text.Json;
using System.Collections.Generic;

namespace Medical.Domain.Managers.Services.MedicalIntegrationDb
{
    public class MedicalMessage
    {
        // CosmosDB requires a root-level id property
        public string id { get; set; }
        public MedicalMessageMetadata Metadata { get; set; }
        public FinalResultsMessage FinalResult { get; set; }
        public UpdateMessages UpdateMessages { get; set; }
        public DeleteOrTransferMessage DeleteOrTransferMessage { get; set; }
        public CaseRegistrationMessage CaseRegistration { get; set; }
    }

    public class CaseRegistrationMessage
    {
        public MedicalMessageMetadata Metadata { get; set; }
        public JsonElement Message { get; set; }
    }

    public class FinalResultsMessage
    {
        public MedicalMessageMetadata Metadata { get; set; }
        public JsonElement Message { get; set; }
    }

    public class UpdateMessages
    {
        public MedicalMessageMetadata Metadata { get; set; }
        public List<JsonElement> Messages { get; set; }
    }

    public class DeleteOrTransferMessage
    {
        public MedicalMessageMetadata Metadata { get; set; }
        public JsonElement Message { get; set; }
    }

    
    public class MedicalMessageMetadata
    {
        public string Id { get; set; } // CosmosDB id
        public string MessageType { get; set; } // 445, 440, 441, 439
        public DateTime ReceivedUtc { get; set; }
        public string SourceSystem { get; set; }
        public string CaseId { get; set; }
        public string CorrelationId { get; set; }
        // Add more metadata fields as needed
    }
}
