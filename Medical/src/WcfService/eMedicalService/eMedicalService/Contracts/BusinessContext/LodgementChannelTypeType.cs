using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Enumeration for lodgement channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public enum LodgementChannelTypeType
    {
        /// <summary>
        /// Paper-based lodgement channel
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// Electronic lodgement channel
        /// </summary>
        [EnumMember]
        ELECTRONIC,

        /// <summary>
        /// Data load lodgement channel
        /// </summary>
        [EnumMember]
        DATALOAD
    }
}