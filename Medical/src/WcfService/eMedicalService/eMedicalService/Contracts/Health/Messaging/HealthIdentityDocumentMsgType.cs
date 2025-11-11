using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthIdentityDocumentMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthIdentityDocumentMsgType
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
    }
}