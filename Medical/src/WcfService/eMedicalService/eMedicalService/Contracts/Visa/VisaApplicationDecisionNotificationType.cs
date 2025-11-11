using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Visa application decision notification type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaApplicationDecisionNotificationType
    {
        /// <summary>
        /// Decision type
        /// </summary>
        [DataMember]
        public string DecisionType { get; set; }

        /// <summary>
        /// Decision date
        /// </summary>
        [DataMember]
        public DateTime DecisionDate { get; set; }

        /// <summary>
        /// Notification method
        /// </summary>
        [DataMember]
        public string NotificationMethod { get; set; }

        /// <summary>
        /// Notification date
        /// </summary>
        [DataMember]
        public DateTime? NotificationDate { get; set; }
    }
}