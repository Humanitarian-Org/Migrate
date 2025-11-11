using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Core party identifier type containing an identifier and its type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierType
    {
        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public IdentifierTypeType IdentifierType { get; set; }
    }
}