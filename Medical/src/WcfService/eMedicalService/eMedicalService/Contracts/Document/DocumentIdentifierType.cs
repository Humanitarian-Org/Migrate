using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.Document.Core.V1
{

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
}