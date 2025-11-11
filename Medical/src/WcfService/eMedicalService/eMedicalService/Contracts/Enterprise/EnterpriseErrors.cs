using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "EnterpriseErrors", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class EnterpriseErrors
    {
        [DataMember]
        public string ErrorCode { get; set; } = string.Empty;

        [DataMember]
        public string ErrorMessage { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}