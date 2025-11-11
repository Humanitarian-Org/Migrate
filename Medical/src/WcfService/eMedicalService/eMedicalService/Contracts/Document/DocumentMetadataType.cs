using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Document metadata type for document information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentMetadataType
    {
        /// <summary>
        /// Document title or name
        /// </summary>
        [DataMember]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// Document description
        /// </summary>
        [DataMember]
        public string DocumentDescription { get; set; }

        /// <summary>
        /// Document author or creator
        /// </summary>
        [DataMember]
        public string DocumentAuthor { get; set; }

        /// <summary>
        /// Document creation date
        /// </summary>
        [DataMember]
        public DateTime? DocumentCreationDate { get; set; }

        /// <summary>
        /// Document modification date
        /// </summary>
        [DataMember]
        public DateTime? DocumentModificationDate { get; set; }

        /// <summary>
        /// Document version information
        /// </summary>
        [DataMember]
        public string DocumentVersion { get; set; }

        /// <summary>
        /// Document security classification
        /// </summary>
        [DataMember]
        public string SecurityClassification { get; set; }
    }
}