using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Enumeration for language test types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public enum LanguageTestTypeType
    {
        /// <summary>
        /// IELTS test
        /// </summary>
        [EnumMember]
        IELTS,

        /// <summary>
        /// TOEFL test
        /// </summary>
        [EnumMember]
        TOEFL,

        /// <summary>
        /// PTE Academic test
        /// </summary>
        [EnumMember]
        PTE_ACADEMIC,

        /// <summary>
        /// Cambridge English test
        /// </summary>
        [EnumMember]
        CAMBRIDGE_ENGLISH
    }
}