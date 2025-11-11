using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// List of detailed party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierDetailsListType
    {
        [DataMember]
        public List<PartyIdentifierDetailsType> PartyIdentifierDetails { get; set; } = new List<PartyIdentifierDetailsType>();
    }
}