using System;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("RegisterMedicalExaminationsResultsResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsResponseType
    {
        [XmlElement("CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("ResultsRegistrationId")]
        public string ResultsRegistrationId { get; set; } = string.Empty;

        [XmlElement("ProcessedDateTime")]
        public DateTime ProcessedDateTime { get; set; }

        [XmlElement("ResponseCode")]
        public string ResponseCode { get; set; } = string.Empty;

        [XmlElement("ResponseMessage")]
        public string ResponseMessage { get; set; } = string.Empty;

        [XmlElement("Acknowledgement")]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}