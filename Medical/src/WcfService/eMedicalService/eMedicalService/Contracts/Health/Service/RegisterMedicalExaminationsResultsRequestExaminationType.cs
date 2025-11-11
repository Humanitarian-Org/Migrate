using System;
using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestExaminationType
    {
        [DataMember]
        public string ExaminationCode { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationType { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExaminationDate { get; set; }

        [DataMember]
        public string ExaminationResult { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationStatus { get; set; } = string.Empty;

        [DataMember]
        public string DoctorName { get; set; } = string.Empty;

        [DataMember]
        public string ClinicName { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationNotes { get; set; } = string.Empty;

        [DataMember]
        public HealthCaseAttachmentMsgType[] ExaminationAttachments { get; set; }
    }
}