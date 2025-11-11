using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Match context identifier for matching operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class MatchContextIdentifierType
    {
        [DataMember]
        public string MatchContextValue { get; set; }

        [DataMember]
        public string MatchContextType { get; set; }
    }
}