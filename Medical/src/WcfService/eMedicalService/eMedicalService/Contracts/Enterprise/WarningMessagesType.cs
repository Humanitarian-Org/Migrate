using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "WarningMessagesType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningMessagesType
    {
        [DataMember]
        public WarningMessageType[] Warning { get; set; }
    }
}