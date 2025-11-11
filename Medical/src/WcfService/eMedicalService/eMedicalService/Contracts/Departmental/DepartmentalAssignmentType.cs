using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
    /// <summary>
    /// Departmental assignment type for officer assignments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalAssignmentType
    {
        /// <summary>
        /// Assigned officer
        /// </summary>
        [DataMember]
        public DepartmentalOfficerType AssignedOfficer { get; set; }

        /// <summary>
        /// Assigned role
        /// </summary>
        [DataMember]
        public DepartmentalRoleType AssignedRole { get; set; }

        /// <summary>
        /// Assigned unit
        /// </summary>
        [DataMember]
        public DepartmentalUnitType AssignedUnit { get; set; }

        /// <summary>
        /// Assignment start date
        /// </summary>
        [DataMember]
        public DateTime AssignmentStartDate { get; set; }

        /// <summary>
        /// Assignment end date
        /// </summary>
        [DataMember]
        public DateTime? AssignmentEndDate { get; set; }

        /// <summary>
        /// Assignment status
        /// </summary>
        [DataMember]
        public string AssignmentStatus { get; set; }

        /// <summary>
        /// Assignment reference
        /// </summary>
        [DataMember]
        public string AssignmentReference { get; set; }
    }
}