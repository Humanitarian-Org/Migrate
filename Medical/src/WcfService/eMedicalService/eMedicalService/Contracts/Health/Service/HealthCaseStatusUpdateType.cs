using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "HealthCaseStatusUpdateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class HealthCaseStatusUpdateType
    {
        [DataMember]
        public string Status { get; set; } = string.Empty;

        [DataMember]
        public DateTime StatusTimestamp { get; set; }

        [DataMember]
        public bool StatusTimestampSpecified { get; set; }
    }
}