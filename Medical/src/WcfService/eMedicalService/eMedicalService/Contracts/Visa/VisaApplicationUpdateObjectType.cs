using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa application update object type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaApplicationUpdateObjectType
    {
        /// <summary>
        /// Application identifier
        /// </summary>
        [DataMember]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Update type
        /// </summary>
        [DataMember]
        public string UpdateType { get; set; }

        /// <summary>
        /// Updated visa information
        /// </summary>
        [DataMember]
        public VisaType UpdatedVisaInformation { get; set; }

        /// <summary>
        /// Update timestamp
        /// </summary>
        [DataMember]
        public DateTime UpdateTimestamp { get; set; }

        /// <summary>
        /// Update reason
        /// </summary>
        [DataMember]
        public string UpdateReason { get; set; }
    }
}