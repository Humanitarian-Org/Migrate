using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "HealthCaseDetailFormType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class HealthCaseDetailFormType
    {
        [DataMember]
        public string FormData { get; set; } = string.Empty;

        [DataMember]
        public string FormType { get; set; } = string.Empty;

        [DataMember]
        public string FormVersion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FormSubmissionDate { get; set; }

        [DataMember]
        public string FormStatus { get; set; } = string.Empty;
    }
}