using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Search index identifier for party searches
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class SearchIndexIdentifierType
    {
        [DataMember]
        public string SearchIndexValue { get; set; }

        [DataMember]
        public PartySearchTypeType SearchIndexType { get; set; }
    }
}