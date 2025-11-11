using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Party context type for party information within records
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class PartyContextType
    {
        /// <summary>
        /// Party identifier
        /// </summary>
        [DataMember]
        public string PartyId { get; set; }

        /// <summary>
        /// Party role in the context
        /// </summary>
        [DataMember]
        public string PartyRole { get; set; }

        /// <summary>
        /// Party context description
        /// </summary>
        [DataMember]
        public string PartyContextDescription { get; set; }
    }
}