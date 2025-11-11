using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Unstructured grant date type for grant date information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class UnstructuredGrantDateType
    {
        /// <summary>
        /// Grant date
        /// </summary>
        [DataMember]
        public DateTime GrantDate { get; set; }

        /// <summary>
        /// Indicates if date is estimated
        /// </summary>
        [DataMember]
        public bool IsEstimated { get; set; }

        /// <summary>
        /// Grant date source
        /// </summary>
        [DataMember]
        public string GrantDateSource { get; set; }
    }
}