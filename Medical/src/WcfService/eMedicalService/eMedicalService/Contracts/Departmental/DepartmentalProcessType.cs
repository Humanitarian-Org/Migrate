using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
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