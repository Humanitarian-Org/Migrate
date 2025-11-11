using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Enumeration for direction types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum DirectionTypeType
    {
        /// <summary>
        /// Inbound direction
        /// </summary>
        [EnumMember]
        INBOUND,

        /// <summary>
        /// Outbound direction
        /// </summary>
        [EnumMember]
        OUTBOUND,

        /// <summary>
        /// Bidirectional
        /// </summary>
        [EnumMember]
        BIDIRECTIONAL
    }
}