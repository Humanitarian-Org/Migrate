using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Diagnostics;

namespace eMedicalService
{
    /// <summary>
    /// Corrected eMedical Integration Service Contract
    /// Based on actual SOAP actions and namespace analysis from sample XML
    /// </summary>
    [ServiceContract(Namespace = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1", 
                     Name = "HealthCase_Ext_PortType_V1_0")]
    public interface IeMedicalIntegrationService
    {
        /// <summary>
        /// Registers a new health case in the system
        /// SOAP Action: http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseRequest
        /// </summary>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseRequest",
                           ReplyAction = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseResponse")]
        RegisterHealthCaseResponseMessage RegisterHealthCaseRequest(RegisterHealthCaseRequestMessage request);

        /// <summary>
        /// Notifies the system of a medical examination status change
        /// SOAP Action: http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyMedicalExaminationStatusRequest
        /// </summary>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyMedicalExaminationStatusRequest",
                           ReplyAction = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyMedicalExaminationStatusResponse")]
        NotifyMedicalExaminationStatusResponseMessage NotifyMedicalExaminationStatusRequest(NotifyMedicalExaminationStatusRequestMessage request);

        /// <summary>
        /// Registers medical examination results for a health case  
        /// SOAP Action: http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterMedicalExaminationsResultsRequest
        /// </summary>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterMedicalExaminationsResultsRequest",
                           ReplyAction = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterMedicalExaminationsResultsResponse")]
        RegisterMedicalExaminationsResultsResponseMessage RegisterMedicalExaminationsResultsRequest(RegisterMedicalExaminationsResultsRequestMessage request);

        /// <summary>
        /// Deletes a cached health case from the system
        /// SOAP Action: http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/DeleteCachedHealthCaseRequest
        /// </summary>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/DeleteCachedHealthCaseRequest",
                           ReplyAction = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/DeleteCachedHealthCaseResponse")]
        DeleteCachedHealthCaseResponseMessage DeleteCachedHealthCaseRequest(DeleteCachedHealthCaseRequestMessage request);

        /// <summary>
        /// Notifies cached health client details update
        /// SOAP Action: http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyCachedHealthClientDetailsUpdateResponse
        /// </summary>
        [OperationContract(Action = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyCachedHealthClientDetailsUpdateResponse",
                           ReplyAction = "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/NotifyCachedHealthClientDetailsUpdateAcknowledgement")]
        AcknowledgementResponseMessage NotifyCachedHealthClientDetailsUpdateResponse(NotifyCachedHealthClientDetailsUpdateRequestMessage request);
    }

    // Request/Response Message Contracts based on sample XML

