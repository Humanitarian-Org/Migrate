using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
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