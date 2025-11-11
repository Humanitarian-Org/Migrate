using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// List of business service identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdentifierListType
    {
        /// <summary>
        /// Collection of business service identifiers
        /// </summary>
        [DataMember]
        public List<BusinessServiceIdentifierType> BusinessServiceIdentifier { get; set; } = new List<BusinessServiceIdentifierType>();
    }
}