using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Enumeration for lodgement method types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public enum LodgementMethodTypeType
    {
        /// <summary>
        /// Online lodgement
        /// </summary>
        [EnumMember]
        ONLINE,

        /// <summary>
        /// Paper-based lodgement
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// In-person lodgement
        /// </summary>
        [EnumMember]
        IN_PERSON,

        /// <summary>
        /// Agent-assisted lodgement
        /// </summary>
        [EnumMember]
        AGENT_ASSISTED
    }
}