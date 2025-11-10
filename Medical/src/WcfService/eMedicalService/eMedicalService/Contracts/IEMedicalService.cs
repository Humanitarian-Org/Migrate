using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts
{
    /// <summary>
    /// eMedical Service Contract - Main interface for medical operations
    /// Based on WSDL: https://api-test.iom.int/eMedicalInterface/services/eMedicalPort12?wsdl
    /// </summary>
    [ServiceContract(
        Name = "eMedicalPortType", 
        Namespace = "urn:iom.org/mimosa/medical/aus/v1",
        ConfigurationName = "eMedicalPortType")]
    public interface IEMedicalService
    {
        /// <summary>
        /// Register a new health case
        /// </summary>
        [OperationContract(Action = "RegisterHealthCase")]
        [FaultContract(typeof(EnterpriseErrors))]
        AcknowledgementMessage RegisterHealthCase(RegisterHealthCaseRequest request);

        /// <summary>
        /// Notify medical examination status
        /// </summary>
        [OperationContract(Action = "NotifyMedicalExaminationStatus")]
        [FaultContract(typeof(EnterpriseErrors))]
        AcknowledgementMessage NotifyMedicalExaminationStatus(NotifyMedicalExaminationStatusRequest request);

        /// <summary>
        /// Delete cached health case
        /// </summary>
        [OperationContract(Action = "DeleteCachedHealthCase")]
        [FaultContract(typeof(EnterpriseErrors))]
        AcknowledgementMessage DeleteCachedHealthCase(DeleteCachedHealthCaseRequest request);

        /// <summary>
        /// Register medical examinations results
        /// </summary>
        [OperationContract(Action = "RegisterMedicalExaminationsResults")]
        [FaultContract(typeof(EnterpriseErrors))]
        AcknowledgementMessage RegisterMedicalExaminationsResults(RegisterMedicalExaminationsResultsRequest request);

        /// <summary>
        /// Notify cached health client details update response
        /// </summary>
        [OperationContract(Action = "NotifyCachedHealthClientDetailsUpdateResponse")]
        [FaultContract(typeof(EnterpriseErrors))]
        AcknowledgementMessage NotifyCachedHealthClientDetailsUpdateResponse(NotifyCachedHealthClientDetailsUpdateResponse request);
    }

    // Basic data contracts based on the WSDL structure
    
    [DataContract(Name = "RegisterHealthCaseRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseRequest
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;
        
        [DataMember]
        public string CaseId { get; set; } = string.Empty;
        
        [DataMember]
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }

    [DataContract(Name = "NotifyMedicalExaminationStatusRequest", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
    public class NotifyMedicalExaminationStatusRequest
    {
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;
        
        [DataMember]
        public string Status { get; set; } = string.Empty;
        
        [DataMember]
        public DateTime StatusTimestamp { get; set; } = DateTime.UtcNow;
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
        [DataMember]
        public string CorrelationId { get; set; } = string.Empty;
        
        [DataMember]
        public string ExaminationResults { get; set; } = string.Empty;
        
        [DataMember]
        public DateTime ResultTimestamp { get; set; } = DateTime.UtcNow;
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
        [DataMember]
        public string MessageId { get; set; } = string.Empty;
        
        [DataMember]
        public string Status { get; set; } = string.Empty;
        
        [DataMember]
        public string Message { get; set; } = string.Empty;
        
        [DataMember]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
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
}