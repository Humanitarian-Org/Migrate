using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Issuing country type for document issuance information
    /// Uses Enterprise Core namespace for country codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class IssuingCountryType
    {
        /// <summary>
        /// Country code for the issuing country
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Type of country code used (e.g., ISO, ICAO)
        /// </summary>
        [DataMember]
        public string CountryCodeType { get; set; }
    }
}