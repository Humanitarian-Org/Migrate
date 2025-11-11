using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business context type for business process identification and management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessContextType
    {
        /// <summary>
        /// Unique identifier for the business context
        /// </summary>
        [DataMember]
        public string BusinessContextId { get; set; }

        /// <summary>
        /// Type classification of the business context
        /// </summary>
        [DataMember]
        public string BusinessContextType_Value { get; set; }

        /// <summary>
        /// Optional sub-type classification
        /// </summary>
        [DataMember]
        public string BusinessContextSubType { get; set; }

        /// <summary>
        /// Optional container identifier for grouping contexts
        /// </summary>
        [DataMember]
        public string BusinessContextContainerId { get; set; }
    }
}