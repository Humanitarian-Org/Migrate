using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Business context information record type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class BusinessContextInformationRecordType
    {
        /// <summary>
        /// Business context identifier
        /// </summary>
        [DataMember]
        public string BusinessContextId { get; set; }

        /// <summary>
        /// Information record identifier
        /// </summary>
        [DataMember]
        public string InformationRecordId { get; set; }

        /// <summary>
        /// Context relationship type
        /// </summary>
        [DataMember]
        public string ContextRelationshipType { get; set; }
    }
}