using eMedicalService.Contracts.Enterprise.InformationMessages.V1;
using eMedicalService.Contracts.Enterprise.WarningMessages.V1;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Enterprise.AcknowledgementMessage.V1
{
    /// <summary>
    /// Acknowledgement message type containing information, warnings and acknowledgement
    /// </summary>
    [DataContract(Name = "acknowledgementMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    [XmlType(TypeName = "acknowledgementMessageType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public class AcknowledgementMessageType
    {
        [DataMember(Order = 0)]
        [XmlElement("Informations", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
        public InformationsType Informations { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("Warnings", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
        public WarningsType Warnings { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("Acknowledgement")]
        public AcknowledgementType Acknowledgement { get; set; }
    }

    /// <summary>
    /// Acknowledgement type enumeration
    /// </summary>
    [DataContract(Name = "acknowledgementType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public enum AcknowledgementType
    {
        [EnumMember]
        SUCCESS
    }
}

namespace eMedicalService.Contracts.Enterprise.InformationMessages.V1
{
    /// <summary>
    /// Container for multiple information messages
    /// </summary>
    [DataContract(Name = "informationsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    [XmlType(TypeName = "informationsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    [XmlRoot("Informations", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationsType
    {
        [DataMember(IsRequired = true)]
        [XmlElement("Information")]
        public List<InformationType> Information { get; set; }

        public InformationsType()
        {
            Information = new List<InformationType>();
        }
    }

    /// <summary>
    /// Individual information message
    /// </summary>
    [DataContract(Name = "informationType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    [XmlType(TypeName = "informationType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
    public class InformationType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("InformationCode", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string InformationCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string OriginatorName { get; set; }
    }
}

namespace eMedicalService.Contracts.Enterprise.WarningMessages.V1
{
    /// <summary>
    /// Container for multiple warning messages
    /// </summary>
    [DataContract(Name = "warningsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    [XmlType(TypeName = "warningsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    [XmlRoot("Warnings", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningsType
    {
        [DataMember(IsRequired = true)]
        [XmlElement("Warning")]
        public List<WarningType> Warning { get; set; }

        public WarningsType()
        {
            Warning = new List<WarningType>();
        }
    }

    /// <summary>
    /// Individual warning message
    /// </summary>
    [DataContract(Name = "warningType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    [XmlType(TypeName = "warningType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
    public class WarningType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("WarningCode", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string WarningCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
        public string OriginatorName { get; set; }
    }
}

namespace eMedicalService.Contracts.Enterprise.ErrorMessages.V1
{
    /// <summary>
    /// Enterprise errors type containing validation, logic, system and security errors
    /// </summary>
    [DataContract(Name = "enterpriseErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "enterpriseErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class EnterpriseErrorsType
    {
        [DataMember(Order = 0)]
        [XmlElement("ValidationErrors")]
        public ValidationErrorsType ValidationErrors { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LogicErrors")]
        public LogicErrorsType LogicErrors { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("SystemErrors")]
        public SystemErrorsType SystemErrors { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("SecurityErrors")]
        public SecurityErrorsType SecurityErrors { get; set; }
    }

    /// <summary>
    /// Container for validation errors
    /// </summary>
    [DataContract(Name = "validationErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "validationErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class ValidationErrorsType
    {
        [DataMember]
        [XmlElement("ValidationError")]
        public List<ValidationErrorType> ValidationError { get; set; }

        public ValidationErrorsType()
        {
            ValidationError = new List<ValidationErrorType>();
        }
    }

    /// <summary>
    /// Individual validation error
    /// </summary>
    [DataContract(Name = "validationErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "validationErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class ValidationErrorType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("ValidationErrorCode")]
        public string ValidationErrorCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName")]
        public string OriginatorName { get; set; }
    }

    /// <summary>
    /// Container for logic errors
    /// </summary>
    [DataContract(Name = "logicErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "logicErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class LogicErrorsType
    {
        [DataMember]
        [XmlElement("LogicError")]
        public List<LogicErrorType> LogicError { get; set; }

        public LogicErrorsType()
        {
            LogicError = new List<LogicErrorType>();
        }
    }

    /// <summary>
    /// Individual logic error
    /// </summary>
    [DataContract(Name = "logicErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "logicErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class LogicErrorType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("LogicErrorCode")]
        public string LogicErrorCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName")]
        public string OriginatorName { get; set; }
    }

    /// <summary>
    /// Container for system errors
    /// </summary>
    [DataContract(Name = "systemErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "systemErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class SystemErrorsType
    {
        [DataMember]
        [XmlElement("SystemError")]
        public List<SystemErrorType> SystemError { get; set; }

        public SystemErrorsType()
        {
            SystemError = new List<SystemErrorType>();
        }
    }

    /// <summary>
    /// Individual system error
    /// </summary>
    [DataContract(Name = "systemErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "systemErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class SystemErrorType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("SystemErrorCode")]
        public string SystemErrorCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName")]
        public string OriginatorName { get; set; }
    }

    /// <summary>
    /// Container for security errors
    /// </summary>
    [DataContract(Name = "securityErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "securityErrorsType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class SecurityErrorsType
    {
        [DataMember]
        [XmlElement("SecurityError")]
        public List<SecurityErrorType> SecurityError { get; set; }

        public SecurityErrorsType()
        {
            SecurityError = new List<SecurityErrorType>();
        }
    }

    /// <summary>
    /// Individual security error
    /// </summary>
    [DataContract(Name = "securityErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    [XmlType(TypeName = "securityErrorType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
    public class SecurityErrorType
    {
        [DataMember(Order = 0)]
        [XmlElement("AdditionalDetailText")]
        public string AdditionalDetailText { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("LocationText")]
        public string LocationText { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("DescriptionText")]
        public string DescriptionText { get; set; }

        [DataMember(Order = 3, IsRequired = true)]
        [XmlElement("SecurityErrorCode")]
        public string SecurityErrorCode { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        [XmlElement("OriginatorLocation")]
        public string OriginatorLocation { get; set; }

        [DataMember(Order = 5, IsRequired = true)]
        [XmlElement("OriginatorName")]
        public string OriginatorName { get; set; }
    }
}