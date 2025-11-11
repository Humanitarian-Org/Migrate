using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Messaging
{
    [DataContract(Name = "HealthClinicIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClinicIdentifierMsgType
    {
        [DataMember]
        public string ClinicId { get; set; } = string.Empty;

        [DataMember]
        public string ClinicName { get; set; } = string.Empty;

        [DataMember]
        public string CountryCode { get; set; } = string.Empty;

        [DataMember]
        public string StateCode { get; set; } = string.Empty;

        [DataMember]
        public string CityCode { get; set; } = string.Empty;
    }
}