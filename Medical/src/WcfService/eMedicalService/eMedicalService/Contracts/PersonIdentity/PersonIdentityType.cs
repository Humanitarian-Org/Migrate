using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.PersonIdentity.Core.V1
{
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