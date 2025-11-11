using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Biometric enrolment ID type for enrolment tracking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricEnrolmentIdType
    {
        /// <summary>
        /// Enrolment identifier
        /// </summary>
        [DataMember]
        public string EnrolmentId { get; set; }

        /// <summary>
        /// Enrolment date
        /// </summary>
        [DataMember]
        public DateTime EnrolmentDate { get; set; }

        /// <summary>
        /// Acquisition method used
        /// </summary>
        [DataMember]
        public AcquisitionMethodCodeType AcquisitionMethod { get; set; }

        /// <summary>
        /// Acquisition status
        /// </summary>
        [DataMember]
        public AcquisitionStatusCodeType AcquisitionStatus { get; set; }
    }
}