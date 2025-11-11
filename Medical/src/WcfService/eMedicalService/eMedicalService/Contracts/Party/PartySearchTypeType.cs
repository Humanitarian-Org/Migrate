using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Enumeration for party search types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum PartySearchTypeType
    {
        [EnumMember]
        IDENTITY_DOCUMENT,
        
        [EnumMember]
        ORGANISATION_ID,
        
        [EnumMember]
        PERSON_ID,
        
        [EnumMember]
        ORGANISATION,
        
        [EnumMember]
        PERSON,
        
        [EnumMember]
        GENERIC
    }
}