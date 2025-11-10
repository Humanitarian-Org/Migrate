using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Enumeration for address role types in information records
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum AddressRoleTypeType
    {
        /// <summary>
        /// Primary residential address
        /// </summary>
        [EnumMember]
        PRIMARY_RESIDENTIAL,

        /// <summary>
        /// Secondary or mailing address
        /// </summary>
        [EnumMember]
        MAILING,

        /// <summary>
        /// Business address
        /// </summary>
        [EnumMember]
        BUSINESS,

        /// <summary>
        /// Temporary address
        /// </summary>
        [EnumMember]
        TEMPORARY
    }

    /// <summary>
    /// Enumeration for channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum ChannelTypeType
    {
        /// <summary>
        /// Electronic channel
        /// </summary>
        [EnumMember]
        ELECTRONIC,

        /// <summary>
        /// Paper-based channel
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// Phone channel
        /// </summary>
        [EnumMember]
        PHONE,

        /// <summary>
        /// In-person channel
        /// </summary>
        [EnumMember]
        IN_PERSON
    }

    /// <summary>
    /// Enumeration for direction types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum DirectionTypeType
    {
        /// <summary>
        /// Inbound direction
        /// </summary>
        [EnumMember]
        INBOUND,

        /// <summary>
        /// Outbound direction
        /// </summary>
        [EnumMember]
        OUTBOUND,

        /// <summary>
        /// Bidirectional
        /// </summary>
        [EnumMember]
        BIDIRECTIONAL
    }

    /// <summary>
    /// Access group type for record access control
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class AccessGroupType
    {
        /// <summary>
        /// Access group identifier
        /// </summary>
        [DataMember]
        public string AccessGroupId { get; set; }

        /// <summary>
        /// Access group name
        /// </summary>
        [DataMember]
        public string AccessGroupName { get; set; }

        /// <summary>
        /// Access group description
        /// </summary>
        [DataMember]
        public string AccessGroupDescription { get; set; }

        /// <summary>
        /// Access level or permissions
        /// </summary>
        [DataMember]
        public string AccessLevel { get; set; }
    }

    /// <summary>
    /// Body content binary type for information record content
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class BodyContentBinaryType
    {
        /// <summary>
        /// Binary content data
        /// </summary>
        [DataMember]
        public byte[] ContentData { get; set; }

        /// <summary>
        /// Content MIME type
        /// </summary>
        [DataMember]
        public string ContentMimeType { get; set; }

        /// <summary>
        /// Content encoding
        /// </summary>
        [DataMember]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Content size in bytes
        /// </summary>
        [DataMember]
        public long ContentSize { get; set; }
    }

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

    /// <summary>
    /// Electronic file type for electronic documents
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class ElectronicFileType
    {
        /// <summary>
        /// File identifier
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// File type or extension
        /// </summary>
        [DataMember]
        public string FileType { get; set; }

        /// <summary>
        /// File binary content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType FileContent { get; set; }

        /// <summary>
        /// File creation date
        /// </summary>
        [DataMember]
        public DateTime FileCreationDate { get; set; }

        /// <summary>
        /// File last modified date
        /// </summary>
        [DataMember]
        public DateTime? FileModifiedDate { get; set; }
    }

    /// <summary>
    /// Electronic reference file type for file references
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class ElectronicReferenceFileType
    {
        /// <summary>
        /// Reference file identifier
        /// </summary>
        [DataMember]
        public string ReferenceFileId { get; set; }

        /// <summary>
        /// File reference information
        /// </summary>
        [DataMember]
        public BodyContentReferenceType FileReference { get; set; }

        /// <summary>
        /// Reference file metadata
        /// </summary>
        [DataMember]
        public ElectronicFileType FileMetadata { get; set; }
    }

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

    /// <summary>
    /// Party context type for party information within records
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class PartyContextType
    {
        /// <summary>
        /// Party identifier
        /// </summary>
        [DataMember]
        public string PartyId { get; set; }

        /// <summary>
        /// Party role in the context
        /// </summary>
        [DataMember]
        public string PartyRole { get; set; }

        /// <summary>
        /// Party context description
        /// </summary>
        [DataMember]
        public string PartyContextDescription { get; set; }
    }

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