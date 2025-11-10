using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise.Core.V1;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Cached unstructured date type extending the base UnstructuredDateType
    /// </summary>
    [DataContract(Name = "cachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "cachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType : UnstructuredDateType
    {
        [DataMember(Order = 3)]
        [XmlElement("CachedEntryKey")]
        public string CachedEntryKey { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("CachedEntryText")]
        public string CachedEntryText { get; set; }
    }

    /// <summary>
    /// Health case identifier type
    /// </summary>
    [DataContract(Name = "healthCaseIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "healthCaseIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifierValue")]
        public string HealthCaseIdentifierValue { get; set; }
    }

    /// <summary>
    /// Health case identifier message type 
    /// </summary>
    [DataContract(Name = "healthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "healthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }
    }

    /// <summary>
    /// Person name type
    /// </summary>
    [DataContract(Name = "personNameType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "personNameType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class PersonNameType
    {
        [DataMember]
        [XmlElement("GivenName")]
        public string GivenName { get; set; }

        [DataMember]
        [XmlElement("FamilyName")]
        public string FamilyName { get; set; }

        [DataMember]
        [XmlElement("MiddleName")]
        public string MiddleName { get; set; }

        [DataMember]
        [XmlElement("Title")]
        public string Title { get; set; }
    }

    /// <summary>
    /// Medical examination status enumeration
    /// </summary>
    [DataContract(Name = "medicalExaminationStatus", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public enum MedicalExaminationStatus
    {
        [EnumMember]
        NOT_STARTED,
        [EnumMember]
        IN_PROGRESS,
        [EnumMember]
        COMPLETED,
        [EnumMember]
        CANCELLED,
        [EnumMember]
        REFERRED,
        [EnumMember]
        FAILED
    }

    /// <summary>
    /// Medical examination type
    /// </summary>
    [DataContract(Name = "medicalExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "medicalExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class MedicalExaminationType
    {
        [DataMember]
        [XmlElement("ExaminationTypeCode")]
        public string ExaminationTypeCode { get; set; }

        [DataMember]
        [XmlElement("ExaminationTypeDescription")]
        public string ExaminationTypeDescription { get; set; }

        [DataMember]
        [XmlElement("Status")]
        public MedicalExaminationStatus Status { get; set; }

        [DataMember]
        [XmlElement("ExaminationDate")]
        public CachedUnstructuredDateType ExaminationDate { get; set; }

        [DataMember]
        [XmlElement("ExaminationCentre")]
        public string ExaminationCentre { get; set; }
    }

    /// <summary>
    /// Health case type containing all health information
    /// </summary>
    [DataContract(Name = "healthCaseType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "healthCaseType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("PersonName")]
        public PersonNameType PersonName { get; set; }

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
        public string Nationality { get; set; }

        [DataMember]
        [XmlElement("PassportNumber")]
        public string PassportNumber { get; set; }

        [DataMember]
        [XmlElement("PassportCountryOfIssue")]
        public string PassportCountryOfIssue { get; set; }

        [DataMember]
        [XmlElement("VisaSubclass")]
        public string VisaSubclass { get; set; }

        [DataMember]
        [XmlElement("ClientType")]
        public string ClientType { get; set; }

        [DataMember]
        [XmlElement("CaseCreationDate")]
        public CachedUnstructuredDateType CaseCreationDate { get; set; }

        [DataMember]
        [XmlElement("MedicalExaminations")]
        public List<MedicalExaminationType> MedicalExaminations { get; set; }

        [DataMember]
        [XmlElement("AuditInformation")]
        public AuditInformationType AuditInformation { get; set; }

        public HealthCaseType()
        {
            MedicalExaminations = new List<MedicalExaminationType>();
        }
    }
}