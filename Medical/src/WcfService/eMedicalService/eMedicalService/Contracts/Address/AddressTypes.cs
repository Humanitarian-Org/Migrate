using System;
using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
    /// <summary>
    /// Contact method type enumeration
    /// </summary>
    [DataContract(Name = "contactMethodTypeType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public enum ContactMethodTypeType
    {
        [EnumMember]
        ADDRESS,
        [EnumMember]
        EMAIL,
        [EnumMember]
        FAX,
        [EnumMember]
        TELEPHONE,
        [EnumMember]
        MOBILE,
        [EnumMember]
        TELEX,
        [EnumMember]
        VOIP
    }

    /// <summary>
    /// Unstructured address type enumeration
    /// </summary>
    [DataContract(Name = "unstructuredAddressTypeType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public enum UnstructuredAddressTypeType
    {
        [EnumMember]
        RESIDENTIAL,
        [EnumMember]
        POSTAL,
        [EnumMember]
        BUSINESS,
        [EnumMember]
        OTHER
    }

    /// <summary>
    /// Party address type with usage and validity period
    /// </summary>
    [DataContract(Name = "partyAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "partyAddressType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class PartyAddressType
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement("UsageCode")]
        public string UsageCode { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("StartDate", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public DateTime? StartDate { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("EndDate", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// Party address details containing structured address information
    /// </summary>
    [DataContract(Name = "partyAddressDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "partyAddressDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class PartyAddressDetailsType : PartyAddressType
    {
        [DataMember(Order = 3)]
        [XmlElement("SemistructuredAddress")]
        public SemistructuredAddressType SemistructuredAddress { get; set; }
    }

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

    /// <summary>
    /// Party address system details with system-specific information
    /// </summary>
    [DataContract(Name = "partyAddressSystemDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    [XmlType(TypeName = "partyAddressSystemDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class PartyAddressSystemDetailsType
    {
        [DataMember(Order = 0)]
        [XmlElement("SystemCode")]
        public string SystemCode { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("SystemAddressId")]
        public string SystemAddressId { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("SystemAddressType")]
        public string SystemAddressType { get; set; }
    }

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