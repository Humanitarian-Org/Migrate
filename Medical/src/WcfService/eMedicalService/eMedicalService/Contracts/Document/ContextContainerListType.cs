using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// List container for multiple context containers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class ContextContainerListType
    {
        /// <summary>
        /// Collection of context containers
        /// </summary>
        [DataMember]
        public List<ContextContainerType> ContextContainer { get; set; } = new List<ContextContainerType>();
    }
}