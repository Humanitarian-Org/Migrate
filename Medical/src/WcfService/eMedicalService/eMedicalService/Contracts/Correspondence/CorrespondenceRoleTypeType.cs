using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for correspondence role types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceRoleTypeType
    {
        /// <summary>
        /// Sender role
        /// </summary>
        [EnumMember]
        SENDER,

        /// <summary>
        /// Recipient role
        /// </summary>
        [EnumMember]
        RECIPIENT,

        /// <summary>
        /// Carbon copy role
        /// </summary>
        [EnumMember]
        CC,

        /// <summary>
        /// Blind carbon copy role
        /// </summary>
        [EnumMember]
        BCC,

        /// <summary>
        /// Forwarded role
        /// </summary>
        [EnumMember]
        FORWARDED
    }
}