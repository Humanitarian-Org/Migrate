using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise.Core.V1;

namespace eMedicalService.Contracts.Health.Core.V1
{
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