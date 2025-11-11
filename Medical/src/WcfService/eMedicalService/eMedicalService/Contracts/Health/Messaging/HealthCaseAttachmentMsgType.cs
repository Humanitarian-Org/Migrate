using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthCaseAttachmentMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseAttachmentMsgType
    {
        [DataMember]
        public string AttachmentId { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentType { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentName { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentData { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentMimeType { get; set; } = string.Empty;

        [DataMember]
        public long AttachmentSize { get; set; }

        [DataMember]
        public DateTime AttachmentCreatedDate { get; set; }
    }
}