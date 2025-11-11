using System;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlRoot("RegisterHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseResponseType
    {
        [XmlElement("CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("HealthCaseRegistrationId")]
        public string HealthCaseRegistrationId { get; set; } = string.Empty;

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