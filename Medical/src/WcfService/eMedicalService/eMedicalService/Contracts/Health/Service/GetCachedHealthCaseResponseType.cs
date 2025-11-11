using System.Runtime.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "GetCachedHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class GetCachedHealthCaseResponseType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public RegisterHealthCaseRequestType HealthCase { get; set; }

        [DataMember]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}