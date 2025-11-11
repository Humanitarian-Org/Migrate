using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa classification type for visa categorization
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaClassificationType
    {
        /// <summary>
        /// Classification code
        /// </summary>
        [DataMember]
        public string ClassificationCode { get; set; }

        /// <summary>
        /// Classification name
        /// </summary>
        [DataMember]
        public string ClassificationName { get; set; }

        /// <summary>
        /// Classification description
        /// </summary>
        [DataMember]
        public string ClassificationDescription { get; set; }
    }
}