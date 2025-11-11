using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Information record status type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class InformationRecordStatusType
    {
        /// <summary>
        /// Status code
        /// </summary>
        [DataMember]
        public string StatusCode { get; set; }

        /// <summary>
        /// Status description
        /// </summary>
        [DataMember]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Status effective date
        /// </summary>
        [DataMember]
        public DateTime StatusEffectiveDate { get; set; }

        /// <summary>
        /// Status change reason
        /// </summary>
        [DataMember]
        public string StatusChangeReason { get; set; }
    }
}