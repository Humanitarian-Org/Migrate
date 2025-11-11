using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business service classifier type for service categorization
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceClassifierType
    {
        /// <summary>
        /// Classification code for the service
        /// </summary>
        [DataMember]
        public string ServiceClassificationCode { get; set; }

        /// <summary>
        /// Classification type for the service
        /// </summary>
        [DataMember]
        public string ServiceClassificationType { get; set; }

        /// <summary>
        /// Description of the service classification
        /// </summary>
        [DataMember]
        public string ServiceClassificationDescription { get; set; }
    }
}