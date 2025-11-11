using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// DateTime filter type for record filtering
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class DateTimeFilterType
    {
        /// <summary>
        /// Filter start date
        /// </summary>
        [DataMember]
        public DateTime? FilterStartDate { get; set; }

        /// <summary>
        /// Filter end date
        /// </summary>
        [DataMember]
        public DateTime? FilterEndDate { get; set; }

        /// <summary>
        /// Filter operator (e.g., EQUALS, BETWEEN, GREATER_THAN)
        /// </summary>
        [DataMember]
        public string FilterOperator { get; set; }
    }
}