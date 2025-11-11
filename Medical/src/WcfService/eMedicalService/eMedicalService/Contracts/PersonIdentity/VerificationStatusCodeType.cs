using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for verification status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum VerificationStatusCodeType
    {
        /// <summary>
        /// Verification successful
        /// </summary>
        [EnumMember]
        VERIFIED,

        /// <summary>
        /// Verification failed
        /// </summary>
        [EnumMember]
        FAILED,

        /// <summary>
        /// Verification pending
        /// </summary>
        [EnumMember]
        PENDING,

        /// <summary>
        /// Not verified
        /// </summary>
        [EnumMember]
        NOT_VERIFIED
    }
}