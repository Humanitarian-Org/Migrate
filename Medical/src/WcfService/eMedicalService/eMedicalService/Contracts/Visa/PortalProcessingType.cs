using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Portal processing type for portal-based processing
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class PortalProcessingType
    {
        /// <summary>
        /// Portal identifier
        /// </summary>
        [DataMember]
        public string PortalId { get; set; }

        /// <summary>
        /// Portal name
        /// </summary>
        [DataMember]
        public string PortalName { get; set; }

        /// <summary>
        /// Processing status in portal
        /// </summary>
        [DataMember]
        public string ProcessingStatus { get; set; }

        /// <summary>
        /// Portal reference number
        /// </summary>
        [DataMember]
        public string PortalReferenceNumber { get; set; }
    }
}