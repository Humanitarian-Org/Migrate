using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
    /// <summary>
    /// Last actioned by departmental officer type for tracking the last officer to act
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class LastActionedByDepartmentalOfficerType
    {
        /// <summary>
        /// Departmental officer information
        /// </summary>
        [DataMember]
        public DepartmentalOfficerType Officer { get; set; }

        /// <summary>
        /// Date of the last action
        /// </summary>
        [DataMember]
        public DateTime LastActionDate { get; set; }

        /// <summary>
        /// Type of last action performed
        /// </summary>
        [DataMember]
        public string LastActionType { get; set; }

        /// <summary>
        /// Description of the last action
        /// </summary>
        [DataMember]
        public string LastActionDescription { get; set; }

        /// <summary>
        /// Reference number for the last action
        /// </summary>
        [DataMember]
        public string LastActionReference { get; set; }
    }
}