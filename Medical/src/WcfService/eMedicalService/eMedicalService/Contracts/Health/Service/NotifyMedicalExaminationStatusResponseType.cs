using System.Runtime.Serialization;
using eMedicalService.Contracts.Enterprise;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "NotifyMedicalExaminationStatusResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public AcknowledgementMessage Acknowledgement { get; set; }
    }
}