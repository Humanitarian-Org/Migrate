using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
    /// <summary>
    /// Originating departmental officer type for tracking the originating officer
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class OriginatingDepartmentalOfficerType
    {
        /// <summary>
        /// Departmental officer information
        /// </summary>
        [DataMember]
        public DepartmentalOfficerType Officer { get; set; }

        /// <summary>
        /// Date when the officer originated the action
        /// </summary>
        [DataMember]
        public DateTime OriginationDate { get; set; }

        /// <summary>
        /// Action or process originated by the officer
        /// </summary>
        [DataMember]
        public string OriginatedAction { get; set; }

        /// <summary>
        /// Reference number for the origination
        /// </summary>
        [DataMember]
        public string OriginationReference { get; set; }
    }
}