using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Comparison level type for identity comparison operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class ComparisonLevelType
    {
        /// <summary>
        /// Comparison level identifier
        /// </summary>
        [DataMember]
        public string ComparisonLevel { get; set; }

        /// <summary>
        /// Comparison algorithm used
        /// </summary>
        [DataMember]
        public string ComparisonAlgorithm { get; set; }

        /// <summary>
        /// Comparison threshold
        /// </summary>
        [DataMember]
        public decimal ComparisonThreshold { get; set; }
    }
}