using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestIdentityDocumentType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestIdentityDocumentType
    {
        [DataMember]
        public string DocumentType { get; set; } = string.Empty;

        [DataMember]
        public string DocumentNumber { get; set; } = string.Empty;

        [DataMember]
        public string IssuingCountry { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [DataMember]
        public DateTime IssueDate { get; set; }

        [DataMember]
        public string DocumentImageData { get; set; } = string.Empty;
    }
}