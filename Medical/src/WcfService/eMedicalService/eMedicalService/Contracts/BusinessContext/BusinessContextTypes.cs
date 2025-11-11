using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Enumeration for lodgement channel types
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public enum LodgementChannelTypeType
    {
        /// <summary>
        /// Paper-based lodgement channel
        /// </summary>
        [EnumMember]
        PAPER,

        /// <summary>
        /// Electronic lodgement channel
        /// </summary>
        [EnumMember]
        ELECTRONIC,

        /// <summary>
        /// Data load lodgement channel
        /// </summary>
        [EnumMember]
        DATALOAD
    }

    /// <summary>
    /// Business context type for business process identification and management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessContextType
    {
        /// <summary>
        /// Unique identifier for the business context
        /// </summary>
        [DataMember]
        public string BusinessContextId { get; set; }

        /// <summary>
        /// Type classification of the business context
        /// </summary>
        [DataMember]
        public string BusinessContextType_Value { get; set; }

        /// <summary>
        /// Optional sub-type classification
        /// </summary>
        [DataMember]
        public string BusinessContextSubType { get; set; }

        /// <summary>
        /// Optional container identifier for grouping contexts
        /// </summary>
        [DataMember]
        public string BusinessContextContainerId { get; set; }
    }

    /// <summary>
    /// Business service identifier type for service identification
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdentifierType
    {
        /// <summary>
        /// Value of the business service identifier
        /// </summary>
        [DataMember]
        public string BusinessServiceIdValue { get; set; }

        /// <summary>
        /// Type of the business service identifier
        /// </summary>
        [DataMember]
        public string BusinessServiceIdType { get; set; }
    }

    /// <summary>
    /// Business service ID type for service management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdType
    {
        /// <summary>
        /// Business service identifier details
        /// </summary>
        [DataMember]
        public BusinessServiceIdentifierType BusinessServiceIdentifier { get; set; }

        /// <summary>
        /// Service activation status
        /// </summary>
        [DataMember]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Service effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }
    }

    /// <summary>
    /// List of business service IDs
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdListType
    {
        /// <summary>
        /// Collection of business service IDs
        /// </summary>
        [DataMember]
        public List<BusinessServiceIdType> BusinessServiceId { get; set; } = new List<BusinessServiceIdType>();
    }

    /// <summary>
    /// List of business service identifiers
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceIdentifierListType
    {
        /// <summary>
        /// Collection of business service identifiers
        /// </summary>
        [DataMember]
        public List<BusinessServiceIdentifierType> BusinessServiceIdentifier { get; set; } = new List<BusinessServiceIdentifierType>();
    }

    /// <summary>
    /// Business service classifier type for service categorization
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessServiceClassifierType
    {
        /// <summary>
        /// Classification code for the service
        /// </summary>
        [DataMember]
        public string ServiceClassificationCode { get; set; }

        /// <summary>
        /// Classification type for the service
        /// </summary>
        [DataMember]
        public string ServiceClassificationType { get; set; }

        /// <summary>
        /// Description of the service classification
        /// </summary>
        [DataMember]
        public string ServiceClassificationDescription { get; set; }
    }

    /// <summary>
    /// Business event type for business process event tracking
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessEventType
    {
        /// <summary>
        /// Type of business event
        /// </summary>
        [DataMember]
        public string BusinessEventType_Value { get; set; }

        /// <summary>
        /// Optional qualifier for the business event
        /// </summary>
        [DataMember]
        public string BusinessEventQualifierType { get; set; }
    }

    /// <summary>
    /// List of business events
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessEventListType
    {
        /// <summary>
        /// Collection of business events
        /// </summary>
        [DataMember]
        public List<BusinessEventType> BusinessEvent { get; set; } = new List<BusinessEventType>();
    }

    /// <summary>
    /// Business workflow type for workflow management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessWorkflowType
    {
        /// <summary>
        /// Workflow identifier
        /// </summary>
        [DataMember]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Workflow name or title
        /// </summary>
        [DataMember]
        public string WorkflowName { get; set; }

        /// <summary>
        /// Current workflow status
        /// </summary>
        [DataMember]
        public string WorkflowStatus { get; set; }

        /// <summary>
        /// Business context associated with the workflow
        /// </summary>
        [DataMember]
        public BusinessContextType BusinessContext { get; set; }

        /// <summary>
        /// Events associated with the workflow
        /// </summary>
        [DataMember]
        public BusinessEventListType WorkflowEvents { get; set; }

        /// <summary>
        /// Lodgement channel used for the workflow
        /// </summary>
        [DataMember]
        public LodgementChannelTypeType? LodgementChannel { get; set; }
    }

    /// <summary>
    /// Business rule type for business rule management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessRuleType
    {
        /// <summary>
        /// Unique rule identifier
        /// </summary>
        [DataMember]
        public string RuleId { get; set; }

        /// <summary>
        /// Rule name or title
        /// </summary>
        [DataMember]
        public string RuleName { get; set; }

        /// <summary>
        /// Rule description
        /// </summary>
        [DataMember]
        public string RuleDescription { get; set; }

        /// <summary>
        /// Rule category or type
        /// </summary>
        [DataMember]
        public string RuleCategory { get; set; }

        /// <summary>
        /// Rule execution priority
        /// </summary>
        [DataMember]
        public int? RulePriority { get; set; }

        /// <summary>
        /// Rule active status
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Rule effective date
        /// </summary>
        [DataMember]
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Rule expiry date
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Business context where the rule applies
        /// </summary>
        [DataMember]
        public BusinessContextType ApplicableContext { get; set; }
    }

    /// <summary>
    /// List of business rules
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessRuleListType
    {
        /// <summary>
        /// Collection of business rules
        /// </summary>
        [DataMember]
        public List<BusinessRuleType> BusinessRule { get; set; } = new List<BusinessRuleType>();
    }

    /// <summary>
    /// Business context request type for context operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessContextRequestType
    {
        /// <summary>
        /// Business context information
        /// </summary>
        [DataMember]
        public BusinessContextType BusinessContext { get; set; }

        /// <summary>
        /// Business service identifiers
        /// </summary>
        [DataMember]
        public BusinessServiceIdentifierListType ServiceIdentifiers { get; set; }

        /// <summary>
        /// Business workflow information
        /// </summary>
        [DataMember]
        public BusinessWorkflowType Workflow { get; set; }

        /// <summary>
        /// Request timestamp
        /// </summary>
        [DataMember]
        public DateTime RequestTimestamp { get; set; }

        /// <summary>
        /// Requesting user or system identifier
        /// </summary>
        [DataMember]
        public string RequestorId { get; set; }
    }
}