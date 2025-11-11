using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// List of document attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentAttachmentListType
    {
        /// <summary>
        /// Collection of document attachments
        /// </summary>
        [DataMember]
        public List<DocumentAttachmentType> DocumentAttachment { get; set; } = new List<DocumentAttachmentType>();
    }
}