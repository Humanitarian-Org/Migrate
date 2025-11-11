using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlType(TypeName = "NotifyCachedHealthClientDetailsUpdateRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyCachedHealthClientDetailsUpdateRequestType
    {
        [XmlElement("CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("UpdateDate")]
        public DateTime UpdateDate { get; set; }

        [XmlElement("UpdateReason")]
        public string UpdateReason { get; set; } = string.Empty;

        [XmlElement("HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [XmlElement("ClientDetails")]
        public string ClientDetails { get; set; } = string.Empty;
    }
}