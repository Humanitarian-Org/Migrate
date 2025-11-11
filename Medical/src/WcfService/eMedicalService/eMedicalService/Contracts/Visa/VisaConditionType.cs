using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa condition type for visa conditions
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaConditionType
    {
        /// <summary>
        /// Condition code
        /// </summary>
        [DataMember]
        public string ConditionCode { get; set; }

        /// <summary>
        /// Condition description
        /// </summary>
        [DataMember]
        public string ConditionDescription { get; set; }

        /// <summary>
        /// Whether condition is mandatory
        /// </summary>
        [DataMember]
        public bool IsMandatory { get; set; }

        /// <summary>
        /// Condition effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Condition expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }
    }
}