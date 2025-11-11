using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Numerics;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Enumeration for lodgement method types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public enum LodgementMethodTypeType
    {
        /// <summary>
        /// Online lodgement
        /// </summary>
        [EnumMember]
        ONLINE,

        /// <summary>
        /// Paper-based lodgement
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// In-person lodgement
        /// </summary>
        [EnumMember]
        IN_PERSON,

        /// <summary>
        /// Agent-assisted lodgement
        /// </summary>
        [EnumMember]
        AGENT_ASSISTED
    }

    /// <summary>
    /// Enumeration for language test types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public enum LanguageTestTypeType
    {
        /// <summary>
        /// IELTS test
        /// </summary>
        [EnumMember]
        IELTS,

        /// <summary>
        /// TOEFL test
        /// </summary>
        [EnumMember]
        TOEFL,

        /// <summary>
        /// PTE Academic test
        /// </summary>
        [EnumMember]
        PTE_ACADEMIC,

        /// <summary>
        /// Cambridge English test
        /// </summary>
        [EnumMember]
        CAMBRIDGE_ENGLISH
    }

    /// <summary>
    /// Visa condition type for visa conditions
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaConditionType
    {
        /// <summary>
        /// Condition code
        /// </summary>
        [DataMember]
        public string ConditionCode { get; set; }

        /// <summary>
        /// Condition description
        /// </summary>
        [DataMember]
        public string ConditionDescription { get; set; }

        /// <summary>
        /// Whether condition is mandatory
        /// </summary>
        [DataMember]
        public bool IsMandatory { get; set; }

        /// <summary>
        /// Condition effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Condition expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }
    }

    /// <summary>
    /// List of visa conditions
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaConditionListType
    {
        /// <summary>
        /// Collection of visa conditions
        /// </summary>
        [DataMember]
        public List<VisaConditionType> VisaCondition { get; set; } = new List<VisaConditionType>();
    }

    /// <summary>
    /// Visa classification type for visa categorization
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaClassificationType
    {
        /// <summary>
        /// Classification code
        /// </summary>
        [DataMember]
        public string ClassificationCode { get; set; }

        /// <summary>
        /// Classification name
        /// </summary>
        [DataMember]
        public string ClassificationName { get; set; }

        /// <summary>
        /// Classification description
        /// </summary>
        [DataMember]
        public string ClassificationDescription { get; set; }
    }

    /// <summary>
    /// Visa status type for visa status information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaStatusType
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
    /// Unstructured grant date type for grant date information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class UnstructuredGrantDateType
    {
        /// <summary>
        /// Grant date
        /// </summary>
        [DataMember]
        public DateTime GrantDate { get; set; }

        /// <summary>
        /// Indicates if date is estimated
        /// </summary>
        [DataMember]
        public bool IsEstimated { get; set; }

        /// <summary>
        /// Grant date source
        /// </summary>
        [DataMember]
        public string GrantDateSource { get; set; }
    }

    /// <summary>
    /// Unstructured issue date type for visa issue information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class UnstructuredIssueDateType
    {
        /// <summary>
        /// Issue date
        /// </summary>
        [DataMember]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Issuing authority
        /// </summary>
        [DataMember]
        public string IssuingAuthority { get; set; }

        /// <summary>
        /// Issue location
        /// </summary>
        [DataMember]
        public string IssueLocation { get; set; }
    }

    /// <summary>
    /// Preferred travel identity document type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class PreferredTravelIdentityDocumentType
    {
        /// <summary>
        /// Document number
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Document type
        /// </summary>
        [DataMember]
        public string DocumentType { get; set; }

        /// <summary>
        /// Issuing country
        /// </summary>
        [DataMember]
        public string IssuingCountry { get; set; }

        /// <summary>
        /// Document issue date
        /// </summary>
        [DataMember]
        public UnstructuredIssueDateType IssueDate { get; set; }

        /// <summary>
        /// Document expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }
    }

    /// <summary>
    /// Portal processing type for portal-based processing
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class PortalProcessingType
    {
        /// <summary>
        /// Portal identifier
        /// </summary>
        [DataMember]
        public string PortalId { get; set; }

        /// <summary>
        /// Portal name
        /// </summary>
        [DataMember]
        public string PortalName { get; set; }

        /// <summary>
        /// Processing status in portal
        /// </summary>
        [DataMember]
        public string ProcessingStatus { get; set; }

        /// <summary>
        /// Portal reference number
        /// </summary>
        [DataMember]
        public string PortalReferenceNumber { get; set; }
    }

    /// <summary>
    /// Visa application skills assessment type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaApplicationSkillsAssessmentType
    {
        /// <summary>
        /// Assessment authority
        /// </summary>
        [DataMember]
        public string AssessmentAuthority { get; set; }

        /// <summary>
        /// Assessment outcome
        /// </summary>
        [DataMember]
        public string AssessmentOutcome { get; set; }

        /// <summary>
        /// Assessment date
        /// </summary>
        [DataMember]
        public DateTime AssessmentDate { get; set; }

        /// <summary>
        /// Skills assessed
        /// </summary>
        [DataMember]
        public string SkillsAssessed { get; set; }
    }

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

    /// <summary>
    /// Nomination ceiling detail type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class NominationCeilingDetailType
    {
        /// <summary>
        /// Ceiling type
        /// </summary>
        [DataMember]
        public string CeilingType { get; set; }

        /// <summary>
        /// Ceiling limit
        /// </summary>
        [DataMember]
        public int CeilingLimit { get; set; }

        /// <summary>
        /// Current count
        /// </summary>
        [DataMember]
        public int CurrentCount { get; set; }

        /// <summary>
        /// Ceiling period
        /// </summary>
        [DataMember]
        public string CeilingPeriod { get; set; }
    }

    /// <summary>
    /// List of nomination ceiling details
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class NominationCeilingDetailListType
    {
        /// <summary>
        /// Collection of nomination ceiling details
        /// </summary>
        [DataMember]
        public List<NominationCeilingDetailType> NominationCeilingDetail { get; set; } = new List<NominationCeilingDetailType>();
    }

    /// <summary>
    /// Core visa type for comprehensive visa information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaType
    {
        /// <summary>
        /// Visa grant number
        /// </summary>
        [DataMember]
        public string VisaGrantNumber { get; set; }

        /// <summary>
        /// Visa grant date
        /// </summary>
        [DataMember]
        public DateTime GrantDate { get; set; }

        /// <summary>
        /// Grant by code (granting authority)
        /// </summary>
        [DataMember]
        public string GrantByCode { get; set; }

        /// <summary>
        /// Visa class code
        /// </summary>
        [DataMember]
        public string VisaClassCode { get; set; }

        /// <summary>
        /// Visa subclass code
        /// </summary>
        [DataMember]
        public string VisaSubclassCode { get; set; }

        /// <summary>
        /// Visa stream
        /// </summary>
        [DataMember]
        public string VisaStream { get; set; }

        /// <summary>
        /// Visa entries allowed code
        /// </summary>
        [DataMember]
        public string VisaEntriesAllowedCode { get; set; }

        /// <summary>
        /// Visa entry expiry date
        /// </summary>
        [DataMember]
        public DateTime? VisaEntryExpiryDate { get; set; }

        /// <summary>
        /// Visa stay period code
        /// </summary>
        [DataMember]
        public string VisaStayPeriodCode { get; set; }

        /// <summary>
        /// Date until which visa is in effect
        /// </summary>
        [DataMember]
        public DateTime? VisaInEffectUntilDate { get; set; }

        /// <summary>
        /// Initial visa stay until date
        /// </summary>
        [DataMember]
        public DateTime? InitialVisaStayUntilDate { get; set; }

        /// <summary>
        /// Migrant entry expiry date
        /// </summary>
        [DataMember]
        public DateTime? MigrantEntryExpiryDate { get; set; }

        /// <summary>
        /// Visa condition codes
        /// </summary>
        [DataMember]
        public List<int> VisaConditionCode { get; set; } = new List<int>();

        /// <summary>
        /// Detailed visa conditions
        /// </summary>
        [DataMember]
        public VisaConditionListType VisaConditions { get; set; }

        /// <summary>
        /// Visa classification
        /// </summary>
        [DataMember]
        public VisaClassificationType VisaClassification { get; set; }

        /// <summary>
        /// Current visa status
        /// </summary>
        [DataMember]
        public VisaStatusType VisaStatus { get; set; }

        /// <summary>
        /// Preferred travel document
        /// </summary>
        [DataMember]
        public PreferredTravelIdentityDocumentType PreferredTravelDocument { get; set; }

        /// <summary>
        /// Portal processing information
        /// </summary>
        [DataMember]
        public PortalProcessingType PortalProcessing { get; set; }

        /// <summary>
        /// Skills assessment information
        /// </summary>
        [DataMember]
        public VisaApplicationSkillsAssessmentType SkillsAssessment { get; set; }

        /// <summary>
        /// Decision notification information
        /// </summary>
        [DataMember]
        public VisaApplicationDecisionNotificationType DecisionNotification { get; set; }

        /// <summary>
        /// Lodgement method
        /// </summary>
        [DataMember]
        public LodgementMethodTypeType? LodgementMethod { get; set; }
    }

    /// <summary>
    /// Visa application update object type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaApplicationUpdateObjectType
    {
        /// <summary>
        /// Application identifier
        /// </summary>
        [DataMember]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Update type
        /// </summary>
        [DataMember]
        public string UpdateType { get; set; }

        /// <summary>
        /// Updated visa information
        /// </summary>
        [DataMember]
        public VisaType UpdatedVisaInformation { get; set; }

        /// <summary>
        /// Update timestamp
        /// </summary>
        [DataMember]
        public DateTime UpdateTimestamp { get; set; }

        /// <summary>
        /// Update reason
        /// </summary>
        [DataMember]
        public string UpdateReason { get; set; }
    }
}