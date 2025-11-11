using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business service identifier type for service identification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdentifierType
    {
        /// <summary>
        /// Value of the business service identifier
        /// </summary>
        [DataMember]
        public string BusinessServiceIdValue { get; set; }

        /// <summary>
        /// Type of the business service identifier
        /// </summary>
        [DataMember]
        public string BusinessServiceIdType { get; set; }
    }
}