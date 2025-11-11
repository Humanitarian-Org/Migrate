using System.Runtime.Serialization;

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
}