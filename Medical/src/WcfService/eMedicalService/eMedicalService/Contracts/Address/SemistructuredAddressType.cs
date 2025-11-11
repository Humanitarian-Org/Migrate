using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
    /// <summary>
    /// Semi-structured address with individual components
    /// </summary>
    [DataContract(Name = "semistructuredAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "semistructuredAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class SemistructuredAddressType
    {
        [DataMember(Order = 0)]
        [XmlElement("AddressLine1")]
        public string AddressLine1 { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("AddressLine2")]
        public string AddressLine2 { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("AddressLine3")]
        public string AddressLine3 { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("AddressLine4")]
        public string AddressLine4 { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("LocalityName")]
        public string LocalityName { get; set; }

        [DataMember(Order = 5)]
        [XmlElement("StateTerritoryName")]
        public string StateTerritoryName { get; set; }

        [DataMember(Order = 6)]
        [XmlElement("CountryCode")]
        public string CountryCode { get; set; }

        [DataMember(Order = 7)]
        [XmlElement("PostalCode")]
        public string PostalCode { get; set; }
    }
}