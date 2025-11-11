using System.Runtime.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "GetHealthCaseStatusResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class GetHealthCaseStatusResponseType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public HealthCaseStatusUpdateType Status { get; set; }

        [DataMember]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}