using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Biometric match ID type for matching operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricMatchIdType
    {
        /// <summary>
        /// Match identifier
        /// </summary>
        [DataMember]
        public string MatchId { get; set; }

        /// <summary>
        /// Match confidence score
        /// </summary>
        [DataMember]
        public decimal? MatchScore { get; set; }

        /// <summary>
        /// Match date
        /// </summary>
        [DataMember]
        public DateTime MatchDate { get; set; }
    }
}