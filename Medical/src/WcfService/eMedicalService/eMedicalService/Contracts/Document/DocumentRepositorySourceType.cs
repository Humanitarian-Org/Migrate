using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Enumeration for document repository source systems
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public enum DocumentRepositorySourceType
    {
        /// <summary>
        /// Lotus Notes mailbox repository
        /// </summary>
        [EnumMember]
        LOTUS_NOTES_MAILBOX,

        /// <summary>
        /// Group folder repository
        /// </summary>
        [EnumMember]
        GROUP_FOLDER,

        /// <summary>
        /// TRIM document management system
        /// </summary>
        [EnumMember]
        TRIM
    }
}