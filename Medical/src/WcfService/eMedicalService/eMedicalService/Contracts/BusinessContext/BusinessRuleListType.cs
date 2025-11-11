using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// List of business rules
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessRuleListType
    {
        /// <summary>
        /// Collection of business rules
        /// </summary>
        [DataMember]
        public List<BusinessRuleType> BusinessRule { get; set; } = new List<BusinessRuleType>();
    }
}