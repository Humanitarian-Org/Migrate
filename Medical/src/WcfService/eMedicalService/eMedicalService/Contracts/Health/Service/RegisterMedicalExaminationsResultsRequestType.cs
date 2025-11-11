using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterMedicalExaminationsResultsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2)]
        public RegisterMedicalExaminationsResultsRequestIdentityDocumentType IdentityDocument { get; set; }

        [DataMember(Order = 3)]
        public HealthFacialImageMsgType HealthFacialImageMsg { get; set; }

        [DataMember(Order = 4)]
        public HealthCaseDetailFormType HealthCaseDetailForm { get; set; }

        [DataMember(Order = 5, Name = "HealthCaseAttachmentMsg")]
        public HealthCaseAttachmentMsgType[] HealthCaseAttachmentMsg { get; set; }

        [DataMember(Order = 6, Name = "HealthRequirement")]
        public RegisterMedicalExaminationsResultsRequestHealthRequirementType[] HealthRequirement { get; set; }

        [DataMember(Order = 7)]
        public string ProcessingUnit { get; set; } = string.Empty;
    }
}