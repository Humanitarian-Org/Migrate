using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
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
}