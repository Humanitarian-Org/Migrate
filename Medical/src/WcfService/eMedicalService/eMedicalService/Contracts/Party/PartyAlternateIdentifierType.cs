using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Alternate party identifier type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierType
    {
        [DataMember]
        public string AlternateIdentifier { get; set; }

        [DataMember]
        public string AlternateIdentifierType { get; set; }
    }
}