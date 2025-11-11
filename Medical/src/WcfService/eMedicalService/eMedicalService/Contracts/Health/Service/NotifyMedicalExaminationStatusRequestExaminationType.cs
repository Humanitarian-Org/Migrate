using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "NotifyMedicalExaminationStatusRequestExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestExaminationType
    {
        [DataMember]
        public string ExaminationCode { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationDescription { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationStatus { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExaminationDate { get; set; }

        [DataMember]
        public string ExaminationResult { get; set; } = string.Empty;

        [DataMember]
        public string Comments { get; set; } = string.Empty;
    }
}