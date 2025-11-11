using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Anchor identifier for party linking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class AnchorIdentifierType
    {
        [DataMember]
        public string AnchorValue { get; set; }

        [DataMember]
        public string AnchorType { get; set; }
    }
}