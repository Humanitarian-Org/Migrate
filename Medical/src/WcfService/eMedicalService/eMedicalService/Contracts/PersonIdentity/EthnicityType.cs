using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Ethnicity type for person ethnicity information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class EthnicityType
    {
        /// <summary>
        /// Ethnicity code
        /// </summary>
        [DataMember]
        public string EthnicityCode { get; set; }

        /// <summary>
        /// Ethnicity description
        /// </summary>
        [DataMember]
        public string EthnicityDescription { get; set; }

        /// <summary>
        /// Primary ethnicity indicator
        /// </summary>
        [DataMember]
        public bool IsPrimary { get; set; }
    }
}