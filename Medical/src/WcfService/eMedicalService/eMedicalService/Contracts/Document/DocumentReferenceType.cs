using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
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
}