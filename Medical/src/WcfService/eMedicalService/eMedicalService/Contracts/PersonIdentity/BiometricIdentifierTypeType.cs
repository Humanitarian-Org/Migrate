using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for biometric identifier types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum BiometricIdentifierTypeType
    {
        /// <summary>
        /// Biometric enrolment ID
        /// </summary>
        [EnumMember]
        ENROLMENT_ID,

        /// <summary>
        /// Biometric collection ID
        /// </summary>
        [EnumMember]
        COLLECTION_ID,

        /// <summary>
        /// Biometric match ID
        /// </summary>
        [EnumMember]
        MATCH_ID
    }
}