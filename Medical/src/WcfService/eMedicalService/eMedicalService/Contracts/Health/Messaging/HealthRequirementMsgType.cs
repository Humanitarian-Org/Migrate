using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthRequirementMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthRequirementMsgType
    {
        [DataMember]
        public string RequirementCode { get; set; } = string.Empty;

        [DataMember]
        public string RequirementDescription { get; set; } = string.Empty;

        [DataMember]
        public string AssessmentType { get; set; } = string.Empty;
    }
}