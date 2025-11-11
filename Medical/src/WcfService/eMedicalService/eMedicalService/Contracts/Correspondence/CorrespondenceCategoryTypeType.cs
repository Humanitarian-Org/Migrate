using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for correspondence category types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceCategoryTypeType
    {
        /// <summary>
        /// Inbound correspondence
        /// </summary>
        [EnumMember]
        INBOUND,

        /// <summary>
        /// Outbound correspondence
        /// </summary>
        [EnumMember]
        OUTBOUND,

        /// <summary>
        /// Internal correspondence
        /// </summary>
        [EnumMember]
        INTERNAL,

        /// <summary>
        /// System generated correspondence
        /// </summary>
        [EnumMember]
        SYSTEM_GENERATED
    }
}