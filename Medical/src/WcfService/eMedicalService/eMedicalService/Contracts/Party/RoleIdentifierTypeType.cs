using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
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
}