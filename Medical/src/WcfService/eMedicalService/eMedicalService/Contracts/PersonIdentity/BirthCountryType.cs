using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Birth country type for person birth location
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BirthCountryType
    {
        /// <summary>
        /// Country code
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [DataMember]
        public string CountryName { get; set; }

        /// <summary>
        /// Birth place within the country
        /// </summary>
        [DataMember]
        public string BirthPlace { get; set; }
    }
}