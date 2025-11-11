using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Declared citizenship type for citizenship information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class DeclaredCitizenshipType
    {
        /// <summary>
        /// Citizenship country code
        /// </summary>
        [DataMember]
        public string CitizenshipCountryCode { get; set; }

        /// <summary>
        /// Citizenship country name
        /// </summary>
        [DataMember]
        public string CitizenshipCountryName { get; set; }

        /// <summary>
        /// Date citizenship acquired
        /// </summary>
        [DataMember]
        public DateTime? CitizenshipAcquiredDate { get; set; }

        /// <summary>
        /// Verification status of the citizenship
        /// </summary>
        [DataMember]
        public VerificationStatusCodeType? VerificationStatus { get; set; }
    }
}