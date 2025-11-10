using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise.Core.V1;
using eMedicalService.Contracts.Health.Core.V1;

namespace eMedicalService.Contracts.Health.Messaging.Service.V1
{
    /// <summary>
    /// Cache health case details request - corrected based on Java v2 implementation
    /// </summary>
    [DataContract(Name = "cacheHealthCaseDetailsRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    [XmlType(TypeName = "cacheHealthCaseDetailsRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class CacheHealthCaseDetailsRequestType
    {
        [DataMember(Order = 0, IsRequired = true)]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, IsRequired = true)]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public List<HealthCaseIdentifierMsgType> HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("CachedCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("CachedeHealthCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedeHealthCreationDate { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("CacheHealthCaseBiographicalDetails")]
        public CacheHealthCaseBiographicalDetailsType CacheHealthCaseBiographicalDetails { get; set; }

        [DataMember(Order = 5)]
        [XmlElement("HealthClientContactListMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthClientContactListMsgType HealthClientContactListMsg { get; set; }

        [DataMember(Order = 6, IsRequired = true)]
        [XmlElement("CacheHealthCaseHealthVisaContextDetailsList")]
        public CacheHealthCaseHealthVisaContextDetailsListType CacheHealthCaseHealthVisaContextDetailsList { get; set; }

        [DataMember(Order = 7)]
        [XmlElement("HealthCaseDetailsRequestHealthRequirement")]
        public List<HealthCaseDetailsRequestHealthRequirementType> HealthCaseDetailsRequestHealthRequirement { get; set; }

        public CacheHealthCaseDetailsRequestType()
        {
            HealthCaseIdentifierMsg = new List<HealthCaseIdentifierMsgType>();
            HealthCaseDetailsRequestHealthRequirement = new List<HealthCaseDetailsRequestHealthRequirementType>();
        }
    }

    /// <summary>
    /// Health case biographical details for caching operations
    /// </summary>
    [DataContract(Name = "cacheHealthCaseBiographicalDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    [XmlType(TypeName = "cacheHealthCaseBiographicalDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class CacheHealthCaseBiographicalDetailsType
    {
        [DataMember]
        [XmlElement("Title")]
        public string Title { get; set; }

        [DataMember]
        [XmlElement("GivenName")]
        public List<string> GivenName { get; set; }

        [DataMember]
        [XmlElement("FamilyName")]
        public string FamilyName { get; set; }

        [DataMember]
        [XmlElement("DateOfBirth")]
        public CachedUnstructuredDateType DateOfBirth { get; set; }

        [DataMember]
        [XmlElement("Sex")]
        public string Sex { get; set; }

        [DataMember]
        [XmlElement("CountryOfBirth")]
        public string CountryOfBirth { get; set; }

        [DataMember]
        [XmlElement("Nationality")]
        public List<string> Nationality { get; set; }

        public CacheHealthCaseBiographicalDetailsType()
        {
            GivenName = new List<string>();
            Nationality = new List<string>();
        }
    }

    /// <summary>
    /// Health client contact list messaging type
    /// </summary>
    [DataContract(Name = "healthClientContactListMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    [XmlType(TypeName = "healthClientContactListMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClientContactListMsgType
    {
        [DataMember]
        [XmlElement("HealthClientContact")]
        public List<HealthClientContactMsgType> HealthClientContact { get; set; }

        public HealthClientContactListMsgType()
        {
            HealthClientContact = new List<HealthClientContactMsgType>();
        }
    }

    /// <summary>
    /// Health client contact messaging type
    /// </summary>
    [DataContract(Name = "healthClientContactMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    [XmlType(TypeName = "healthClientContactMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClientContactMsgType
    {
        [DataMember]
        [XmlElement("ContactMethod")]
        public string ContactMethod { get; set; }

        [DataMember]
        [XmlElement("ContactValue")]
        public string ContactValue { get; set; }

        [DataMember]
        [XmlElement("IsPrimary")]
        public bool IsPrimary { get; set; }
    }

    /// <summary>
    /// Health case visa context details list
    /// </summary>
    [DataContract(Name = "cacheHealthCaseHealthVisaContextDetailsListType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    [XmlType(TypeName = "cacheHealthCaseHealthVisaContextDetailsListType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class CacheHealthCaseHealthVisaContextDetailsListType
    {
        [DataMember]
        [XmlElement("CacheHealthCaseHealthVisaContextDetails")]
        public List<CacheHealthCaseHealthVisaContextDetailsType> CacheHealthCaseHealthVisaContextDetails { get; set; }

        public CacheHealthCaseHealthVisaContextDetailsListType()
        {
            CacheHealthCaseHealthVisaContextDetails = new List<CacheHealthCaseHealthVisaContextDetailsType>();
        }
    }

    /// <summary>
    /// Health case visa context details
    /// </summary>
    [DataContract(Name = "cacheHealthCaseHealthVisaContextDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    [XmlType(TypeName = "cacheHealthCaseHealthVisaContextDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class CacheHealthCaseHealthVisaContextDetailsType
    {
        [DataMember]
        [XmlElement("VisaSubclass")]
        public string VisaSubclass { get; set; }

        [DataMember]
        [XmlElement("ClientType")]
        public string ClientType { get; set; }

        [DataMember]
        [XmlElement("ProcessingUnit")]
        public string ProcessingUnit { get; set; }

        [DataMember]
        [XmlElement("ProcessingLocation")]
        public string ProcessingLocation { get; set; }
    }

    /// <summary>
    /// Health case details request health requirement
    /// </summary>
    [DataContract(Name = "healthCaseDetailsRequestHealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    [XmlType(TypeName = "healthCaseDetailsRequestHealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class HealthCaseDetailsRequestHealthRequirementType
    {
        [DataMember]
        [XmlElement("RequirementCode")]
        public string RequirementCode { get; set; }

        [DataMember]
        [XmlElement("RequirementDescription")]
        public string RequirementDescription { get; set; }

        [DataMember]
        [XmlElement("AssessmentType")]
        public string AssessmentType { get; set; }

        [DataMember]
        [XmlElement("IsMandatory")]
        public bool IsMandatory { get; set; }

        [DataMember]
        [XmlElement("DueDate")]
        public CachedUnstructuredDateType DueDate { get; set; }
    }

    /// <summary>
    /// Register health case request - basic implementation
    /// </summary>
    [DataContract(Name = "registerHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "registerHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class RegisterHealthCaseRequestType
    {
        [DataMember]
        [XmlElement("HealthCase")]
        public HealthCaseType HealthCase { get; set; }

        [DataMember]
        [XmlElement("MessageId")]
        public string MessageId { get; set; }

        [DataMember]
        [XmlElement("RequestDateTime")]
        public DateTime RequestDateTime { get; set; }
    }

    /// <summary>
    /// Notify medical examination status request
    /// </summary>
    [DataContract(Name = "notifyMedicalExaminationStatusRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "notifyMedicalExaminationStatusRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class NotifyMedicalExaminationStatusRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("MedicalExamination")]
        public MedicalExaminationType MedicalExamination { get; set; }

        [DataMember]
        [XmlElement("StatusChangeDateTime")]
        public DateTime StatusChangeDateTime { get; set; }

        [DataMember]
        [XmlElement("NotificationNotes")]
        public NoteTextType NotificationNotes { get; set; }
    }

    /// <summary>
    /// Register medical examinations results request
    /// </summary>
    [DataContract(Name = "registerMedicalExaminationsResultsRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "registerMedicalExaminationsResultsRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("MedicalExaminations")]
        public List<MedicalExaminationType> MedicalExaminations { get; set; }

        [DataMember]
        [XmlElement("ResultsSubmissionDateTime")]
        public DateTime ResultsSubmissionDateTime { get; set; }

        [DataMember]
        [XmlElement("ResultsNotes")]
        public NoteTextType ResultsNotes { get; set; }

        public RegisterMedicalExaminationsResultsRequestType()
        {
            MedicalExaminations = new List<MedicalExaminationType>();
        }
    }

    /// <summary>
    /// Delete cached health case request
    /// </summary>
    [DataContract(Name = "deleteCachedHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "deleteCachedHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class DeleteCachedHealthCaseRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("DeletionReason")]
        public string DeletionReason { get; set; }

        [DataMember]
        [XmlElement("RequestDateTime")]
        public DateTime RequestDateTime { get; set; }
    }

    /// <summary>
    /// Get cached health case request
    /// </summary>
    [DataContract(Name = "getCachedHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "getCachedHealthCaseRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class GetCachedHealthCaseRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("IncludeAuditInformation")]
        public bool IncludeAuditInformation { get; set; }

        [DataMember]
        [XmlElement("RequestDateTime")]
        public DateTime RequestDateTime { get; set; }
    }

    /// <summary>
    /// Get health case status request  
    /// </summary>
    [DataContract(Name = "getHealthCaseStatusRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "getHealthCaseStatusRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class GetHealthCaseStatusRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("RequestDateTime")]
        public DateTime RequestDateTime { get; set; }
    }

    /// <summary>
    /// Update medical examination request
    /// </summary>
    [DataContract(Name = "updateMedicalExaminationRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "updateMedicalExaminationRequestType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class UpdateMedicalExaminationRequestType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierMsgType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("MedicalExamination")]
        public MedicalExaminationType MedicalExamination { get; set; }

        [DataMember]
        [XmlElement("UpdateDateTime")]
        public DateTime UpdateDateTime { get; set; }

        [DataMember]
        [XmlElement("UpdateNotes")]
        public NoteTextType UpdateNotes { get; set; }
    }
}