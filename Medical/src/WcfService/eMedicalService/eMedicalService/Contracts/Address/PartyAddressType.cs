using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
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
}