using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Person name type
    /// </summary>
    [DataContract(Name = "personNameType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "personNameType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class PersonNameType
    {
        [DataMember]
        [XmlElement("GivenName")]
        public string GivenName { get; set; }

        [DataMember]
        [XmlElement("FamilyName")]
        public string FamilyName { get; set; }

        [DataMember]
        [XmlElement("MiddleName")]
        public string MiddleName { get; set; }

        [DataMember]
        [XmlElement("Title")]
        public string Title { get; set; }
    }
}