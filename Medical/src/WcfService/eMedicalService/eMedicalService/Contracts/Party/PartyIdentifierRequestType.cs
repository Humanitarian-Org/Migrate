using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Party identifier request type for identifier requests
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierRequestType
    {
        [DataMember]
        public PartyIdentifierType PartyIdentifier { get; set; }

        [DataMember]
        public PartyTypeType? PartyType { get; set; }

        [DataMember]
        public string RequestContext { get; set; }
    }
}