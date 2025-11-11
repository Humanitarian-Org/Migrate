using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Enumeration for party types - either ORGANISATION or PERSON
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum PartyTypeType
    {
        [EnumMember]
        ORGANISATION,
        
        [EnumMember]
        PERSON
    }
}