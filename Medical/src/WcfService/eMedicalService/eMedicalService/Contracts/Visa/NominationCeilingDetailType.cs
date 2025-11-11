using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Nomination ceiling detail type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class NominationCeilingDetailType
    {
        /// <summary>
        /// Ceiling type
        /// </summary>
        [DataMember]
        public string CeilingType { get; set; }

        /// <summary>
        /// Ceiling limit
        /// </summary>
        [DataMember]
        public int CeilingLimit { get; set; }

        /// <summary>
        /// Current count
        /// </summary>
        [DataMember]
        public int CurrentCount { get; set; }

        /// <summary>
        /// Ceiling period
        /// </summary>
        [DataMember]
        public string CeilingPeriod { get; set; }
    }
}