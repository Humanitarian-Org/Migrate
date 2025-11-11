using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "GetHealthCaseStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class GetHealthCaseStatusRequestType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public string CaseId { get; set; } = string.Empty;
    }
}