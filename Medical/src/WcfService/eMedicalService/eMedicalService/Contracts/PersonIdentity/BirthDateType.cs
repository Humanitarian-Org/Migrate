using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Birth date type for person birth information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BirthDateType
    {
        /// <summary>
        /// Birth date
        /// </summary>
        [DataMember]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Indicates if birth date is estimated
        /// </summary>
        [DataMember]
        public bool IsEstimated { get; set; }

        /// <summary>
        /// Birth date verification status
        /// </summary>
        [DataMember]
        public VerificationStatusCodeType? VerificationStatus { get; set; }
    }
}