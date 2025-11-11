using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Enumeration for channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum ChannelTypeType
    {
        /// <summary>
        /// Electronic channel
        /// </summary>
        [EnumMember]
        ELECTRONIC,

        /// <summary>
        /// Paper-based channel
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// Phone channel
        /// </summary>
        [EnumMember]
        PHONE,

        /// <summary>
        /// In-person channel
        /// </summary>
        [EnumMember]
        IN_PERSON
    }
}