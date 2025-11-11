using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Correspondence search criteria type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceSearchCriteriaType
    {
        /// <summary>
        /// Search by correspondence ID
        /// </summary>
        [DataMember]
        public string CorrespondenceId { get; set; }

        /// <summary>
        /// Search by status
        /// </summary>
        [DataMember]
        public CorrespondenceStatusCodeType? Status { get; set; }

        /// <summary>
        /// Search by category
        /// </summary>
        [DataMember]
        public CorrespondenceCategoryTypeType? Category { get; set; }

        /// <summary>
        /// Search by participant
        /// </summary>
        [DataMember]
        public string ParticipantName { get; set; }

        /// <summary>
        /// Search by date range
        /// </summary>
        [DataMember]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Search by date range
        /// </summary>
        [DataMember]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Search by subject
        /// </summary>
        [DataMember]
        public string SubjectKeywords { get; set; }
    }
}