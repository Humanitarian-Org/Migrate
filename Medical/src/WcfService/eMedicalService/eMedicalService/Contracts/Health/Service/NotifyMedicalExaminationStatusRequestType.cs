using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Core;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2)]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 3, Name = "HealthCaseStatusUpdate")]
        public HealthCaseStatusUpdateType HealthCaseStatusUpdate { get; set; }

        [DataMember(Order = 4)]
        public NotifyMedicalExaminationStatusRequestHealthRequirementType[] HealthRequirements { get; set; }

        [DataMember(Order = 5)]
        public NotifyMedicalStatusRequestHealthClientContextType ClientContext { get; set; }
    }
}