using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Address
{
    [DataContract(Name = "AddressMsgType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class AddressMsgType
    {
        [DataMember]
        public string AddressLine1 { get; set; } = string.Empty;

        [DataMember]
        public string AddressLine2 { get; set; } = string.Empty;

        [DataMember]
        public string Suburb { get; set; } = string.Empty;

        [DataMember]
        public string State { get; set; } = string.Empty;

        [DataMember]
        public string PostalCode { get; set; } = string.Empty;

        [DataMember]
        public string Country { get; set; } = string.Empty;
    }
}