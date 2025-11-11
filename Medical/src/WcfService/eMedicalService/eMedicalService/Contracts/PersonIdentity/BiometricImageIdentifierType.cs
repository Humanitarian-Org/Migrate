using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Biometric image identifier type for biometric image management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricImageIdentifierType
    {
        /// <summary>
        /// Image identifier value
        /// </summary>
        [DataMember]
        public string ImageId { get; set; }

        /// <summary>
        /// Type of image identifier
        /// </summary>
        [DataMember]
        public BiometricIdentifierTypeType IdentifierType { get; set; }

        /// <summary>
        /// Biometric type of the image
        /// </summary>
        [DataMember]
        public BiometricTypeType BiometricType { get; set; }
    }
}