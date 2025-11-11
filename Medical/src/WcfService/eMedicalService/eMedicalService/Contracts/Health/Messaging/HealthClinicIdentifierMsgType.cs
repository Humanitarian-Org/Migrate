using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [XmlType(TypeName = "HealthClinicIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClinicIdentifierMsgType
    {
        [XmlElement("HealthClinicIdentifier", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthClinicIdentifier { get; set; } = string.Empty;

        [XmlElement("HealthClinicIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthClinicIdentifierType { get; set; } = string.Empty;
    }
}