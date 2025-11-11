using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
    /// <summary>
    /// Telephone line type with structured telephone information
    /// </summary>
    [DataContract(Name = "telephoneLineType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "telephoneLineType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class TelephoneLineType
    {
        [DataMember(Order = 0)]
        [XmlElement("ServiceCode")]
        public string ServiceCode { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("ExtensionNumber")]
        public string ExtensionNumber { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("TelephoneNumber")]
        public string TelephoneNumber { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("AreaCode")]
        public int? AreaCode { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("CountryTelephoneCode")]
        public string CountryTelephoneCode { get; set; }

        [DataMember(Order = 5)]
        [XmlElement("UnstructuredTelephoneNumber")]
        public string UnstructuredTelephoneNumber { get; set; }
    }
}