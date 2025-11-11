using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business event type for business process event tracking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessEventType
    {
        /// <summary>
        /// Type of business event
        /// </summary>
        [DataMember]
        public string BusinessEventType_Value { get; set; }

        /// <summary>
        /// Optional qualifier for the business event
        /// </summary>
        [DataMember]
        public string BusinessEventQualifierType { get; set; }
    }
}