using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Health.Messaging;
using eMedicalService.Contracts.Health.Core;

namespace eMedicalService.Contracts.Health.Service
{
    [XmlType(TypeName = "RegisterHealthCaseClientBiographicalDetails", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseClientBiographicalDetailsType
    {
        [XmlElement("GivenName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public string GivenName { get; set; } = string.Empty;

        [XmlElement("FamilyName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public string FamilyName { get; set; } = string.Empty;

        [XmlElement("SexType", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string SexType { get; set; } = string.Empty;

        [XmlElement("CachedBirthYear", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedBirthYear { get; set; }

        [XmlElement("CachedBirthMonth", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedBirthMonth { get; set; }

        [XmlElement("CachedBirthDay", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedBirthDay { get; set; }

        [XmlElement("BirthCountryCode", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string BirthCountryCode { get; set; } = string.Empty;

        [XmlElement("RelationshipToPrimaryApplicant", Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
        public string RelationshipToPrimaryApplicant { get; set; } = string.Empty;

        [XmlElement("HealthIdentityDocumentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthIdentityDocumentMsgType HealthIdentityDocumentMsg { get; set; }
    }
}