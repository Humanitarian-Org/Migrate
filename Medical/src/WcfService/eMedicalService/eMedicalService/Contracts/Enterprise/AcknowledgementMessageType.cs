using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [XmlType(TypeName = "AcknowledgementMessage", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class AcknowledgementMessageType
    {
        [XmlElement("CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [XmlElement("AcknowledgementCode")]
        public string AcknowledgementCode { get; set; } = string.Empty;

        [XmlElement("AcknowledgementText")]
        public string AcknowledgementText { get; set; } = string.Empty;

        [XmlElement("ProcessedDateTime")]
        public DateTime ProcessedDateTime { get; set; }
    }
}