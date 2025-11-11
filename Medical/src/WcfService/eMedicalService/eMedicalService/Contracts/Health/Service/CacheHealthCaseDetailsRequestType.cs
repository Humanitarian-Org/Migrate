using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "CacheHealthCaseDetailsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class CacheHealthCaseDetailsRequestType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public RegisterHealthCaseRequestType HealthCase { get; set; }
    }
}