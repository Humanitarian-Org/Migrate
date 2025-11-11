using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Unstructured issue date type for visa issue information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class UnstructuredIssueDateType
    {
        /// <summary>
        /// Issue date
        /// </summary>
        [DataMember]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Issuing authority
        /// </summary>
        [DataMember]
        public string IssuingAuthority { get; set; }

        /// <summary>
        /// Issue location
        /// </summary>
        [DataMember]
        public string IssueLocation { get; set; }
    }
}