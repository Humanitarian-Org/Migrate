using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Generic identifier type for flexible identifier management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class GenericIdentifierType
    {
        [DataMember]
        public string GenericIdentifierValue { get; set; }

        [DataMember]
        public string IdentifierType { get; set; }
    }
}