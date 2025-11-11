using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Contact person type for party relationships
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class ContactPersonType
    {
        [DataMember]
        public string ContactPersonName { get; set; }

        [DataMember]
        public string ContactPersonRole { get; set; }

        [DataMember]
        public PartyIdentifierType ContactPersonIdentifier { get; set; }
    }
}