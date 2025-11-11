using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
    /// <summary>
    /// Fax address type with fax-specific information
    /// </summary>
    [DataContract(Name = "faxAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "faxAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class FaxAddressType
    {
        [DataMember(Order = 0)]
        [XmlElement("FaxNumber")]
        public string FaxNumber { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("AreaCode")]
        public int? AreaCode { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("CountryTelephoneCode")]
        public string CountryTelephoneCode { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("UnstructuredFaxNumber")]
        public string UnstructuredFaxNumber { get; set; }
    }
}