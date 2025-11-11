using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Correspondence header type for correspondence metadata
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceHeaderType
    {
        /// <summary>
        /// Correspondence unique identifier
        /// </summary>
        [DataMember]
        public string CorrespondenceId { get; set; }

        /// <summary>
        /// Subject line of the correspondence
        /// </summary>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Correspondence status
        /// </summary>
        [DataMember]
        public CorrespondenceStatusCodeType Status { get; set; }

        /// <summary>
        /// Correspondence category
        /// </summary>
        [DataMember]
        public CorrespondenceCategoryTypeType Category { get; set; }

        /// <summary>
        /// Document category
        /// </summary>
        [DataMember]
        public DocumentCategoryCodeType DocumentCategory { get; set; }

        /// <summary>
        /// Creation timestamp
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Last modification timestamp
        /// </summary>
        [DataMember]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Sent timestamp
        /// </summary>
        [DataMember]
        public DateTime? SentDate { get; set; }

        /// <summary>
        /// Registration details
        /// </summary>
        [DataMember]
        public RegistrationDateType Registration { get; set; }

        /// <summary>
        /// Priority level
        /// </summary>
        [DataMember]
        public string Priority { get; set; }

        /// <summary>
        /// Reference to parent correspondence
        /// </summary>
        [DataMember]
        public string ParentCorrespondenceId { get; set; }
    }
}