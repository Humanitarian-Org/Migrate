using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for document category codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum DocumentCategoryCodeType
    {
        /// <summary>
        /// Official letter
        /// </summary>
        [EnumMember]
        LETTER,

        /// <summary>
        /// Notice document
        /// </summary>
        [EnumMember]
        NOTICE,

        /// <summary>
        /// Report document
        /// </summary>
        [EnumMember]
        REPORT,

        /// <summary>
        /// Certificate document
        /// </summary>
        [EnumMember]
        CERTIFICATE,

        /// <summary>
        /// Attachment document
        /// </summary>
        [EnumMember]
        ATTACHMENT
    }
}