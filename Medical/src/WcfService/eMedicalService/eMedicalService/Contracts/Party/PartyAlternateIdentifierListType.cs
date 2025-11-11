using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// List of alternate party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierListType
    {
        [DataMember]
        public List<PartyAlternateIdentifierType> PartyAlternateIdentifier { get; set; } = new List<PartyAlternateIdentifierType>();
    }
}