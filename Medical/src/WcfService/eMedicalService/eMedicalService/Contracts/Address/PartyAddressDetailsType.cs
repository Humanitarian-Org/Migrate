using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
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
}