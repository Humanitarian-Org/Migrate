using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Core information record type combining all components
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class InformationRecordType
    {
        /// <summary>
        /// Information record identifier
        /// </summary>
        [DataMember]
        public string InformationRecordId { get; set; }

        /// <summary>
        /// Record title or name
        /// </summary>
        [DataMember]
        public string RecordTitle { get; set; }

        /// <summary>
        /// Record description
        /// </summary>
        [DataMember]
        public string RecordDescription { get; set; }

        /// <summary>
        /// Record type or category
        /// </summary>
        [DataMember]
        public string RecordType { get; set; }

        /// <summary>
        /// Current status of the record
        /// </summary>
        [DataMember]
        public InformationRecordCurrentStatusType CurrentStatus { get; set; }

        /// <summary>
        /// Record creation date
        /// </summary>
        [DataMember]
        public DateTime RecordCreationDate { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [DataMember]
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Electronic files associated with the record
        /// </summary>
        [DataMember]
        public List<ElectronicFileType> ElectronicFiles { get; set; } = new List<ElectronicFileType>();

        /// <summary>
        /// Reference files associated with the record
        /// </summary>
        [DataMember]
        public List<ElectronicReferenceFileType> ReferenceFiles { get; set; } = new List<ElectronicReferenceFileType>();

        /// <summary>
        /// Access groups for the record
        /// </summary>
        [DataMember]
        public List<AccessGroupType> AccessGroups { get; set; } = new List<AccessGroupType>();

        /// <summary>
        /// Record relationships
        /// </summary>
        [DataMember]
        public List<InformationRecordRelationshipType> Relationships { get; set; } = new List<InformationRecordRelationshipType>();

        /// <summary>
        /// Business context associations
        /// </summary>
        [DataMember]
        public List<BusinessContextInformationRecordType> BusinessContexts { get; set; } = new List<BusinessContextInformationRecordType>();

        /// <summary>
        /// Party contexts
        /// </summary>
        [DataMember]
        public List<PartyContextType> PartyContexts { get; set; } = new List<PartyContextType>();

        /// <summary>
        /// Channel type used for the record
        /// </summary>
        [DataMember]
        public ChannelTypeType? ChannelType { get; set; }
    }
}