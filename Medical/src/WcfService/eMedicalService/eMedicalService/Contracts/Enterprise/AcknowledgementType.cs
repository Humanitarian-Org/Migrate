using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "AcknowledgementType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public enum AcknowledgementType
    {
        [EnumMember]
        SUCCESS,
        [EnumMember]
        ERROR,
        [EnumMember]
        WARNING
    }
}