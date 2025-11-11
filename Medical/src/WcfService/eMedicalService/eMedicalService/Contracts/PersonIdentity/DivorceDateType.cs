using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Divorce date type for marital status information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class DivorceDateType
    {
        /// <summary>
        /// Date of divorce
        /// </summary>
        [DataMember]
        public DateTime DivorceDate { get; set; }

        /// <summary>
        /// Jurisdiction of divorce
        /// </summary>
        [DataMember]
        public string DivorceJurisdiction { get; set; }

        /// <summary>
        /// Divorce certificate number
        /// </summary>
        [DataMember]
        public string DivorceCertificateNumber { get; set; }
    }
}