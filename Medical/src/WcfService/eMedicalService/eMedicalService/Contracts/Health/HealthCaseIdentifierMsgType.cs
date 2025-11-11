using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Health case identifier message type 
    /// </summary>
    [DataContract(Name = "healthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "healthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }
    }
}