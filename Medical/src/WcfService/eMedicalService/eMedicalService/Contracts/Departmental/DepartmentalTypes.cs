using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
    /// <summary>
    /// Departmental officer type for officer identification and management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalOfficerType
    {
        /// <summary>
        /// Given name of the departmental officer
        /// </summary>
        [DataMember]
        public string GivenName { get; set; }

        /// <summary>
        /// Family name of the departmental officer
        /// </summary>
        [DataMember]
        public string FamilyName { get; set; }

        /// <summary>
        /// Unique departmental officer identifier
        /// </summary>
        [DataMember]
        public string DepartmentalOfficerId { get; set; }

        /// <summary>
        /// Officer position or title
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Department or unit the officer belongs to
        /// </summary>
        [DataMember]
        public string Department { get; set; }

        /// <summary>
        /// Officer's contact email
        /// </summary>
        [DataMember]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Officer's contact phone
        /// </summary>
        [DataMember]
        public string ContactPhone { get; set; }
    }

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

    /// <summary>
    /// Departmental organizational unit type for department structure
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalUnitType
    {
        /// <summary>
        /// Unit identifier
        /// </summary>
        [DataMember]
        public string UnitId { get; set; }

        /// <summary>
        /// Unit name
        /// </summary>
        [DataMember]
        public string UnitName { get; set; }

        /// <summary>
        /// Unit type or category
        /// </summary>
        [DataMember]
        public string UnitType { get; set; }

        /// <summary>
        /// Parent unit identifier
        /// </summary>
        [DataMember]
        public string ParentUnitId { get; set; }

        /// <summary>
        /// Unit manager or supervisor
        /// </summary>
        [DataMember]
        public DepartmentalOfficerType UnitManager { get; set; }

        /// <summary>
        /// Unit location
        /// </summary>
        [DataMember]
        public string UnitLocation { get; set; }
    }

    /// <summary>
    /// Departmental role type for role management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalRoleType
    {
        /// <summary>
        /// Role identifier
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        [DataMember]
        public string RoleName { get; set; }

        /// <summary>
        /// Role description
        /// </summary>
        [DataMember]
        public string RoleDescription { get; set; }

        /// <summary>
        /// Role permissions or authorities
        /// </summary>
        [DataMember]
        public List<string> Permissions { get; set; } = new List<string>();

        /// <summary>
        /// Role level or hierarchy
        /// </summary>
        [DataMember]
        public int? RoleLevel { get; set; }
    }

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

    /// <summary>
    /// List of departmental assignments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalAssignmentListType
    {
        /// <summary>
        /// Collection of departmental assignments
        /// </summary>
        [DataMember]
        public List<DepartmentalAssignmentType> Assignment { get; set; } = new List<DepartmentalAssignmentType>();
    }

    /// <summary>
    /// Departmental process type for process management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalProcessType
    {
        /// <summary>
        /// Process identifier
        /// </summary>
        [DataMember]
        public string ProcessId { get; set; }

        /// <summary>
        /// Process name
        /// </summary>
        [DataMember]
        public string ProcessName { get; set; }

        /// <summary>
        /// Process description
        /// </summary>
        [DataMember]
        public string ProcessDescription { get; set; }

        /// <summary>
        /// Originating officer
        /// </summary>
        [DataMember]
        public OriginatingDepartmentalOfficerType OriginatingOfficer { get; set; }

        /// <summary>
        /// Last actioned officer
        /// </summary>
        [DataMember]
        public LastActionedByDepartmentalOfficerType LastActionedOfficer { get; set; }

        /// <summary>
        /// Current assignments
        /// </summary>
        [DataMember]
        public DepartmentalAssignmentListType CurrentAssignments { get; set; }

        /// <summary>
        /// Process status
        /// </summary>
        [DataMember]
        public string ProcessStatus { get; set; }

        /// <summary>
        /// Process priority
        /// </summary>
        [DataMember]
        public string ProcessPriority { get; set; }

        /// <summary>
        /// Process start date
        /// </summary>
        [DataMember]
        public DateTime ProcessStartDate { get; set; }

        /// <summary>
        /// Expected completion date
        /// </summary>
        [DataMember]
        public DateTime? ExpectedCompletionDate { get; set; }
    }
}