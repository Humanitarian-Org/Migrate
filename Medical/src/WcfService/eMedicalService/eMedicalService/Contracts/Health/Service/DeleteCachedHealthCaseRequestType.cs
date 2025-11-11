using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("DeleteCachedHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseRequestType
    {
        [XmlElement("CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("DeletionReason")]
        public string DeletionReason { get; set; } = string.Empty;

        [XmlElement("HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifierMsg { get; set; }
    }
}