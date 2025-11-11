using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// List of correspondence attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceAttachmentListType
    {
        /// <summary>
        /// Collection of attachments
        /// </summary>
        [DataMember]
        public List<CorrespondenceAttachmentType> Attachment { get; set; } = new List<CorrespondenceAttachmentType>();
    }
}