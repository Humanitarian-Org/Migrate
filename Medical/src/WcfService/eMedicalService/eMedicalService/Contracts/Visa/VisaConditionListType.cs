using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// List of visa conditions
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaConditionListType
    {
        /// <summary>
        /// Collection of visa conditions
        /// </summary>
        [DataMember]
        public List<VisaConditionType> VisaCondition { get; set; } = new List<VisaConditionType>();
    }
}