using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Document attachment type for file attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentAttachmentType
    {
        /// <summary>
        /// Filename of the attachment
        /// </summary>
        [DataMember]
        public string AttachmentFileName { get; set; }

        /// <summary>
        /// MIME type of the attachment
        /// </summary>
        [DataMember]
        public string AttachmentMimeType { get; set; }

        /// <summary>
        /// Base64 encoded content of the attachment
        /// </summary>
        [DataMember]
        public byte[] AttachmentContent { get; set; }

        /// <summary>
        /// Size of the attachment in bytes
        /// </summary>
        [DataMember]
        public long? AttachmentSize { get; set; }

        /// <summary>
        /// Repository source where the document is stored
        /// </summary>
        [DataMember]
        public DocumentRepositorySourceType? RepositorySource { get; set; }
    }
}