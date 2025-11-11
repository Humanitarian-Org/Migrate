using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Information record relationship type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class InformationRecordRelationshipType
    {
        /// <summary>
        /// Related record identifier
        /// </summary>
        [DataMember]
        public string RelatedRecordId { get; set; }

        /// <summary>
        /// Relationship type
        /// </summary>
        [DataMember]
        public string RelationshipType { get; set; }

        /// <summary>
        /// Relationship description
        /// </summary>
        [DataMember]
        public string RelationshipDescription { get; set; }

        /// <summary>
        /// Relationship direction
        /// </summary>
        [DataMember]
        public DirectionTypeType RelationshipDirection { get; set; }
    }
}