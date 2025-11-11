using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
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
}