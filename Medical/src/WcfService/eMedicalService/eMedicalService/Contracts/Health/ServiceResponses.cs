using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise.Core.V1;
using eMedicalService.Contracts.Health.Core.V1;

namespace eMedicalService.Contracts.Health.Messaging.Service.V1
{
    /// <summary>
    /// Standard acknowledgement response
    /// </summary>
    [DataContract(Name = "acknowledgementResponseType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    [XmlType(TypeName = "acknowledgementResponseType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public class AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("AcknowledgementType")]
        public AcknowledgementType AcknowledgementType { get; set; }

        [DataMember]
        [XmlElement("MessageId")]
        public string MessageId { get; set; }

        [DataMember]
        [XmlElement("ProcessingDateTime")]
        public DateTime ProcessingDateTime { get; set; }

        [DataMember]
        [XmlElement("ResponseMessage")]
        public string ResponseMessage { get; set; }

        [DataMember]
        [XmlElement("ErrorDetails")]
        public string ErrorDetails { get; set; }
    }

    /// <summary>
    /// Cache health case details response
    /// </summary>
    [DataContract(Name = "cacheHealthCaseDetailsResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "cacheHealthCaseDetailsResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class CacheHealthCaseDetailsResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("CacheKey")]
        public string CacheKey { get; set; }

        [DataMember]
        [XmlElement("CacheExpirationDateTime")]
        public DateTime? CacheExpirationDateTime { get; set; }
    }

    /// <summary>
    /// Get cached health case response
    /// </summary>
    [DataContract(Name = "getCachedHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "getCachedHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class GetCachedHealthCaseResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("HealthCase")]
        public HealthCaseType HealthCase { get; set; }

        [DataMember]
        [XmlElement("CacheRetrievalDateTime")]
        public DateTime CacheRetrievalDateTime { get; set; }
    }

    /// <summary>
    /// Get health case status response
    /// </summary>
    [DataContract(Name = "getHealthCaseStatusResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "getHealthCaseStatusResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class GetHealthCaseStatusResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("OverallHealthCaseStatus")]
        public string OverallHealthCaseStatus { get; set; }

        [DataMember]
        [XmlElement("MedicalExaminationStatuses")]
        public List<MedicalExaminationType> MedicalExaminationStatuses { get; set; }

        [DataMember]
        [XmlElement("LastUpdateDateTime")]
        public DateTime LastUpdateDateTime { get; set; }

        public GetHealthCaseStatusResponseType()
        {
            MedicalExaminationStatuses = new List<MedicalExaminationType>();
        }
    }

    /// <summary>
    /// Register health case response
    /// </summary>
    [DataContract(Name = "registerHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "registerHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class RegisterHealthCaseResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("HealthCaseIdentifier")]
        public HealthCaseIdentifierType HealthCaseIdentifier { get; set; }

        [DataMember]
        [XmlElement("RegistrationDateTime")]
        public DateTime RegistrationDateTime { get; set; }
    }

    /// <summary>
    /// Notify medical examination status response
    /// </summary>
    [DataContract(Name = "notifyMedicalExaminationStatusResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "notifyMedicalExaminationStatusResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class NotifyMedicalExaminationStatusResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("StatusUpdateDateTime")]
        public DateTime StatusUpdateDateTime { get; set; }
    }

    /// <summary>
    /// Register medical examinations results response
    /// </summary>
    [DataContract(Name = "registerMedicalExaminationsResultsResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "registerMedicalExaminationsResultsResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class RegisterMedicalExaminationsResultsResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("ResultsProcessingDateTime")]
        public DateTime ResultsProcessingDateTime { get; set; }

        [DataMember]
        [XmlElement("ProcessedExaminationCount")]
        public int ProcessedExaminationCount { get; set; }
    }

    /// <summary>
    /// Delete cached health case response
    /// </summary>
    [DataContract(Name = "deleteCachedHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "deleteCachedHealthCaseResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class DeleteCachedHealthCaseResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("DeletionDateTime")]
        public DateTime DeletionDateTime { get; set; }
    }

    /// <summary>
    /// Update medical examination response
    /// </summary>
    [DataContract(Name = "updateMedicalExaminationResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    [XmlType(TypeName = "updateMedicalExaminationResponseType", Namespace = "http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0")]
    public class UpdateMedicalExaminationResponseType : AcknowledgementResponseType
    {
        [DataMember]
        [XmlElement("UpdateProcessingDateTime")]
        public DateTime UpdateProcessingDateTime { get; set; }
    }
}