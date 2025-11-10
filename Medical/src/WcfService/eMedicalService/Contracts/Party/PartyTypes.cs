using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Enumeration for party types - either ORGANISATION or PERSON
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum PartyTypeType
    {
        [EnumMember]
        ORGANISATION,
        
        [EnumMember]
        PERSON
    }

    /// <summary>
    /// Enumeration for party search types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum PartySearchTypeType
    {
        [EnumMember]
        IDENTITY_DOCUMENT,
        
        [EnumMember]
        ORGANISATION_ID,
        
        [EnumMember]
        PERSON_ID,
        
        [EnumMember]
        ORGANISATION,
        
        [EnumMember]
        PERSON,
        
        [EnumMember]
        GENERIC
    }

    /// <summary>
    /// Enumeration for identifier types used in the party system
    /// Includes various system identifiers like CDH_PARTY_ID, CID, CSP_ID, etc.
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum IdentifierTypeType
    {
        /// <summary>
        /// Common Data Hub Party Identifier
        /// </summary>
        [EnumMember]
        CDH_PARTY_ID,
        
        /// <summary>
        /// Client Identifier
        /// </summary>
        [EnumMember]
        CID,
        
        /// <summary>
        /// Customer Service Portal Identifier
        /// </summary>
        [EnumMember]
        CSP_ID,
        
        /// <summary>
        /// HATS (Health Assessment and Treatment System) Client Identifier
        /// </summary>
        [EnumMember]
        HATS_CLIENT_ID,
        
        /// <summary>
        /// ICSE (Immigration Case Status Enquiry) Agent Identifier
        /// </summary>
        [EnumMember]
        ICSE_AGENT_ID,
        
        /// <summary>
        /// Migration Agent Registration Authority Identifier
        /// </summary>
        [EnumMember]
        MARA_ID,
        
        /// <summary>
        /// Person Identifier
        /// </summary>
        [EnumMember]
        PID,
        
        /// <summary>
        /// Revenue Receipting Identifier
        /// </summary>
        [EnumMember]
        REVENUE_RECEIPTING_ID,
        
        /// <summary>
        /// Sponsor Client Identifier
        /// </summary>
        [EnumMember]
        SCID
    }

    /// <summary>
    /// Enumeration for role identifier types used for tracking party roles across various systems
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum RoleIdentifierTypeType
    {
        [EnumMember]
        APPLICANT_TRACKING_NUMBER,

        /// <summary>
        /// Authorised Recipient Id
        /// </summary>
        [EnumMember]
        AUTHORISED_RECIPIENT_ID,

        /// <summary>
        /// Biometric Acquisition and Matching System ID
        /// </summary>
        [EnumMember]
        BAMS_ID,

        /// <summary>
        /// Border Referral Id
        /// </summary>
        [EnumMember]
        BORDER_REFERRAL_ID,

        /// <summary>
        /// GVP Transaction Client Id
        /// </summary>
        [EnumMember]
        BTXC_ID,

        /// <summary>
        /// GVP Contact Recipient Id
        /// </summary>
        [EnumMember]
        BTXCR_ID,

        [EnumMember]
        CANX_ID,

        [EnumMember]
        CANXC_ID,

        [EnumMember]
        CANXCR_ID,

        /// <summary>
        /// CCMDS Appointment Id (Compliance Counter Appointment ID)
        /// </summary>
        [EnumMember]
        CCMDS_APPOINTMENT_ID,

        /// <summary>
        /// CCMDS Referral Id
        /// </summary>
        [EnumMember]
        CCMDS_REFERRAL_ID,

        /// <summary>
        /// CCMDS Service Id
        /// </summary>
        [EnumMember]
        CCMDS_SERVICE_ID,

        /// <summary>
        /// Citizenship Evidence Number
        /// </summary>
        [EnumMember]
        CEN,

        /// <summary>
        /// Citizenship Appointment Id
        /// </summary>
        [EnumMember]
        CITIZENSHIP_APPOINTMENT_ID,

        /// <summary>
        /// CCMDS Client Case Id
        /// </summary>
        [EnumMember]
        CLIENT_CASE_ID,

        /// <summary>
        /// ELMA Examinee ID
        /// </summary>
        [EnumMember]
        ELMA_EXAMINEE_ID,

        [EnumMember]
        ETAS_ID,

        [EnumMember]
        HAP_APPLICANT_ID,

        [EnumMember]
        HEALTH_CASE_NUMBER,

        [EnumMember]
        IMMI_CARD_STATUS_ID,

        [EnumMember]
        IMTEL_ID,

        [EnumMember]
        IRIS_AGENT_ID,

        /// <summary>
        /// IRIS Client Identifier
        /// </summary>
        [EnumMember]
        IRIS_CLIENT_ID,

        [EnumMember]
        IRIS_POST_CLIENT_ID,

        [EnumMember]
        ONLINE_ACCOUNT_ID,

        /// <summary>
        /// Security Referral Id
        /// </summary>
        [EnumMember]
        SECURITY_REFERRAL_ID,

        [EnumMember]
        SPL,

        /// <summary>
        /// Visa Application Identifier
        /// </summary>
        [EnumMember]
        VISA_APPLICATION_ID,

        [EnumMember]
        VISA_GRANT_NUMBER,

        /// <summary>
        /// Visa Lodgement Number
        /// </summary>
        [EnumMember]
        VLN
    }

    /// <summary>
    /// Core party identifier type containing an identifier and its type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierType
    {
        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public IdentifierTypeType IdentifierType { get; set; }
    }

    /// <summary>
    /// Party role identifier containing role identifier and role type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyRoleIdentifierType
    {
        [DataMember]
        public string RoleIdentifier { get; set; }

        [DataMember]
        public RoleIdentifierTypeType RoleIdentifierType { get; set; }
    }

    /// <summary>
    /// Detailed party identifier with effective dates
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierDetailsType
    {
        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public IdentifierTypeType IdentifierType { get; set; }

        [DataMember]
        public DateTime? EffectiveFromDateTime { get; set; }

        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }

    /// <summary>
    /// List of party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierListType
    {
        [DataMember]
        public List<PartyIdentifierType> PartyIdentifier { get; set; } = new List<PartyIdentifierType>();
    }

    /// <summary>
    /// List of detailed party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierDetailsListType
    {
        [DataMember]
        public List<PartyIdentifierDetailsType> PartyIdentifierDetails { get; set; } = new List<PartyIdentifierDetailsType>();
    }

    /// <summary>
    /// Generic identifier type for flexible identifier management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class GenericIdentifierType
    {
        [DataMember]
        public string GenericIdentifierValue { get; set; }

        [DataMember]
        public string GenericIdentifierType { get; set; }
    }

    /// <summary>
    /// Alternate party identifier type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierType
    {
        [DataMember]
        public string AlternateIdentifier { get; set; }

        [DataMember]
        public string AlternateIdentifierType { get; set; }
    }

    /// <summary>
    /// List of alternate party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierListType
    {
        [DataMember]
        public List<PartyAlternateIdentifierType> PartyAlternateIdentifier { get; set; } = new List<PartyAlternateIdentifierType>();
    }

    /// <summary>
    /// Detailed alternate party identifier with metadata
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierDetailsType
    {
        [DataMember]
        public string AlternateIdentifier { get; set; }

        [DataMember]
        public string AlternateIdentifierType { get; set; }

        [DataMember]
        public DateTime? EffectiveFromDateTime { get; set; }

        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }

    /// <summary>
    /// List of detailed alternate party identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierDetailsListType
    {
        [DataMember]
        public List<PartyAlternateIdentifierDetailsType> PartyAlternateIdentifierDetails { get; set; } = new List<PartyAlternateIdentifierDetailsType>();
    }

    /// <summary>
    /// Search index identifier for party searches
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class SearchIndexIdentifierType
    {
        [DataMember]
        public string SearchIndexValue { get; set; }

        [DataMember]
        public PartySearchTypeType SearchIndexType { get; set; }
    }

    /// <summary>
    /// Anchor identifier for party linking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class AnchorIdentifierType
    {
        [DataMember]
        public string AnchorValue { get; set; }

        [DataMember]
        public string AnchorType { get; set; }
    }

    /// <summary>
    /// Match context identifier for matching operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class MatchContextIdentifierType
    {
        [DataMember]
        public string MatchContextValue { get; set; }

        [DataMember]
        public string MatchContextType { get; set; }
    }

    /// <summary>
    /// Match context type for party matching
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class MatchContextType
    {
        [DataMember]
        public string MatchContext { get; set; }

        [DataMember]
        public List<MatchContextIdentifierType> MatchContextIdentifiers { get; set; } = new List<MatchContextIdentifierType>();
    }

    /// <summary>
    /// Contact person type for party relationships
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class ContactPersonType
    {
        [DataMember]
        public string ContactPersonName { get; set; }

        [DataMember]
        public string ContactPersonRole { get; set; }

        [DataMember]
        public PartyIdentifierType ContactPersonIdentifier { get; set; }
    }

    /// <summary>
    /// Applicant sub details type for applicant-specific information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class ApplicantSubDetailsType
    {
        [DataMember]
        public string ApplicantType { get; set; }

        [DataMember]
        public string ApplicantStatus { get; set; }

        [DataMember]
        public DateTime? ApplicationDate { get; set; }
    }

    /// <summary>
    /// Party identifier request type for identifier requests
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierRequestType
    {
        [DataMember]
        public PartyIdentifierType PartyIdentifier { get; set; }

        [DataMember]
        public PartyTypeType? PartyType { get; set; }

        [DataMember]
        public string RequestContext { get; set; }
    }
}