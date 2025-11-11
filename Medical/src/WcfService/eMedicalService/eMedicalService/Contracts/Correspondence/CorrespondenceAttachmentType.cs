using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Correspondence attachment type for file attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceAttachmentType
    {
        /// <summary>
        /// Attachment filename
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Attachment binary content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType BinaryContent { get; set; }

        /// <summary>
        /// Attachment description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Document category of the attachment
        /// </summary>
        [DataMember]
        public DocumentCategoryCodeType? AttachmentCategory { get; set; }
    }
}