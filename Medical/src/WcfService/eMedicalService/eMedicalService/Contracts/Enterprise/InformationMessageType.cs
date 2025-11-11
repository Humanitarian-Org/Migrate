using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "InformationMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationMessageType
    {
        [DataMember]
        public string Code { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; }
    }
}