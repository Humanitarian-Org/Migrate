using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// List of party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierListType
    {
        [DataMember]
        public List<PartyIdentifierType> PartyIdentifier { get; set; } = new List<PartyIdentifierType>();
    }
}