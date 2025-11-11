using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// List of business service IDs
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdListType
    {
        /// <summary>
        /// Collection of business service IDs
        /// </summary>
        [DataMember]
        public List<BusinessServiceIdType> BusinessServiceId { get; set; } = new List<BusinessServiceIdType>();
    }
}