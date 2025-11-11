using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
    /// <summary>
    /// Enumeration for biometric types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum BiometricTypeType
    {
        /// <summary>
        /// Facial biometric
        /// </summary>
        [EnumMember]
        FACIAL,

        /// <summary>
        /// FCC facial biometric
        /// </summary>
        [EnumMember]
        FCC_FACIAL
    }

    /// <summary>
    /// Enumeration for biometric identifier types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum BiometricIdentifierTypeType
    {
        /// <summary>
        /// Biometric enrolment ID
        /// </summary>
        [EnumMember]
        ENROLMENT_ID,

        /// <summary>
        /// Biometric collection ID
        /// </summary>
        [EnumMember]
        COLLECTION_ID,

        /// <summary>
        /// Biometric match ID
        /// </summary>
        [EnumMember]
        MATCH_ID
    }

    /// <summary>
    /// Enumeration for acquisition method codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum AcquisitionMethodCodeType
    {
        /// <summary>
        /// Digital acquisition method
        /// </summary>
        [EnumMember]
        DIGITAL,

        /// <summary>
        /// Manual acquisition method
        /// </summary>
        [EnumMember]
        MANUAL,

        /// <summary>
        /// Automatic acquisition method
        /// </summary>
        [EnumMember]
        AUTOMATIC
    }

    /// <summary>
    /// Enumeration for acquisition status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum AcquisitionStatusCodeType
    {
        /// <summary>
        /// Successfully acquired
        /// </summary>
        [EnumMember]
        SUCCESS,

        /// <summary>
        /// Failed to acquire
        /// </summary>
        [EnumMember]
        FAILED,

        /// <summary>
        /// Partially acquired
        /// </summary>
        [EnumMember]
        PARTIAL,

        /// <summary>
        /// Acquisition pending
        /// </summary>
        [EnumMember]
        PENDING
    }

    /// <summary>
    /// Enumeration for verification status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public enum VerificationStatusCodeType
    {
        /// <summary>
        /// Verification successful
        /// </summary>
        [EnumMember]
        VERIFIED,

        /// <summary>
        /// Verification failed
        /// </summary>
        [EnumMember]
        FAILED,

        /// <summary>
        /// Verification pending
        /// </summary>
        [EnumMember]
        PENDING,

        /// <summary>
        /// Not verified
        /// </summary>
        [EnumMember]
        NOT_VERIFIED
    }

    /// <summary>
    /// Birth date type for person birth information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BirthDateType
    {
        /// <summary>
        /// Birth date
        /// </summary>
        [DataMember]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Indicates if birth date is estimated
        /// </summary>
        [DataMember]
        public bool IsEstimated { get; set; }

        /// <summary>
        /// Birth date verification status
        /// </summary>
        [DataMember]
        public VerificationStatusCodeType? VerificationStatus { get; set; }
    }

    /// <summary>
    /// Birth country type for person birth location
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BirthCountryType
    {
        /// <summary>
        /// Country code
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [DataMember]
        public string CountryName { get; set; }

        /// <summary>
        /// Birth place within the country
        /// </summary>
        [DataMember]
        public string BirthPlace { get; set; }
    }

    /// <summary>
    /// Declared citizenship type for citizenship information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class DeclaredCitizenshipType
    {
        /// <summary>
        /// Citizenship country code
        /// </summary>
        [DataMember]
        public string CitizenshipCountryCode { get; set; }

        /// <summary>
        /// Citizenship country name
        /// </summary>
        [DataMember]
        public string CitizenshipCountryName { get; set; }

        /// <summary>
        /// Date citizenship acquired
        /// </summary>
        [DataMember]
        public DateTime? CitizenshipAcquiredDate { get; set; }

        /// <summary>
        /// Verification status of the citizenship
        /// </summary>
        [DataMember]
        public VerificationStatusCodeType? VerificationStatus { get; set; }
    }

    /// <summary>
    /// Ethnicity type for person ethnicity information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class EthnicityType
    {
        /// <summary>
        /// Ethnicity code
        /// </summary>
        [DataMember]
        public string EthnicityCode { get; set; }

        /// <summary>
        /// Ethnicity description
        /// </summary>
        [DataMember]
        public string EthnicityDescription { get; set; }

        /// <summary>
        /// Primary ethnicity indicator
        /// </summary>
        [DataMember]
        public bool IsPrimary { get; set; }
    }

    /// <summary>
    /// Biometric image identifier type for biometric image management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricImageIdentifierType
    {
        /// <summary>
        /// Image identifier value
        /// </summary>
        [DataMember]
        public string ImageId { get; set; }

        /// <summary>
        /// Type of image identifier
        /// </summary>
        [DataMember]
        public BiometricIdentifierTypeType IdentifierType { get; set; }

        /// <summary>
        /// Biometric type of the image
        /// </summary>
        [DataMember]
        public BiometricTypeType BiometricType { get; set; }
    }

    /// <summary>
    /// Biometric enrolment ID type for enrolment tracking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricEnrolmentIdType
    {
        /// <summary>
        /// Enrolment identifier
        /// </summary>
        [DataMember]
        public string EnrolmentId { get; set; }

        /// <summary>
        /// Enrolment date
        /// </summary>
        [DataMember]
        public DateTime EnrolmentDate { get; set; }

        /// <summary>
        /// Acquisition method used
        /// </summary>
        [DataMember]
        public AcquisitionMethodCodeType AcquisitionMethod { get; set; }

        /// <summary>
        /// Acquisition status
        /// </summary>
        [DataMember]
        public AcquisitionStatusCodeType AcquisitionStatus { get; set; }
    }

    /// <summary>
    /// List of biometric enrolment IDs
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricEnrolmentIdListType
    {
        /// <summary>
        /// Collection of biometric enrolment IDs
        /// </summary>
        [DataMember]
        public List<BiometricEnrolmentIdType> BiometricEnrolmentId { get; set; } = new List<BiometricEnrolmentIdType>();
    }

    /// <summary>
    /// Biometric collection ID type for collection management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricCollectionIdType
    {
        /// <summary>
        /// Collection identifier
        /// </summary>
        [DataMember]
        public string CollectionId { get; set; }

        /// <summary>
        /// Collection date
        /// </summary>
        [DataMember]
        public DateTime CollectionDate { get; set; }

        /// <summary>
        /// Collection location
        /// </summary>
        [DataMember]
        public string CollectionLocation { get; set; }
    }

    /// <summary>
    /// Biometric match ID type for matching operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class BiometricMatchIdType
    {
        /// <summary>
        /// Match identifier
        /// </summary>
        [DataMember]
        public string MatchId { get; set; }

        /// <summary>
        /// Match confidence score
        /// </summary>
        [DataMember]
        public decimal? MatchScore { get; set; }

        /// <summary>
        /// Match date
        /// </summary>
        [DataMember]
        public DateTime MatchDate { get; set; }
    }

    /// <summary>
    /// Divorce date type for marital status information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class DivorceDateType
    {
        /// <summary>
        /// Date of divorce
        /// </summary>
        [DataMember]
        public DateTime DivorceDate { get; set; }

        /// <summary>
        /// Jurisdiction of divorce
        /// </summary>
        [DataMember]
        public string DivorceJurisdiction { get; set; }

        /// <summary>
        /// Divorce certificate number
        /// </summary>
        [DataMember]
        public string DivorceCertificateNumber { get; set; }
    }

    /// <summary>
    /// Comparison level type for identity comparison operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class ComparisonLevelType
    {
        /// <summary>
        /// Comparison level identifier
        /// </summary>
        [DataMember]
        public string ComparisonLevel { get; set; }

        /// <summary>
        /// Comparison algorithm used
        /// </summary>
        [DataMember]
        public string ComparisonAlgorithm { get; set; }

        /// <summary>
        /// Comparison threshold
        /// </summary>
        [DataMember]
        public decimal ComparisonThreshold { get; set; }
    }

    /// <summary>
    /// Core person identity type combining biographical and biometric information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
    public class PersonIdentityType
    {
        /// <summary>
        /// Person's birth information
        /// </summary>
        [DataMember]
        public BirthDateType BirthDate { get; set; }

        /// <summary>
        /// Person's birth country information
        /// </summary>
        [DataMember]
        public BirthCountryType BirthCountry { get; set; }

        /// <summary>
        /// Person's declared citizenship
        /// </summary>
        [DataMember]
        public DeclaredCitizenshipType DeclaredCitizenship { get; set; }

        /// <summary>
        /// Person's ethnicity information
        /// </summary>
        [DataMember]
        public EthnicityType Ethnicity { get; set; }

        /// <summary>
        /// Biometric enrolment information
        /// </summary>
        [DataMember]
        public BiometricEnrolmentIdListType BiometricEnrolments { get; set; }

        /// <summary>
        /// Biometric image identifiers
        /// </summary>
        [DataMember]
        public List<BiometricImageIdentifierType> BiometricImages { get; set; } = new List<BiometricImageIdentifierType>();

        /// <summary>
        /// Biometric collection information
        /// </summary>
        [DataMember]
        public BiometricCollectionIdType BiometricCollection { get; set; }

        /// <summary>
        /// Biometric match information
        /// </summary>
        [DataMember]
        public BiometricMatchIdType BiometricMatch { get; set; }

        /// <summary>
        /// Divorce information if applicable
        /// </summary>
        [DataMember]
        public DivorceDateType DivorceDate { get; set; }

        /// <summary>
        /// Identity verification status
        /// </summary>
        [DataMember]
        public VerificationStatusCodeType OverallVerificationStatus { get; set; }

        /// <summary>
        /// Last verification date
        /// </summary>
        [DataMember]
        public DateTime? LastVerificationDate { get; set; }
    }
}