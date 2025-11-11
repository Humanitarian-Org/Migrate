using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using eMedicalService.Contracts.Health.Service;
using eMedicalService.Contracts.Health.Messaging;
using eMedicalService.Contracts.Health.Core;
using eMedicalService.Contracts.Enterprise;

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
        [XmlSerializerFormat]
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
}
