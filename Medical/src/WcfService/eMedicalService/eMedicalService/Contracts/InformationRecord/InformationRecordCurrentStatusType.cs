using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Information record current status type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class InformationRecordCurrentStatusType
    {
        /// <summary>
        /// Current status information
        /// </summary>
        [DataMember]
        public InformationRecordStatusType CurrentStatus { get; set; }

        /// <summary>
        /// Previous status information
        /// </summary>
        [DataMember]
        public InformationRecordStatusType PreviousStatus { get; set; }

        /// <summary>
        /// Status change timestamp
        /// </summary>
        [DataMember]
        public DateTime StatusChangeTimestamp { get; set; }
    }
}