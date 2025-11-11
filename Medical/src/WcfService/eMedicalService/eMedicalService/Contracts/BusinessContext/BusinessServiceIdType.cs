using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business service ID type for service management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdType
    {
        /// <summary>
        /// Business service identifier details
        /// </summary>
        [DataMember]
        public BusinessServiceIdentifierType BusinessServiceIdentifier { get; set; }

        /// <summary>
        /// Service activation status
        /// </summary>
        [DataMember]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Service effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }
    }
}