    [MessageContract(IsWrapped = false)]
    public class RegisterHealthCaseRequestMessage
    {
        [MessageBodyMember(Name = "RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
        public RegisterHealthCaseRequestType Body;
    }

    [MessageContract(IsWrapped = false)]  
    public class RegisterHealthCaseResponseMessage
    {
        [MessageBodyMember(Name = "RegisterHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
        public RegisterHealthCaseResponseType Body;
    }

    // NotifyMedicalExaminationStatus Message Contracts

    [MessageContract(IsWrapped = false)]
    public class NotifyMedicalExaminationStatusRequestMessage
    {
        [MessageBodyMember(Name = "NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public NotifyMedicalExaminationStatusRequestType Body;
    }

    [MessageContract(IsWrapped = false)]
    public class NotifyMedicalExaminationStatusResponseMessage
    {
        [MessageBodyMember(Name = "NotifyMedicalExaminationStatusResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public NotifyMedicalExaminationStatusResponseType Body;
    }

    // RegisterMedicalExaminationsResults Message Contracts

    [MessageContract(IsWrapped = false)]
    public class RegisterMedicalExaminationsResultsRequestMessage
    {
        [MessageBodyMember(Name = "RegisterMedicalExaminationsResultsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public RegisterMedicalExaminationsResultsRequestType Body;
    }

    [MessageContract(IsWrapped = false)]
    public class RegisterMedicalExaminationsResultsResponseMessage
    {
        [MessageBodyMember(Name = "RegisterMedicalExaminationsResultsResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public RegisterMedicalExaminationsResultsResponseType Body;
    }

    // DeleteCachedHealthCase Message Contracts

    [MessageContract(IsWrapped = false)]
    public class DeleteCachedHealthCaseRequestMessage
    {
        [MessageBodyMember(Name = "DeleteCachedHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public DeleteCachedHealthCaseRequestType Body;
    }

    [MessageContract(IsWrapped = false)]
    public class DeleteCachedHealthCaseResponseMessage
    {
        [MessageBodyMember(Name = "DeleteCachedHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public DeleteCachedHealthCaseResponseType Body;
    }

    // NotifyCachedHealthClientDetailsUpdate Message Contracts

    [MessageContract(IsWrapped = false)]
    public class NotifyCachedHealthClientDetailsUpdateRequestMessage
    {
        [MessageBodyMember(Name = "NotifyCachedHealthClientDetailsUpdateResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public NotifyCachedHealthClientDetailsUpdateRequestType Body;
    }

    [MessageContract(IsWrapped = false)]
    public class AcknowledgementResponseMessage
    {
        [MessageBodyMember(Name = "AcknowledgementMessage", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
        public AcknowledgementMessageType Body;
    }

    // Data Contracts matching the sample XML structure

    [DataContract(Name = "RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "CachedCreationDate")]
        [XmlElement("CachedCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedCreationDate { get; set; }

        [DataMember(Order = 2, Name = "HealthCaseIdentifierMsg")]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 3, Name = "HealthClinicIdentifierMsg")]
        [XmlElement("HealthClinicIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthClinicIdentifierMsgType HealthClinicIdentifierMsg { get; set; }

        [DataMember(Order = 4, Name = "RegisterHealthCaseClientBiographicalDetails")]
        public RegisterHealthCaseClientBiographicalDetailsType RegisterHealthCaseClientBiographicalDetails { get; set; }
    }

    [DataContract(Name = "RegisterHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1)]
        public string HealthCaseRegistrationId { get; set; }

        [DataMember(Order = 2)]
        public DateTime ProcessedDateTime { get; set; }

        [DataMember(Order = 3)]
        public string ResponseCode { get; set; }

        [DataMember(Order = 4)]
        public string ResponseMessage { get; set; }
    }

    // Supporting types based on sample XML
    [DataContract(Name = "CachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType
    {
        [DataMember(Name = "UnstructuredYear")]
        [XmlElement("UnstructuredYear", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredYear { get; set; }

        [DataMember(Name = "UnstructuredMonth")]
        [XmlElement("UnstructuredMonth", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredMonth { get; set; }

        [DataMember(Name = "UnstructuredDay")]
        [XmlElement("UnstructuredDay", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredDay { get; set; }

        [DataMember(Name = "UnstructuredHour")]
        [XmlElement("UnstructuredHour", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredHour { get; set; }

        [DataMember(Name = "UnstructuredMinute")]
        [XmlElement("UnstructuredMinute", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredMinute { get; set; }

        [DataMember(Name = "UnstructuredSecond")]
        [XmlElement("UnstructuredSecond", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredSecond { get; set; }
    }

    [DataContract(Name = "HealthCaseIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseIdentifierMsgType
    {
        [DataMember(Name = "HealthCaseIdentifier")]
        [XmlElement("HealthCaseIdentifier", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }
    }

    [DataContract(Name = "HealthCaseIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class HealthCaseIdentifierType
    {
        [DataMember(Name = "HealthCaseIdentifierValue")]
        public string HealthCaseIdentifierValue { get; set; }

        [DataMember(Name = "HealthCaseIdentifierType")]
        public string HealthCaseIdentifierTypeValue { get; set; }
    }

    [DataContract(Name = "HealthClinicIdentifierMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClinicIdentifierMsgType
    {
        [DataMember(Name = "HealthClinicIdentifier")]
        [XmlElement("HealthClinicIdentifier", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthClinicIdentifier { get; set; }

        [DataMember(Name = "HealthClinicIdentifierType")]
        [XmlElement("HealthClinicIdentifierType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthClinicIdentifierType { get; set; }
    }

    [DataContract(Name = "RegisterHealthCaseClientBiographicalDetails", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseClientBiographicalDetailsType
    {
        [DataMember(Name = "GivenName")]
        [XmlElement("GivenName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public string GivenName { get; set; }

        [DataMember(Name = "FamilyName")]
        [XmlElement("FamilyName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
        public string FamilyName { get; set; }

        [DataMember(Name = "SexType")]
        [XmlElement("SexType", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string SexType { get; set; }

        [DataMember(Name = "CachedBirthYear")]
        [XmlElement("CachedBirthYear", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredYearType CachedBirthYear { get; set; }

        [DataMember(Name = "CachedBirthMonth")]
        [XmlElement("CachedBirthMonth", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredMonthType CachedBirthMonth { get; set; }

        [DataMember(Name = "CachedBirthDay")]
        [XmlElement("CachedBirthDay", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDayType CachedBirthDay { get; set; }

        [DataMember(Name = "BirthCountryCode")]
        [XmlElement("BirthCountryCode", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string BirthCountryCode { get; set; }

        [DataMember(Name = "RelationshipToPrimaryApplicant")]
        [XmlElement("RelationshipToPrimaryApplicant", Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
        public string RelationshipToPrimaryApplicant { get; set; }

        [DataMember(Name = "HealthIdentityDocumentMsg")]
        [XmlElement("HealthIdentityDocumentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthIdentityDocumentMsgType HealthIdentityDocumentMsg { get; set; }

        [DataMember(Name = "HealthClientContactListMsg")]
        [XmlElement("HealthClientContactListMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthClientContactListMsgType HealthClientContactListMsg { get; set; }

        [DataMember(Name = "RegisterHealthCaseVisaContext")]
        public RegisterHealthCaseVisaContextType RegisterHealthCaseVisaContext { get; set; }

        [DataMember(Name = "RegisterHealthCaseRequirementList")]
        public RegisterHealthCaseRequirementListType RegisterHealthCaseRequirementList { get; set; }
    }

    // Additional supporting types for biographical details
    [DataContract(Name = "CachedUnstructuredYearType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredYearType
    {
        [DataMember(Name = "UnstructuredYear")]
        [XmlElement("UnstructuredYear", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredYear { get; set; }
    }

    [DataContract(Name = "CachedUnstructuredMonthType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredMonthType
    {
        [DataMember(Name = "UnstructuredMonth")]
        [XmlElement("UnstructuredMonth", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredMonth { get; set; }
    }

    [DataContract(Name = "CachedUnstructuredDayType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDayType
    {
        [DataMember(Name = "UnstructuredDay")]
        [XmlElement("UnstructuredDay", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredDay { get; set; }
    }

    [DataContract(Name = "HealthIdentityDocumentMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthIdentityDocumentMsgType
    {
        [DataMember(Name = "DocumentTypeCode")]
        [XmlElement("DocumentTypeCode", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentTypeCode { get; set; }

        [DataMember(Name = "DocumentNumber")]
        [XmlElement("DocumentNumber", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentNumber { get; set; }

        [DataMember(Name = "IssuingCountryName")]
        [XmlElement("IssuingCountryName", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string IssuingCountryName { get; set; }

        [DataMember(Name = "CachedIssueDate")]
        [XmlElement("CachedIssueDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedIssueDate { get; set; }

        [DataMember(Name = "CachedExpiryDate")]
        [XmlElement("CachedExpiryDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedExpiryDate { get; set; }
    }

    [DataContract(Name = "HealthClientContactListMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClientContactListMsgType
    {
        [DataMember(Name = "HealthClientContactMsg")]
        public HealthClientContactMsgType HealthClientContactMsg { get; set; }
    }

    [DataContract(Name = "HealthClientContactMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthClientContactMsgType
    {
        [DataMember(Name = "UsageCode")]
        [XmlElement("UsageCode", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
        public string UsageCode { get; set; }

        [DataMember(Name = "HealthPrimaryContactFlag")]
        [XmlElement("HealthPrimaryContactFlag", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public bool HealthPrimaryContactFlag { get; set; }

        [DataMember(Name = "HealthLocationMsg")]
        public HealthLocationMsgType HealthLocationMsg { get; set; }
    }

    [DataContract(Name = "HealthLocationMsgType", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthLocationMsgType
    {
        [DataMember(Name = "AddressLine1")]
        [XmlElement("AddressLine1", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "ProvinceName")]
        [XmlElement("ProvinceName", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
        public string ProvinceName { get; set; }

        [DataMember(Name = "CountryCode")]
        [XmlElement("CountryCode", Namespace = "http://www.immi.gov.au/Namespace/Address/Core/V1.0")]
        public string CountryCode { get; set; }
    }

    [DataContract(Name = "RegisterHealthCaseVisaContextType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseVisaContextType
    {
        [DataMember(Name = "HealthVisaContextType")]
        [XmlElement("HealthVisaContextType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthVisaContextType { get; set; }

        [DataMember(Name = "HealthVisaContextValue")]
        [XmlElement("HealthVisaContextValue", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthVisaContextValue { get; set; }
    }

    [DataContract(Name = "RegisterHealthCaseRequirementListType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequirementListType
    {
        [DataMember(Name = "RegisterHealthCaseRequirement")]
        public RegisterHealthCaseRequirementType[] RegisterHealthCaseRequirement { get; set; }
    }

    [DataContract(Name = "RegisterHealthCaseRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequirementType
    {
        [DataMember(Name = "HealthRequirementType")]
        [XmlElement("HealthRequirementType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthRequirementType { get; set; }

        [DataMember(Name = "CachedCreatedTimestamp")]
        [XmlElement("CachedCreatedTimestamp", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedCreatedTimestamp { get; set; }

        [DataMember(Name = "HealthRequirementStatusCode")]
        [XmlElement("HealthRequirementStatusCode", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string HealthRequirementStatusCode { get; set; }

        [DataMember(Name = "CachedStatusTimestamp")]
        [XmlElement("CachedStatusTimestamp", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedStatusTimestamp { get; set; }
    }

    // Data Contracts for NotifyMedicalExaminationStatus

    [DataContract(Name = "NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2, Name = "ExaminationStatus")]
        [XmlElement("ExaminationStatus", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string ExaminationStatus { get; set; }

        [DataMember(Order = 3, Name = "StatusTimestamp")]
        [XmlElement("StatusTimestamp", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType StatusTimestamp { get; set; }
    }

    [DataContract(Name = "NotifyMedicalExaminationStatusResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1)]
        public string ResponseCode { get; set; }

        [DataMember(Order = 2)]
        public string ResponseMessage { get; set; }

        [DataMember(Order = 3)]
        public DateTime ProcessedDateTime { get; set; }
    }

    // Data Contracts for RegisterMedicalExaminationsResults

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2, Name = "RegisterMedicalExaminationsResultsRequestIdentityDocument")]
        public RegisterMedicalExaminationsResultsRequestIdentityDocumentType RegisterMedicalExaminationsResultsRequestIdentityDocument { get; set; }

        [DataMember(Order = 3, Name = "HealthFacialImageMsg")]
        [XmlElement("HealthFacialImageMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthFacialImageMsgType HealthFacialImageMsg { get; set; }

        [DataMember(Order = 4, Name = "HealthCaseDetailForm")]
        public HealthCaseDetailFormType HealthCaseDetailForm { get; set; }

        [DataMember(Order = 5, Name = "HealthCaseAttachmentMsg")]
        [XmlElement("HealthCaseAttachmentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseAttachmentMsgType[] HealthCaseAttachmentMsg { get; set; }
    }

    [DataContract(Name = "RegisterMedicalExaminationsResultsResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1)]
        public string ResultsRegistrationId { get; set; }

        [DataMember(Order = 2)]
        public DateTime ProcessedDateTime { get; set; }

        [DataMember(Order = 3)]
        public string ResponseCode { get; set; }

        [DataMember(Order = 4)]
        public string ResponseMessage { get; set; }
    }

    // Data Contracts for DeleteCachedHealthCase

    [DataContract(Name = "DeleteCachedHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2, Name = "DeletionReason")]
        [XmlElement("DeletionReason", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string DeletionReason { get; set; }
    }

    [DataContract(Name = "DeleteCachedHealthCaseResponse", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class DeleteCachedHealthCaseResponseType
    {
        [DataMember(Order = 0)]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1)]
        public string ResponseCode { get; set; }

        [DataMember(Order = 2)]
        public string ResponseMessage { get; set; }

        [DataMember(Order = 3)]
        public DateTime ProcessedDateTime { get; set; }
    }

    // Data Contracts for NotifyCachedHealthClientDetailsUpdate

    [DataContract(Name = "NotifyCachedHealthClientDetailsUpdateRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyCachedHealthClientDetailsUpdateRequestType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "HealthCaseIdentifierMsg")]
        [XmlElement("HealthCaseIdentifierMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthCaseIdentifierMsgType[] HealthCaseIdentifierMsg { get; set; }

        [DataMember(Order = 2, Name = "ClientDetails")]
        public object ClientDetails { get; set; } // Placeholder - would need actual structure from XML samples
    }

    // Common Acknowledgement Message

    [DataContract(Name = "AcknowledgementMessage", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class AcknowledgementMessageType
    {
        [DataMember(Order = 0, Name = "CorrelationID")]
        [XmlElement("CorrelationID", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string CorrelationID { get; set; }

        [DataMember(Order = 1, Name = "AcknowledgementCode")]
        [XmlElement("AcknowledgementCode", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string AcknowledgementCode { get; set; }

        [DataMember(Order = 2, Name = "AcknowledgementText")]
        [XmlElement("AcknowledgementText", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public string AcknowledgementText { get; set; }

        [DataMember(Order = 3, Name = "ProcessedDateTime")]
        [XmlElement("ProcessedDateTime", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public DateTime ProcessedDateTime { get; set; }
    }

    // Additional Supporting Types for RegisterMedicalExaminationsResults

    [DataContract(Name = "RegisterMedicalExaminationsResultsRequestIdentityDocument", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class RegisterMedicalExaminationsResultsRequestIdentityDocumentType
    {
        [DataMember(Name = "DocumentTypeCode")]
        [XmlElement("DocumentTypeCode", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentTypeCode { get; set; }

        [DataMember(Name = "DocumentNumber")]
        [XmlElement("DocumentNumber", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string DocumentNumber { get; set; }

        [DataMember(Name = "IssuingCountryName")]
        [XmlElement("IssuingCountryName", Namespace = "http://www.immi.gov.au/Namespace/Document/Core/V1.0")]
        public string IssuingCountryName { get; set; }

        [DataMember(Name = "CachedIssueDate")]
        [XmlElement("CachedIssueDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedIssueDate { get; set; }

        [DataMember(Name = "CachedExpiryDate")]
        [XmlElement("CachedExpiryDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public CachedUnstructuredDateType CachedExpiryDate { get; set; }

        [DataMember(Name = "IdentityDocumentedPresentedFlag")]
        [XmlElement("IdentityDocumentedPresentedFlag", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public bool IdentityDocumentedPresentedFlag { get; set; }

        [DataMember(Name = "IdentityConcernsFlag")]
        [XmlElement("IdentityConcernsFlag", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
        public bool IdentityConcernsFlag { get; set; }
    }

    [DataContract(Name = "HealthFacialImageMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthFacialImageMsgType
    {
        [DataMember(Name = "HealthPhotoAttachedMsg")]
        public HealthPhotoAttachedMsgType HealthPhotoAttachedMsg { get; set; }
    }

    [DataContract(Name = "HealthPhotoAttachedMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthPhotoAttachedMsgType
    {
        [DataMember(Name = "AttachmentType")]
        public string AttachmentType { get; set; }

        [DataMember(Name = "AttachmentName")]
        public string AttachmentName { get; set; }

        [DataMember(Name = "AttachmentContent")]
        public byte[] AttachmentContent { get; set; }
    }

    [DataContract(Name = "HealthCaseDetailForm", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class HealthCaseDetailFormType
    {
        [DataMember(Name = "HealthFormMsg")]
        [XmlElement("HealthFormMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
        public HealthFormMsgType HealthFormMsg { get; set; }
    }

    [DataContract(Name = "HealthFormMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthFormMsgType
    {
        [DataMember(Name = "FormType")]
        public string FormType { get; set; }

        [DataMember(Name = "FormData")]
        public object FormData { get; set; } // Placeholder - would need actual structure from XML samples
    }

    [DataContract(Name = "HealthCaseAttachmentMsg", Namespace = "http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
    public class HealthCaseAttachmentMsgType
    {
        [DataMember(Name = "AttachmentType")]
        public string AttachmentType { get; set; }

        [DataMember(Name = "AttachmentName")]
        public string AttachmentName { get; set; }

        [DataMember(Name = "AttachmentContent")]
        public byte[] AttachmentContent { get; set; }

        [DataMember(Name = "AttachmentDescription")]
        public string AttachmentDescription { get; set; }
    }
}