using System.Runtime.Serialization;

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
}