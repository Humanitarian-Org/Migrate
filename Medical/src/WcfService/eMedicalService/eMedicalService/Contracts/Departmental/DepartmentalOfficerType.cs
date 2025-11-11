using System;
using System.Runtime.Serialization;

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
}