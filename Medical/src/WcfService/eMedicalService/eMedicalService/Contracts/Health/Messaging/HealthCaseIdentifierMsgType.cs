using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [DataMember]
        public string HealthCaseId { get; set; } = string.Empty;

        [DataMember]
        public string CaseTypeCode { get; set; } = string.Empty;

        [DataMember]
        public string VisaCategoryCode { get; set; } = string.Empty;

        [DataMember]
        public string ProcessingUnitCode { get; set; } = string.Empty;
    }
}