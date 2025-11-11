using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Core;

namespace eMedicalService.Contracts.Health.Messaging
{
    [XmlType(TypeName = "HealthIdentityDocumentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthIdentityDocumentMsgType
    {
        [XmlElement("DocumentTypeCode", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentTypeCode { get; set; } = string.Empty;

        [XmlElement("DocumentNumber", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentNumber { get; set; } = string.Empty;

        [XmlElement("IssuingCountryName", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string IssuingCountryName { get; set; } = string.Empty;

        [XmlElement("CachedIssueDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedIssueDate { get; set; }

        [XmlElement("CachedExpiryDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedExpiryDate { get; set; }
    }
}