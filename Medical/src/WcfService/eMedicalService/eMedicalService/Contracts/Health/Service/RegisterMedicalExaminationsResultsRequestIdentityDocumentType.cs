using System;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("RegisterMedicalExaminationsResultsRequestIdentityDocumentType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestIdentityDocumentType
    {
        [XmlElement("DocumentType")]
        public string DocumentType { get; set; } = string.Empty;

        [XmlElement("DocumentTypeCode")]
        public string DocumentTypeCode { get; set; } = string.Empty;

        [XmlElement("DocumentNumber")]
        public string DocumentNumber { get; set; } = string.Empty;

        [XmlElement("IssuingCountry")]
        public string IssuingCountry { get; set; } = string.Empty;

        [XmlElement("IssuingCountryName")]
        public string IssuingCountryName { get; set; } = string.Empty;

        [XmlElement("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [XmlElement("IssueDate")]
        public DateTime IssueDate { get; set; }

        [XmlElement("DocumentImageData")]
        public string DocumentImageData { get; set; } = string.Empty;
    }
}