using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Electronic file type for electronic documents
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class ElectronicFileType
    {
        /// <summary>
        /// File identifier
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// File type or extension
        /// </summary>
        [DataMember]
        public string FileType { get; set; }

        /// <summary>
        /// File binary content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType FileContent { get; set; }

        /// <summary>
        /// File creation date
        /// </summary>
        [DataMember]
        public DateTime FileCreationDate { get; set; }

        /// <summary>
        /// File last modified date
        /// </summary>
        [DataMember]
        public DateTime? FileModifiedDate { get; set; }
    }
}