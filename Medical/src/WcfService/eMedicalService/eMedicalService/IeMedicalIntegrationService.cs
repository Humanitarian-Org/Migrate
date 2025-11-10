using System;
using System.ServiceModel;
using eMedicalService.Contracts.Health.Messaging.Service.V1;

namespace eMedicalService
{
    /// <summary>
    /// eMedical Integration Service Contract - replicating Java eMedical legacy system
    /// Based on au.gov.immi.namespace.health.messaging.service.v1 package structure
    /// </summary>
    [ServiceContract(Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0", 
                     Name = "eMedicalIntegrationService")]
    public interface IeMedicalIntegrationService
    {
        /// <summary>
        /// Registers a new health case in the system
        /// </summary>
        /// <param name="request">Health case registration details</param>
        /// <returns>Registration acknowledgement with health case identifier</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/RegisterHealthCase")]
        RegisterHealthCaseResponseType RegisterHealthCase(RegisterHealthCaseRequestType request);

        /// <summary>
        /// Notifies the system of a medical examination status change
        /// </summary>
        /// <param name="request">Medical examination status notification</param>
        /// <returns>Status update acknowledgement</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/NotifyMedicalExaminationStatus")]
        NotifyMedicalExaminationStatusResponseType NotifyMedicalExaminationStatus(NotifyMedicalExaminationStatusRequestType request);

        /// <summary>
        /// Registers medical examination results for a health case
        /// </summary>
        /// <param name="request">Medical examination results data</param>
        /// <returns>Results registration acknowledgement</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/RegisterMedicalExaminationsResults")]
        RegisterMedicalExaminationsResultsResponseType RegisterMedicalExaminationsResults(RegisterMedicalExaminationsResultsRequestType request);

        /// <summary>
        /// Deletes a cached health case from the system
        /// </summary>
        /// <param name="request">Health case deletion request</param>
        /// <returns>Deletion acknowledgement</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/DeleteCachedHealthCase")]
        DeleteCachedHealthCaseResponseType DeleteCachedHealthCase(DeleteCachedHealthCaseRequestType request);

        /// <summary>
        /// Retrieves a cached health case from the system
        /// </summary>
        /// <param name="request">Health case retrieval request</param>
        /// <returns>Cached health case data</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/GetCachedHealthCase")]
        GetCachedHealthCaseResponseType GetCachedHealthCase(GetCachedHealthCaseRequestType request);

        /// <summary>
        /// Gets the current status of a health case
        /// </summary>
        /// <param name="request">Health case status request</param>
        /// <returns>Current health case status information</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/GetHealthCaseStatus")]
        GetHealthCaseStatusResponseType GetHealthCaseStatus(GetHealthCaseStatusRequestType request);

        /// <summary>
        /// Updates medical examination information
        /// </summary>
        /// <param name="request">Medical examination update request</param>
        /// <returns>Update acknowledgement</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/UpdateMedicalExamination")]
        UpdateMedicalExaminationResponseType UpdateMedicalExamination(UpdateMedicalExaminationRequestType request);

        /// <summary>
        /// Caches health case details in the system
        /// </summary>
        /// <param name="request">Health case caching request</param>
        /// <returns>Caching acknowledgement with cache details</returns>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0/CacheHealthCaseDetails")]
        CacheHealthCaseDetailsResponseType CacheHealthCaseDetails(CacheHealthCaseDetailsRequestType request);
    }

    // Basic data contracts based on the WSDL structure

