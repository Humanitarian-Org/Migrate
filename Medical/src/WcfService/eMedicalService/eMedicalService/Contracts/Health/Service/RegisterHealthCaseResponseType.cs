using System.Runtime.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public string HealthCaseId { get; set; } = string.Empty;

        [DataMember(Order = 2)]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}