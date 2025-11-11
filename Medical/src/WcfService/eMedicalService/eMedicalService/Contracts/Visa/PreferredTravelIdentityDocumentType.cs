using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Preferred travel identity document type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class PreferredTravelIdentityDocumentType
    {
        /// <summary>
        /// Document number
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Document type
        /// </summary>
        [DataMember]
        public string DocumentType { get; set; }

        /// <summary>
        /// Issuing country
        /// </summary>
        [DataMember]
        public string IssuingCountry { get; set; }

        /// <summary>
        /// Document issue date
        /// </summary>
        [DataMember]
        public UnstructuredIssueDateType IssueDate { get; set; }

        /// <summary>
        /// Document expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }
    }
}