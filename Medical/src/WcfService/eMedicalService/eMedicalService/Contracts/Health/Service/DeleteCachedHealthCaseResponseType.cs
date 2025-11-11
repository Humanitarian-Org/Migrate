using System.Runtime.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "DeleteCachedHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseResponseType
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}