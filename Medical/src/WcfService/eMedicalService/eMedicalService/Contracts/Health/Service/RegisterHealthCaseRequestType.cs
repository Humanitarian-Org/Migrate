using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Core;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequestType
    {
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("CachedCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [XmlElement("HealthClinicIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthClinicIdentifierMsgType HealthClinicIdentifierMsg { get; set; }

        [XmlElement("RegisterHealthCaseClientBiographicalDetails")]
        public RegisterHealthCaseClientBiographicalDetailsType RegisterHealthCaseClientBiographicalDetails { get; set; }
    }
}