using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for acquisition method codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum AcquisitionMethodCodeType
    {
        /// <summary>
        /// Digital acquisition method
        /// </summary>
        [EnumMember]
        DIGITAL,

        /// <summary>
        /// Manual acquisition method
        /// </summary>
        [EnumMember]
        MANUAL,

        /// <summary>
        /// Automatic acquisition method
        /// </summary>
        [EnumMember]
        AUTOMATIC
    }
}