    [DataContract(Name = "RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequest
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1)]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 2, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 3)]
        public HealthClinicIdentifierMsgType HealthClinicIdentifierMsg { get; set; }

        [DataMember(Order = 4)]
        public RegisterHealthCaseClientBiographicalDetailsType RegisterHealthCaseClientBiographicalDetails { get; set; }
    }

    [DataContract(Name = "NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequest
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2)]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 3, Name = "HealthCaseStatusUpdate")]
        public HealthCaseStatusUpdateType HealthCaseStatusUpdate { get; set; }

        [DataMember(Order = 4)]
        public NotifyMedicalExaminationStatusRequestHealthRequirementType[] HealthRequirements { get; set; }

        [DataMember(Order = 5)]
        public NotifyMedicalStatusRequestHealthClientContextType ClientContext { get; set; }
    }

    [DataContract(Name = "DeleteCachedHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseRequest
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public string CaseId { get; set; } = string.Empty;
    }

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequest
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        public string CorrelationID { get; set; } = string.Empty;

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2)]
        public RegisterMedicalExaminationsResultsRequestIdentityDocumentType IdentityDocument { get; set; }

        [DataMember(Order = 3)]
        public HealthFacialImageMsgType HealthFacialImageMsg { get; set; }

        [DataMember(Order = 4)]
        public HealthCaseDetailFormType HealthCaseDetailForm { get; set; }

        [DataMember(Order = 5, Name = "HealthCaseAttachmentMsg")]
        public HealthCaseAttachmentMsgType[] HealthCaseAttachmentMsg { get; set; }

        [DataMember(Order = 6, Name = "HealthRequirement")]
        public RegisterMedicalExaminationsResultsRequestHealthRequirementType[] HealthRequirement { get; set; }

        [DataMember(Order = 7)]
        public string ProcessingUnit { get; set; } = string.Empty;
    }

    [DataContract(Name = "NotifyCachedHealthClientDetailsUpdateResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyCachedHealthClientDetailsUpdateResponse
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;

        [DataMember]
        public string Outcome { get; set; } = string.Empty;
    }

    [DataContract(Name = "AcknowledgementMessage", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public class AcknowledgementMessage
    {
        [DataMember(Order = 0)]
        public InformationMessagesType Informations { get; set; }

        [DataMember(Order = 1)]
        public WarningMessagesType Warnings { get; set; }

        [DataMember(Order = 2)]
        public AcknowledgementType Acknowledgement { get; set; }
    }

    [DataContract(Name = "EnterpriseErrors", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class EnterpriseErrors
    {
        [DataMember]
        public string ErrorCode { get; set; } = string.Empty;

        [DataMember]
        public string ErrorMessage { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    // Supporting complex types for RegisterHealthCaseRequest

    [DataContract(Name = "CachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string TimeZone { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [DataMember]
        public string HealthCaseId { get; set; } = string.Empty;

        [DataMember]
        public string CaseTypeCode { get; set; } = string.Empty;

        [DataMember]
        public string VisaCategoryCode { get; set; } = string.Empty;

        [DataMember]
        public string ProcessingUnitCode { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthClinicIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClinicIdentifierMsgType
    {
        [DataMember]
        public string ClinicId { get; set; } = string.Empty;

        [DataMember]
        public string ClinicName { get; set; } = string.Empty;

        [DataMember]
        public string CountryCode { get; set; } = string.Empty;

        [DataMember]
        public string StateCode { get; set; } = string.Empty;

        [DataMember]
        public string CityCode { get; set; } = string.Empty;
    }

    [DataContract(Name = "RegisterHealthCaseClientBiographicalDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseClientBiographicalDetailsType
    {
        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public string GivenName { get; set; } = string.Empty;

        [DataMember]
        public string FamilyName { get; set; } = string.Empty;

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string Gender { get; set; } = string.Empty;

        [DataMember]
        public string CountryOfBirth { get; set; } = string.Empty;

        [DataMember]
        public string Nationality { get; set; } = string.Empty;

        [DataMember]
        public HealthIdentityDocumentMsgType HealthIdentityDocument { get; set; }

        [DataMember]
        public AddressMsgType Address { get; set; }

        [DataMember]
        public string EmailAddress { get; set; } = string.Empty;

        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthIdentityDocumentMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthIdentityDocumentMsgType
    {
        [DataMember]
        public string DocumentType { get; set; } = string.Empty;

        [DataMember]
        public string DocumentNumber { get; set; } = string.Empty;

        [DataMember]
        public string IssuingCountry { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [DataMember]
        public DateTime IssueDate { get; set; }
    }

    [DataContract(Name = "AddressMsgType", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
    public class AddressMsgType
    {
        [DataMember]
        public string AddressLine1 { get; set; } = string.Empty;

        [DataMember]
        public string AddressLine2 { get; set; } = string.Empty;

        [DataMember]
        public string Suburb { get; set; } = string.Empty;

        [DataMember]
        public string State { get; set; } = string.Empty;

        [DataMember]
        public string PostalCode { get; set; } = string.Empty;

        [DataMember]
        public string Country { get; set; } = string.Empty;
    }

    // Supporting complex types for NotifyMedicalExaminationStatusRequest

    [DataContract(Name = "HealthCaseStatusUpdateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class HealthCaseStatusUpdateType
    {
        [DataMember]
        public string Status { get; set; } = string.Empty;

        [DataMember]
        public DateTime StatusTimestamp { get; set; }

        [DataMember]
        public bool StatusTimestampSpecified { get; set; }
    }

    [DataContract(Name = "NotifyMedicalExaminationStatusRequestHealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestHealthRequirementType
    {
        [DataMember]
        public HealthRequirementMsgType HealthRequirementMsg { get; set; }

        [DataMember]
        public HealthRequirementIdentifierMsgType HealthRequirementIdentifierMsg { get; set; }

        [DataMember]
        public NotifyMedicalExaminationStatusRequestExaminationType Examination { get; set; }
    }

    [DataContract(Name = "NotifyMedicalStatusRequestHealthClientContextType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalStatusRequestHealthClientContextType
    {
        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public string GivenName { get; set; } = string.Empty;

        [DataMember]
        public string FamilyName { get; set; } = string.Empty;

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string Gender { get; set; } = string.Empty;

        [DataMember]
        public string CountryOfBirth { get; set; } = string.Empty;

        [DataMember]
        public string Nationality { get; set; } = string.Empty;

        [DataMember]
        public HealthIdentityDocumentMsgType HealthIdentityDocument { get; set; }

        [DataMember]
        public string EmailAddress { get; set; } = string.Empty;

        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthRequirementMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthRequirementMsgType
    {
        [DataMember]
        public string RequirementCode { get; set; } = string.Empty;

        [DataMember]
        public string RequirementDescription { get; set; } = string.Empty;

        [DataMember]
        public string AssessmentType { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthRequirementIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthRequirementIdentifierMsgType
    {
        [DataMember]
        public string RequirementId { get; set; } = string.Empty;

        [DataMember]
        public string RequirementVersion { get; set; } = string.Empty;
    }

    [DataContract(Name = "NotifyMedicalExaminationStatusRequestExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestExaminationType
    {
        [DataMember]
        public string ExaminationCode { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationDescription { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationStatus { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExaminationDate { get; set; }

        [DataMember]
        public string ExaminationResult { get; set; } = string.Empty;

        [DataMember]
        public string Comments { get; set; } = string.Empty;
    }

    // Supporting complex types for RegisterMedicalExaminationsResultsRequest

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestIdentityDocumentType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestIdentityDocumentType
    {
        [DataMember]
        public string DocumentType { get; set; } = string.Empty;

        [DataMember]
        public string DocumentNumber { get; set; } = string.Empty;

        [DataMember]
        public string IssuingCountry { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [DataMember]
        public DateTime IssueDate { get; set; }

        [DataMember]
        public string DocumentImageData { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthFacialImageMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthFacialImageMsgType
    {
        [DataMember]
        public string ImageData { get; set; } = string.Empty;

        [DataMember]
        public string ImageFormat { get; set; } = string.Empty;

        [DataMember]
        public DateTime ImageCaptureDate { get; set; }

        [DataMember]
        public string ImageQuality { get; set; } = string.Empty;

        [DataMember]
        public int ImageWidth { get; set; }

        [DataMember]
        public int ImageHeight { get; set; }
    }

    [DataContract(Name = "HealthCaseDetailFormType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class HealthCaseDetailFormType
    {
        [DataMember]
        public string FormData { get; set; } = string.Empty;

        [DataMember]
        public string FormType { get; set; } = string.Empty;

        [DataMember]
        public string FormVersion { get; set; } = string.Empty;

        [DataMember]
        public DateTime FormSubmissionDate { get; set; }

        [DataMember]
        public string FormStatus { get; set; } = string.Empty;
    }

    [DataContract(Name = "HealthCaseAttachmentMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseAttachmentMsgType
    {
        [DataMember]
        public string AttachmentId { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentType { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentName { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentData { get; set; } = string.Empty;

        [DataMember]
        public string AttachmentMimeType { get; set; } = string.Empty;

        [DataMember]
        public long AttachmentSize { get; set; }

        [DataMember]
        public DateTime AttachmentCreatedDate { get; set; }
    }

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestHealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestHealthRequirementType
    {
        [DataMember]
        public HealthRequirementMsgType HealthRequirementMsg { get; set; }

        [DataMember]
        public HealthRequirementIdentifierMsgType HealthRequirementIdentifierMsg { get; set; }

        [DataMember]
        public RegisterMedicalExaminationsResultsRequestExaminationType Examination { get; set; }
    }

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestExaminationType
    {
        [DataMember]
        public string ExaminationCode { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationType { get; set; } = string.Empty;

        [DataMember]
        public DateTime ExaminationDate { get; set; }

        [DataMember]
        public string ExaminationResult { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationStatus { get; set; } = string.Empty;

        [DataMember]
        public string DoctorName { get; set; } = string.Empty;

        [DataMember]
        public string ClinicName { get; set; } = string.Empty;

        [DataMember]
        public string ExaminationNotes { get; set; } = string.Empty;

        [DataMember]
        public HealthCaseAttachmentMsgType[] ExaminationAttachments { get; set; }
    }

    // Supporting types for AcknowledgementMessage

    [DataContract(Name = "InformationMessagesType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationMessagesType
    {
        [DataMember]
        public InformationMessageType[] Information { get; set; }
    }

    [DataContract(Name = "InformationMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationMessageType
    {
        [DataMember]
        public string Code { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; }
    }

    [DataContract(Name = "WarningMessagesType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningMessagesType
    {
        [DataMember]
        public WarningMessageType[] Warning { get; set; }
    }

    [DataContract(Name = "WarningMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningMessageType
    {
        [DataMember]
        public string Code { get; set; } = string.Empty;

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public DateTime Timestamp { get; set; }
    }

    [DataContract(Name = "AcknowledgementType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public enum AcknowledgementType
    {
        [EnumMember]
        SUCCESS
    }
}

