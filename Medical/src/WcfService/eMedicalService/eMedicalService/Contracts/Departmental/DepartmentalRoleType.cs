using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
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
}