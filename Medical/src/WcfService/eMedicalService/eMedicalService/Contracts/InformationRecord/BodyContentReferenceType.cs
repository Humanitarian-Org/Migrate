using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Body content reference type for referenced content
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class BodyContentReferenceType
    {
        /// <summary>
        /// Reference URL or path
        /// </summary>
        [DataMember]
        public string ContentReference { get; set; }

        /// <summary>
        /// Reference type
        /// </summary>
        [DataMember]
        public string ReferenceType { get; set; }

        /// <summary>
        /// Reference description
        /// </summary>
        [DataMember]
        public string ReferenceDescription { get; set; }
    }
}