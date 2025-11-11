using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// List of detailed alternate party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierDetailsListType
    {
        [DataMember]
        public List<PartyAlternateIdentifierDetailsType> PartyAlternateIdentifierDetails { get; set; } = new List<PartyAlternateIdentifierDetailsType>();
    }
}