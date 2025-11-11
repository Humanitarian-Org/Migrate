using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa application skills assessment type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaApplicationSkillsAssessmentType
    {
        /// <summary>
        /// Assessment authority
        /// </summary>
        [DataMember]
        public string AssessmentAuthority { get; set; }

        /// <summary>
        /// Assessment outcome
        /// </summary>
        [DataMember]
        public string AssessmentOutcome { get; set; }

        /// <summary>
        /// Assessment date
        /// </summary>
        [DataMember]
        public DateTime AssessmentDate { get; set; }

        /// <summary>
        /// Skills assessed
        /// </summary>
        [DataMember]
        public string SkillsAssessed { get; set; }
    }
}