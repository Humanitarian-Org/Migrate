using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "DeleteCachedHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseRequestType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public string CaseId { get; set; } = string.Empty;
    }
}