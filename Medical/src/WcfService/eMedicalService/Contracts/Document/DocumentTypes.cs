using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Enumeration for search document MIME types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public enum SearchDocumentTypeType
    {
        /// <summary>
        /// PDF document type
        /// </summary>
        [EnumMember]
        APPLICATION_PDF,

        /// <summary>
        /// Microsoft Excel document type
        /// </summary>
        [EnumMember]
        APPLICATION_VND_MS_EXCEL,

        /// <summary>
        /// Microsoft Word document type
        /// </summary>
        [EnumMember]
        APPLICATION_MSWORD
    }

    /// <summary>
    /// Enumeration for document repository source systems
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public enum DocumentRepositorySourceType
    {
        /// <summary>
        /// Lotus Notes mailbox repository
        /// </summary>
        [EnumMember]
        LOTUS_NOTES_MAILBOX,

        /// <summary>
        /// Group folder repository
        /// </summary>
        [EnumMember]
        GROUP_FOLDER,

        /// <summary>
        /// TRIM document management system
        /// </summary>
        [EnumMember]
        TRIM
    }

    /// <summary>
    /// Document reference type for document identification and classification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentReferenceType
    {
        /// <summary>
        /// The actual reference value for the document
        /// </summary>
        [DataMember]
        public string DocumentReferenceValue { get; set; }

        /// <summary>
        /// The type classification of the document reference
        /// </summary>
        [DataMember]
        public string DocumentReferenceType_Value { get; set; }
    }

    /// <summary>
    /// Issuing country type for document issuance information
    /// Uses Enterprise Core namespace for country codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class IssuingCountryType
    {
        /// <summary>
        /// Country code for the issuing country
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Type of country code used (e.g., ISO, ICAO)
        /// </summary>
        [DataMember]
        public string CountryCodeType { get; set; }
    }

    /// <summary>
    /// Context container for document organization and classification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class ContextContainerType
    {
        /// <summary>
        /// Unique identifier number for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerNumber { get; set; }

        /// <summary>
        /// Type classification of the context container
        /// </summary>
        [DataMember]
        public string ContextContainerType_Value { get; set; }

        /// <summary>
        /// Optional title for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerTitle { get; set; }

        /// <summary>
        /// Optional description for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerDescription { get; set; }

        /// <summary>
        /// Date and time when the container becomes effective
        /// </summary>
        [DataMember]
        public DateTime EffectiveFromDateTime { get; set; }

        /// <summary>
        /// Optional date and time when the container expires
        /// </summary>
        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }

    /// <summary>
    /// List container for multiple context containers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class ContextContainerListType
    {
        /// <summary>
        /// Collection of context containers
        /// </summary>
        [DataMember]
        public List<ContextContainerType> ContextContainer { get; set; } = new List<ContextContainerType>();
    }

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

    /// <summary>
    /// Document identifier type for unique document identification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentIdentifierType
    {
        /// <summary>
        /// Unique document identifier value
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }

        /// <summary>
        /// Type of document identifier (e.g., UUID, system-specific ID)
        /// </summary>
        [DataMember]
        public string DocumentIdType { get; set; }

        /// <summary>
        /// System or source that generated the identifier
        /// </summary>
        [DataMember]
        public string IdentifierSource { get; set; }
    }

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

    /// <summary>
    /// Document search criteria type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentSearchCriteriaType
    {
        /// <summary>
        /// Document identifier to search for
        /// </summary>
        [DataMember]
        public DocumentIdentifierType DocumentIdentifier { get; set; }

        /// <summary>
        /// Document reference to search for
        /// </summary>
        [DataMember]
        public DocumentReferenceType DocumentReference { get; set; }

        /// <summary>
        /// Search by document type
        /// </summary>
        [DataMember]
        public SearchDocumentTypeType? SearchDocumentType { get; set; }

        /// <summary>
        /// Search by repository source
        /// </summary>
        [DataMember]
        public DocumentRepositorySourceType? RepositorySource { get; set; }

        /// <summary>
        /// Search by issuing country
        /// </summary>
        [DataMember]
        public IssuingCountryType IssuingCountry { get; set; }

        /// <summary>
        /// Date range for document creation
        /// </summary>
        [DataMember]
        public DateTime? CreationDateFrom { get; set; }

        /// <summary>
        /// Date range for document creation
        /// </summary>
        [DataMember]
        public DateTime? CreationDateTo { get; set; }
    }

    /// <summary>
    /// Document search results type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class DocumentSearchResultsType
    {
        /// <summary>
        /// Collection of documents found in search
        /// </summary>
        [DataMember]
        public List<DocumentType> Documents { get; set; } = new List<DocumentType>();

        /// <summary>
        /// Total number of documents found
        /// </summary>
        [DataMember]
        public int TotalResults { get; set; }

        /// <summary>
        /// Number of results returned in this response
        /// </summary>
        [DataMember]
        public int ReturnedResults { get; set; }

        /// <summary>
        /// Indicates if there are more results available
        /// </summary>
        [DataMember]
        public bool HasMoreResults { get; set; }
    }
}