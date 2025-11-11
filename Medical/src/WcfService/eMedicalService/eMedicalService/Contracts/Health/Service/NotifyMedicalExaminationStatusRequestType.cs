using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Core;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestType
    {
        [XmlElement(ElementName = "CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Core/V1.0")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement(ElementName = "HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [XmlElement(ElementName = "CachedCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [XmlElement(ElementName = "HealthCaseStatusUpdate")]
        public HealthCaseStatusUpdateType HealthCaseStatusUpdate { get; set; }

        [XmlElement(ElementName = "ExaminationStatus")]
        public string ExaminationStatus { get; set; } = string.Empty;

        [XmlElement(ElementName = "HealthRequirements")]
        public NotifyMedicalExaminationStatusRequestHealthRequirementType[] HealthRequirements { get; set; }

        [XmlElement(ElementName = "ClientContext")]
        public NotifyMedicalStatusRequestHealthClientContextType ClientContext { get; set; }
    }
}