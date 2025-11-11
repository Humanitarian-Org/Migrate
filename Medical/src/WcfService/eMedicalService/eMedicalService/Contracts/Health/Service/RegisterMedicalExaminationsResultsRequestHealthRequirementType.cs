using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestHealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestHealthRequirementType
    {
        [DataMember]
        public HealthRequirementMsgType HealthRequirementMsg { get; set; }

        [DataMember]
        public HealthRequirementIdentifierMsgType HealthRequirementIdentifierMsg { get; set; }

        [DataMember]
        public RegisterMedicalExaminationsResultsRequestExaminationType Examination { get; set; }
    }
}