using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Electronic reference file type for file references
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class ElectronicReferenceFileType
    {
        /// <summary>
        /// Reference file identifier
        /// </summary>
        [DataMember]
        public string ReferenceFileId { get; set; }

        /// <summary>
        /// File reference information
        /// </summary>
        [DataMember]
        public BodyContentReferenceType FileReference { get; set; }

        /// <summary>
        /// Reference file metadata
        /// </summary>
        [DataMember]
        public ElectronicFileType FileMetadata { get; set; }
    }
}