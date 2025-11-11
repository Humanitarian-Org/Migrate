using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Medical examination status enumeration
    /// </summary>
    [DataContract(Name = "medicalExaminationStatus", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public enum MedicalExaminationStatus
    {
        [EnumMember]
        NOT_STARTED,
        [EnumMember]
        IN_PROGRESS,
        [EnumMember]
        COMPLETED,
        [EnumMember]
        CANCELLED,
        [EnumMember]
        REFERRED,
        [EnumMember]
        FAILED
    }
}