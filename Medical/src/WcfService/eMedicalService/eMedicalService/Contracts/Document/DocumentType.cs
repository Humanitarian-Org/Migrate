using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Complete document type combining all document components
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentType
    {
        /// <summary>
        /// Document identifier information
        /// </summary>
        [DataMember]
        public DocumentIdentifierType DocumentIdentifier { get; set; }

        /// <summary>
        /// Document reference information
        /// </summary>
        [DataMember]
        public DocumentReferenceType DocumentReference { get; set; }

        /// <summary>
        /// Document metadata information
        /// </summary>
        [DataMember]
        public DocumentMetadataType DocumentMetadata { get; set; }

        /// <summary>
        /// Issuing country for the document
        /// </summary>
        [DataMember]
        public IssuingCountryType IssuingCountry { get; set; }

        /// <summary>
        /// Context containers associated with the document
        /// </summary>
        [DataMember]
        public ContextContainerListType ContextContainers { get; set; }

        /// <summary>
        /// Document attachments
        /// </summary>
        [DataMember]
        public DocumentAttachmentListType Attachments { get; set; }

        /// <summary>
        /// Document search type classification
        /// </summary>
        [DataMember]
        public SearchDocumentTypeType? SearchDocumentType { get; set; }

        /// <summary>
        /// Repository source where document is stored
        /// </summary>
        [DataMember]
        public DocumentRepositorySourceType? RepositorySource { get; set; }
    }
}