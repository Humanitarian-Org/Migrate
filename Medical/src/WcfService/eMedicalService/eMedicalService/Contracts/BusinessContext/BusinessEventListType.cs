using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// List of business events
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessEventListType
    {
        /// <summary>
        /// Collection of business events
        /// </summary>
        [DataMember]
        public List<BusinessEventType> BusinessEvent { get; set; } = new List<BusinessEventType>();
    }
}