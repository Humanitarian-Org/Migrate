using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Address.Core.V1
{
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
}