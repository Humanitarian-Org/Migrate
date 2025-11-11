using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Registration date type for correspondence registration
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class RegistrationDateType
    {
        /// <summary>
        /// Date of registration
        /// </summary>
        [DataMember]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Registration authority or system
        /// </summary>
        [DataMember]
        public string RegistrationAuthority { get; set; }

        /// <summary>
        /// Registration reference number
        /// </summary>
        [DataMember]
        public string RegistrationReference { get; set; }
    }
}