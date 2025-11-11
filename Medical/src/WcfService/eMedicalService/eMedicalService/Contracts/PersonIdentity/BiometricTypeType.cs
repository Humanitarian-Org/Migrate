using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for biometric types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum BiometricTypeType
    {
        /// <summary>
        /// Facial biometric
        /// </summary>
        [EnumMember]
        FACIAL,

        /// <summary>
        /// FCC facial biometric
        /// </summary>
        [EnumMember]
        FCC_FACIAL
    }
}