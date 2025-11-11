using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "WarningMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningMessageType
    {
        [DataMember]
        public string Code { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; }
    }
}