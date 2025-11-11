using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa status type for visa status information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaStatusType
    {
        /// <summary>
        /// Status code
        /// </summary>
        [DataMember]
        public string StatusCode { get; set; }

        /// <summary>
        /// Status description
        /// </summary>
        [DataMember]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Status effective date
        /// </summary>
        [DataMember]
        public DateTime StatusEffectiveDate { get; set; }

        /// <summary>
        /// Status change reason
        /// </summary>
        [DataMember]
        public string StatusChangeReason { get; set; }
    }
}