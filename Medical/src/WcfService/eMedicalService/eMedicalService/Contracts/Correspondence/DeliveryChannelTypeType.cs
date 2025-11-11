using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for correspondence delivery channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum DeliveryChannelTypeType
    {
        /// <summary>
        /// Email delivery
        /// </summary>
        [EnumMember]
        EMAIL,

        /// <summary>
        /// Postal delivery
        /// </summary>
        [EnumMember]
        POST,

        /// <summary>
        /// Fax delivery
        /// </summary>
        [EnumMember]
        FAX,

        /// <summary>
        /// Hand delivery
        /// </summary>
        [EnumMember]
        BY_HAND,

        /// <summary>
        /// Hand delivery to last known address
        /// </summary>
        [EnumMember]
        BY_HAND_LAST_KNOWN
    }
}