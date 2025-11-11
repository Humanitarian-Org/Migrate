using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("RegisterMedicalExaminationsResultsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestType
    {
        [XmlElement(ElementName = "CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Core/V1.0")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement(ElementName = "HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [XmlElement(ElementName = "RegisterMedicalExaminationsResultsRequestIdentityDocument")]
        public RegisterMedicalExaminationsResultsRequestIdentityDocumentType RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

        [XmlElement(ElementName = "IdentityDocument")]
        public RegisterMedicalExaminationsResultsRequestIdentityDocumentType IdentityDocument { get; set; }

        [XmlElement(ElementName = "HealthFacialImageMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/V1.0")]
        public HealthFacialImageMsgType HealthFacialImageMsg { get; set; }

        [XmlElement(ElementName = "HealthCaseDetailForm")]
        public HealthCaseDetailFormType HealthCaseDetailForm { get; set; }

        [XmlElement(ElementName = "HealthCaseAttachmentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/V1.0")]
        public HealthCaseAttachmentMsgType[] HealthCaseAttachmentMsg { get; set; }

        [XmlElement(ElementName = "HealthRequirement")]
        public RegisterMedicalExaminationsResultsRequestHealthRequirementType[] HealthRequirement { get; set; }

        [XmlElement(ElementName = "ProcessingUnit")]
        public string ProcessingUnit { get; set; } = string.Empty;
    }
}