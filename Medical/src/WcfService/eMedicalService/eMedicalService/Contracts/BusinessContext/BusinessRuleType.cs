using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business rule type for business rule management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessRuleType
    {
        /// <summary>
        /// Unique rule identifier
        /// </summary>
        [DataMember]
        public string RuleId { get; set; }

        /// <summary>
        /// Rule name or title
        /// </summary>
        [DataMember]
        public string RuleName { get; set; }

        /// <summary>
        /// Rule description
        /// </summary>
        [DataMember]
        public string RuleDescription { get; set; }

        /// <summary>
        /// Rule category or type
        /// </summary>
        [DataMember]
        public string RuleCategory { get; set; }

        /// <summary>
        /// Rule execution priority
        /// </summary>
        [DataMember]
        public int? RulePriority { get; set; }

        /// <summary>
        /// Rule active status
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Rule effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Rule expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Business context where the rule applies
        /// </summary>
        [DataMember]
        public BusinessContextType ApplicableContext { get; set; }
    }
}