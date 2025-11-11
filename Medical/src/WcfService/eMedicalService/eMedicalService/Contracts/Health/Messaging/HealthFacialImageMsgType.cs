using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthFacialImageMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthFacialImageMsgType
    {
        [DataMember]
        public string ImageData { get; set; } = string.Empty;

        [DataMember]
        public string ImageFormat { get; set; } = string.Empty;

        [DataMember]
        public DateTime ImageCaptureDate { get; set; }

        [DataMember]
        public string ImageQuality { get; set; } = string.Empty;

        [DataMember]
        public int ImageWidth { get; set; }

        [DataMember]
        public int ImageHeight { get; set; }
    }
}