using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for correspondence delivery channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum DeliveryChannelTypeType
    {
        /// <summary>
        /// Email delivery
        /// </summary>
        [EnumMember]
        EMAIL,

        /// <summary>
        /// Postal delivery
        /// </summary>
        [EnumMember]
        POST,

        /// <summary>
        /// Fax delivery
        /// </summary>
        [EnumMember]
        FAX,

        /// <summary>
        /// Hand delivery
        /// </summary>
        [EnumMember]
        BY_HAND,

        /// <summary>
        /// Hand delivery to last known address
        /// </summary>
        [EnumMember]
        BY_HAND_LAST_KNOWN
    }

    /// <summary>
    /// Enumeration for correspondence status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceStatusCodeType
    {
        /// <summary>
        /// Correspondence has been deleted
        /// </summary>
        [EnumMember]
        DELETED,

        /// <summary>
        /// Correspondence has been sent
        /// </summary>
        [EnumMember]
        SENT,

        /// <summary>
        /// Sent but storage failed
        /// </summary>
        [EnumMember]
        SENT_STORAGE_FAILED,

        /// <summary>
        /// Sent and pending storage
        /// </summary>
        [EnumMember]
        SENT_PENDING_STORAGE,

        /// <summary>
        /// Sent and pending delivery
        /// </summary>
        [EnumMember]
        SENT_PENDING_DELIVERY,

        /// <summary>
        /// Correspondence has been generated
        /// </summary>
        [EnumMember]
        GENERATED,

        /// <summary>
        /// Generated and pending storage
        /// </summary>
        [EnumMember]
        GENERATED_PENDING_STORAGE,

        /// <summary>
        /// Generated but storage failed
        /// </summary>
        [EnumMember]
        GENERATED_STORAGE_FAILED,

        /// <summary>
        /// Draft delivery failed
        /// </summary>
        [EnumMember]
        DRAFT_DELIVERY_FAILED,

        /// <summary>
        /// Correspondence is in draft status
        /// </summary>
        [EnumMember]
        DRAFT,

        /// <summary>
        /// Correspondence is in pre-draft status
        /// </summary>
        [EnumMember]
        PRE_DRAFT
    }

    /// <summary>
    /// Enumeration for correspondence category types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceCategoryTypeType
    {
        /// <summary>
        /// Inbound correspondence
        /// </summary>
        [EnumMember]
        INBOUND,

        /// <summary>
        /// Outbound correspondence
        /// </summary>
        [EnumMember]
        OUTBOUND,

        /// <summary>
        /// Internal correspondence
        /// </summary>
        [EnumMember]
        INTERNAL,

        /// <summary>
        /// System generated correspondence
        /// </summary>
        [EnumMember]
        SYSTEM_GENERATED
    }

    /// <summary>
    /// Enumeration for correspondence role types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceRoleTypeType
    {
        /// <summary>
        /// Sender role
        /// </summary>
        [EnumMember]
        SENDER,

        /// <summary>
        /// Recipient role
        /// </summary>
        [EnumMember]
        RECIPIENT,

        /// <summary>
        /// Carbon copy role
        /// </summary>
        [EnumMember]
        CC,

        /// <summary>
        /// Blind carbon copy role
        /// </summary>
        [EnumMember]
        BCC,

        /// <summary>
        /// Forwarded role
        /// </summary>
        [EnumMember]
        FORWARDED
    }

    /// <summary>
    /// Enumeration for document category codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum DocumentCategoryCodeType
    {
        /// <summary>
        /// Official letter
        /// </summary>
        [EnumMember]
        LETTER,

        /// <summary>
        /// Notice document
        /// </summary>
        [EnumMember]
        NOTICE,

        /// <summary>
        /// Report document
        /// </summary>
        [EnumMember]
        REPORT,

        /// <summary>
        /// Certificate document
        /// </summary>
        [EnumMember]
        CERTIFICATE,

        /// <summary>
        /// Attachment document
        /// </summary>
        [EnumMember]
        ATTACHMENT
    }

    /// <summary>
    /// Registration date type for correspondence registration
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class RegistrationDateType
    {
        /// <summary>
        /// Date of registration
        /// </summary>
        [DataMember]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Registration authority or system
        /// </summary>
        [DataMember]
        public string RegistrationAuthority { get; set; }

        /// <summary>
        /// Registration reference number
        /// </summary>
        [DataMember]
        public string RegistrationReference { get; set; }
    }

    /// <summary>
    /// Body content binary type for correspondence content
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
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
        /// Content encoding type
        /// </summary>
        [DataMember]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Content size in bytes
        /// </summary>
        [DataMember]
        public long? ContentSize { get; set; }

        /// <summary>
        /// Content checksum for integrity verification
        /// </summary>
        [DataMember]
        public string ContentChecksum { get; set; }
    }

    /// <summary>
    /// Correspondence header type for correspondence metadata
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceHeaderType
    {
        /// <summary>
        /// Correspondence unique identifier
        /// </summary>
        [DataMember]
        public string CorrespondenceId { get; set; }

        /// <summary>
        /// Subject line of the correspondence
        /// </summary>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Correspondence status
        /// </summary>
        [DataMember]
        public CorrespondenceStatusCodeType Status { get; set; }

        /// <summary>
        /// Correspondence category
        /// </summary>
        [DataMember]
        public CorrespondenceCategoryTypeType Category { get; set; }

        /// <summary>
        /// Document category
        /// </summary>
        [DataMember]
        public DocumentCategoryCodeType DocumentCategory { get; set; }

        /// <summary>
        /// Creation timestamp
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Last modification timestamp
        /// </summary>
        [DataMember]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Sent timestamp
        /// </summary>
        [DataMember]
        public DateTime? SentDate { get; set; }

        /// <summary>
        /// Registration details
        /// </summary>
        [DataMember]
        public RegistrationDateType Registration { get; set; }

        /// <summary>
        /// Priority level
        /// </summary>
        [DataMember]
        public string Priority { get; set; }

        /// <summary>
        /// Reference to parent correspondence
        /// </summary>
        [DataMember]
        public string ParentCorrespondenceId { get; set; }
    }

    /// <summary>
    /// Correspondence participant type for sender/recipient information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceParticipantType
    {
        /// <summary>
        /// Role in the correspondence
        /// </summary>
        [DataMember]
        public CorrespondenceRoleTypeType Role { get; set; }

        /// <summary>
        /// Participant name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [DataMember]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Postal address
        /// </summary>
        [DataMember]
        public string PostalAddress { get; set; }

        /// <summary>
        /// Fax number
        /// </summary>
        [DataMember]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Party identifier for the participant
        /// </summary>
        [DataMember]
        public string PartyIdentifier { get; set; }

        /// <summary>
        /// Preferred delivery channel
        /// </summary>
        [DataMember]
        public DeliveryChannelTypeType? PreferredDeliveryChannel { get; set; }
    }

    /// <summary>
    /// List of correspondence participants
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceParticipantListType
    {
        /// <summary>
        /// Collection of participants
        /// </summary>
        [DataMember]
        public List<CorrespondenceParticipantType> Participant { get; set; } = new List<CorrespondenceParticipantType>();
    }

    /// <summary>
    /// Correspondence attachment type for file attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceAttachmentType
    {
        /// <summary>
        /// Attachment filename
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Attachment binary content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType BinaryContent { get; set; }

        /// <summary>
        /// Attachment description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Document category of the attachment
        /// </summary>
        [DataMember]
        public DocumentCategoryCodeType? AttachmentCategory { get; set; }
    }

    /// <summary>
    /// List of correspondence attachments
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceAttachmentListType
    {
        /// <summary>
        /// Collection of attachments
        /// </summary>
        [DataMember]
        public List<CorrespondenceAttachmentType> Attachment { get; set; } = new List<CorrespondenceAttachmentType>();
    }

    /// <summary>
    /// Complete correspondence type combining all correspondence components
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceType
    {
        /// <summary>
        /// Correspondence header information
        /// </summary>
        [DataMember]
        public CorrespondenceHeaderType Header { get; set; }

        /// <summary>
        /// Correspondence participants (sender, recipients, etc.)
        /// </summary>
        [DataMember]
        public CorrespondenceParticipantListType Participants { get; set; }

        /// <summary>
        /// Correspondence body content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType BodyContent { get; set; }

        /// <summary>
        /// Correspondence attachments
        /// </summary>
        [DataMember]
        public CorrespondenceAttachmentListType Attachments { get; set; }

        /// <summary>
        /// Delivery channels used
        /// </summary>
        [DataMember]
        public List<DeliveryChannelTypeType> DeliveryChannels { get; set; } = new List<DeliveryChannelTypeType>();
    }

    /// <summary>
    /// Correspondence search criteria type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceSearchCriteriaType
    {
        /// <summary>
        /// Search by correspondence ID
        /// </summary>
        [DataMember]
        public string CorrespondenceId { get; set; }

        /// <summary>
        /// Search by status
        /// </summary>
        [DataMember]
        public CorrespondenceStatusCodeType? Status { get; set; }

        /// <summary>
        /// Search by category
        /// </summary>
        [DataMember]
        public CorrespondenceCategoryTypeType? Category { get; set; }

        /// <summary>
        /// Search by participant
        /// </summary>
        [DataMember]
        public string ParticipantName { get; set; }

        /// <summary>
        /// Search by date range
        /// </summary>
        [DataMember]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Search by date range
        /// </summary>
        [DataMember]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Search by subject
        /// </summary>
        [DataMember]
        public string SubjectKeywords { get; set; }
    }
}