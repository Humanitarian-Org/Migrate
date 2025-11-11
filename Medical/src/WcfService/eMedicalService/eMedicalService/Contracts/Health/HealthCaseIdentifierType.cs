using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Health case identifier type
    /// </summary>
    [DataContract(Name = "healthCaseIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "healthCaseIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifierValue")]
        public string HealthCaseIdentifierValue { get; set; }
    }
}