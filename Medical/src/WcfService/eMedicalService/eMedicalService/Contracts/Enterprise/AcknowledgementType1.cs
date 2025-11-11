using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise.Core.V1
{
    /// <summary>
    /// Acknowledgement type enumeration
    /// </summary>
    [DataContract(Name = "acknowledgementType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public enum AcknowledgementType
    {
        [EnumMember]
        SUCCESS
    }
}