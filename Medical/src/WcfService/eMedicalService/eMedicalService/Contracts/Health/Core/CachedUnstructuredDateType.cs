using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Core
{
    [DataContract(Name = "CachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string TimeZone { get; set; } = string.Empty;
    }
}