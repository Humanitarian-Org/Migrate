using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
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
}