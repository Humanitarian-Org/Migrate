using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "InformationMessagesType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationMessagesType
    {
        [DataMember]
        public InformationMessageType[] Information { get; set; }
    }
}