using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthRequirementIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthRequirementIdentifierMsgType
    {
        [DataMember]
        public string RequirementId { get; set; } = string.Empty;

        [DataMember]
        public string RequirementVersion { get; set; } = string.Empty;
    }
}