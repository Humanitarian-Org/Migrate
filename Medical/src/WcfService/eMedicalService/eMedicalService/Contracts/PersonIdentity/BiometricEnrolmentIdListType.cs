using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// List of biometric enrolment IDs
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricEnrolmentIdListType
    {
        /// <summary>
        /// Collection of biometric enrolment IDs
        /// </summary>
        [DataMember]
        public List<BiometricEnrolmentIdType> BiometricEnrolmentId { get; set; } = new List<BiometricEnrolmentIdType>();
    }
}