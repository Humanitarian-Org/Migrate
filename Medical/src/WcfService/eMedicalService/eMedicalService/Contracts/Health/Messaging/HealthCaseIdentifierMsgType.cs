using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [XmlType(TypeName = "HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [XmlElement("HealthCaseIdentifier", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }
    }

    [XmlType(TypeName = "HealthCaseIdentifier", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierType
    {
        [XmlElement("HealthCaseIdentifierValue")]
        public string HealthCaseIdentifierValue { get; set; } = string.Empty;

        [XmlElement("HealthCaseIdentifierType")]
        public string IdentifierTypeValue { get; set; } = string.Empty;
    }
}