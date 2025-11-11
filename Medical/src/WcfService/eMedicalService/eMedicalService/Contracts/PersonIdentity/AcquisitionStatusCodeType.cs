using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for acquisition status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum AcquisitionStatusCodeType
    {
        /// <summary>
        /// Successfully acquired
        /// </summary>
        [EnumMember]
        SUCCESS,

        /// <summary>
        /// Failed to acquire
        /// </summary>
        [EnumMember]
        FAILED,

        /// <summary>
        /// Partially acquired
        /// </summary>
        [EnumMember]
        PARTIAL,

        /// <summary>
        /// Acquisition pending
        /// </summary>
        [EnumMember]
        PENDING
    }
}