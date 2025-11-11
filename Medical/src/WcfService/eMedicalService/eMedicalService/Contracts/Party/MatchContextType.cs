using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Match context type for party matching
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class MatchContextType
    {
        [DataMember]
        public string MatchContext { get; set; }

        [DataMember]
        public List<MatchContextIdentifierType> MatchContextIdentifiers { get; set; } = new List<MatchContextIdentifierType>();
    }
}