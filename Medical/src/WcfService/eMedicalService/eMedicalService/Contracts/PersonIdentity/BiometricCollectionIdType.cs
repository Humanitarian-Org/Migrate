using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Biometric collection ID type for collection management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricCollectionIdType
    {
        /// <summary>
        /// Collection identifier
        /// </summary>
        [DataMember]
        public string CollectionId { get; set; }

        /// <summary>
        /// Collection date
        /// </summary>
        [DataMember]
        public DateTime CollectionDate { get; set; }

        /// <summary>
        /// Collection location
        /// </summary>
        [DataMember]
        public string CollectionLocation { get; set; }
    }
}