using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Core;
using eMedicalService.Contracts.Health.Messaging;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 2, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 3)]
        public HealthClinicIdentifierMsgType HealthClinicIdentifierMsg { get; set; }

        [DataMember(Order = 4)]
        public RegisterHealthCaseClientBiographicalDetailsType RegisterHealthCaseClientBiographicalDetails { get; set; }
    }
}