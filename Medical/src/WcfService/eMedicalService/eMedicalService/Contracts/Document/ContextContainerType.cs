using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Document.Core.V1
{
    /// <summary>
    /// Context container for document organization and classification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
    public class ContextContainerType
    {
        /// <summary>
        /// Unique identifier number for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerNumber { get; set; }

        /// <summary>
        /// Type classification of the context container
        /// </summary>
        [DataMember]
        public string ContextContainerType_Value { get; set; }

        /// <summary>
        /// Optional title for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerTitle { get; set; }

        /// <summary>
        /// Optional description for the context container
        /// </summary>
        [DataMember]
        public string ContextContainerDescription { get; set; }

        /// <summary>
        /// Date and time when the container becomes effective
        /// </summary>
        [DataMember]
        public DateTime EffectiveFromDateTime { get; set; }

        /// <summary>
        /// Optional date and time when the container expires
        /// </summary>
        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }
}