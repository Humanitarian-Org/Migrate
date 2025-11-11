using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Body content binary type for information record content
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class BodyContentBinaryType
    {
        /// <summary>
        /// Binary content data
        /// </summary>
        [DataMember]
        public byte[] ContentData { get; set; }

        /// <summary>
        /// Content MIME type
        /// </summary>
        [DataMember]
        public string ContentMimeType { get; set; }

        /// <summary>
        /// Content encoding
        /// </summary>
        [DataMember]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Content size in bytes
        /// </summary>
        [DataMember]
        public long ContentSize { get; set; }
    }
}