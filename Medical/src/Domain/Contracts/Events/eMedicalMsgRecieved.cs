using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Medical.Domain.Contracts.Events
{
    public class eMedicalMsgRecieved
    {
        // Raw SOAP XML stored as string for reliable NServiceBus serialization
        // Will be parsed to XDocument in the handler
        [XmlElement("SoapEnvelope")]
        public string SoapEnvelope { get; set; }
        
        // Base64-encoded SOAP XML for bit-perfect preservation (including signatures)
        // Preferred over SoapEnvelope when SOAP signatures must be validated
        [XmlElement("SoapEnvelopeBase64")]
        public string SoapEnvelopeBase64 { get; set; }
    }

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class enterpriseErrorsType
{
    
    private object[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LogicErrors", typeof(logicErrorsType), Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("SecurityErrors", typeof(securityErrorsType), Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("SystemErrors", typeof(systemErrorsType), Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("ValidationErrors", typeof(validationErrorsType), Order=0)]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class logicErrorsType
{
    
    private logicErrorType[] logicErrorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LogicError", Order=0)]
    public logicErrorType[] LogicError
    {
        get
        {
            return this.logicErrorField;
        }
        set
        {
            this.logicErrorField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class logicErrorType
{
    
    private string originatorNameField;
    
    private string originatorLocationField;
    
    private string errorCodeField;
    
    private string descriptionTextField;
    
    private string locationTextField;
    
    private string additionalDetailTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=1)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=2)]
    public string ErrorCode
    {
        get
        {
            return this.errorCodeField;
        }
        set
        {
            this.errorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=3)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=4)]
    public string LocationText
    {
        get
        {
            return this.locationTextField;
        }
        set
        {
            this.locationTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=5)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class validationErrorsType
{
    
    private validationErrorType[] validationErrorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ValidationError", Order=0)]
    public validationErrorType[] ValidationError
    {
        get
        {
            return this.validationErrorField;
        }
        set
        {
            this.validationErrorField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class validationErrorType
{
    
    private string originatorNameField;
    
    private string originatorLocationField;
    
    private string errorCodeField;
    
    private string descriptionTextField;
    
    private string locationTextField;
    
    private string additionalDetailTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=1)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=2)]
    public string ErrorCode
    {
        get
        {
            return this.errorCodeField;
        }
        set
        {
            this.errorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=3)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=4)]
    public string LocationText
    {
        get
        {
            return this.locationTextField;
        }
        set
        {
            this.locationTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=5)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class systemErrorsType
{
    
    private systemErrorType[] systemErrorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SystemError", Order=0)]
    public systemErrorType[] SystemError
    {
        get
        {
            return this.systemErrorField;
        }
        set
        {
            this.systemErrorField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class systemErrorType
{
    
    private string originatorNameField;
    
    private string originatorLocationField;
    
    private string errorCodeField;
    
    private string descriptionTextField;
    
    private string additionalDetailTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=1)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=2)]
    public string ErrorCode
    {
        get
        {
            return this.errorCodeField;
        }
        set
        {
            this.errorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=3)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=4)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class securityErrorsType
{
    
    private securityErrorType[] securityErrorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SecurityError", Order=0)]
    public securityErrorType[] SecurityError
    {
        get
        {
            return this.securityErrorField;
        }
        set
        {
            this.securityErrorField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0")]
public partial class securityErrorType
{
    
    private string originatorNameField;
    
    private string originatorLocationField;
    
    private string errorCodeField;
    
    private string descriptionTextField;
    
    private string additionalDetailTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=1)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=2)]
    public string ErrorCode
    {
        get
        {
            return this.errorCodeField;
        }
        set
        {
            this.errorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=3)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=4)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0")]
public partial class warningType
{
    
    private string additionalDetailTextField;
    
    private string locationTextField;
    
    private string descriptionTextField;
    
    private string warningCodeField;
    
    private string originatorLocationField;
    
    private string originatorNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=0)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=1)]
    public string LocationText
    {
        get
        {
            return this.locationTextField;
        }
        set
        {
            this.locationTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=2)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=3)]
    public string WarningCode
    {
        get
        {
            return this.warningCodeField;
        }
        set
        {
            this.warningCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=4)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=5)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0")]
public partial class informationType
{
    
    private string additionalDetailTextField;
    
    private string locationTextField;
    
    private string descriptionTextField;
    
    private string informationCodeField;
    
    private string originatorLocationField;
    
    private string originatorNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=0)]
    public string AdditionalDetailText
    {
        get
        {
            return this.additionalDetailTextField;
        }
        set
        {
            this.additionalDetailTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=1)]
    public string LocationText
    {
        get
        {
            return this.locationTextField;
        }
        set
        {
            this.locationTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=2)]
    public string DescriptionText
    {
        get
        {
            return this.descriptionTextField;
        }
        set
        {
            this.descriptionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=3)]
    public string InformationCode
    {
        get
        {
            return this.informationCodeField;
        }
        set
        {
            this.informationCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=4)]
    public string OriginatorLocation
    {
        get
        {
            return this.originatorLocationField;
        }
        set
        {
            this.originatorLocationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/ErrorMessages/V1.0", DataType="token", Order=5)]
    public string OriginatorName
    {
        get
        {
            return this.originatorNameField;
        }
        set
        {
            this.originatorNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
public partial class acknowledgementMessageType
{
    
    private informationType[] informationsField;
    
    private warningType[] warningsField;
    
    private acknowledgementType acknowledgementField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/InformationMessages/V1.0", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Information", IsNullable=false)]
    public informationType[] Informations
    {
        get
        {
            return this.informationsField;
        }
        set
        {
            this.informationsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/WarningMessages/V1.0", Order=1)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Warning", IsNullable=false)]
    public warningType[] Warnings
    {
        get
        {
            return this.warningsField;
        }
        set
        {
            this.warningsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public acknowledgementType Acknowledgement
    {
        get
        {
            return this.acknowledgementField;
        }
        set
        {
            this.acknowledgementField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
public enum acknowledgementType
{
    
    /// <remarks/>
    SUCCESS,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedUnstructuredDateTimeType
{
    
    private string unstructuredYearField;
    
    private string unstructuredMonthField;
    
    private string unstructuredDayField;
    
    private string unstructuredHourField;
    
    private string unstructuredMinuteField;
    
    private string unstructuredSecondField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=0)]
    public string UnstructuredYear
    {
        get
        {
            return this.unstructuredYearField;
        }
        set
        {
            this.unstructuredYearField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=1)]
    public string UnstructuredMonth
    {
        get
        {
            return this.unstructuredMonthField;
        }
        set
        {
            this.unstructuredMonthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=2)]
    public string UnstructuredDay
    {
        get
        {
            return this.unstructuredDayField;
        }
        set
        {
            this.unstructuredDayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=3)]
    public string UnstructuredHour
    {
        get
        {
            return this.unstructuredHourField;
        }
        set
        {
            this.unstructuredHourField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=4)]
    public string UnstructuredMinute
    {
        get
        {
            return this.unstructuredMinuteField;
        }
        set
        {
            this.unstructuredMinuteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=5)]
    public string UnstructuredSecond
    {
        get
        {
            return this.unstructuredSecondField;
        }
        set
        {
            this.unstructuredSecondField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
public partial class registerHealthCaseRequirementType
{
    
    private string healthRequirementTypeField;
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    private string healthRequirementStatusCodeField;
    
    private cachedUnstructuredDateTimeType cachedStatusTimestampField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="integer", Order=0)]
    public string HealthRequirementType
    {
        get
        {
            return this.healthRequirementTypeField;
        }
        set
        {
            this.healthRequirementTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=2)]
    public string HealthRequirementStatusCode
    {
        get
        {
            return this.healthRequirementStatusCodeField;
        }
        set
        {
            this.healthRequirementStatusCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=3)]
    public cachedUnstructuredDateTimeType CachedStatusTimestamp
    {
        get
        {
            return this.cachedStatusTimestampField;
        }
        set
        {
            this.cachedStatusTimestampField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
public partial class registerHealthCaseVisaContextType
{
    
    private string healthVisaContextTypeField;
    
    private string healthVisaContextValueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string HealthVisaContextType
    {
        get
        {
            return this.healthVisaContextTypeField;
        }
        set
        {
            this.healthVisaContextTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string HealthVisaContextValue
    {
        get
        {
            return this.healthVisaContextValueField;
        }
        set
        {
            this.healthVisaContextValueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthTelephoneMsgType
{
    
    private string countryTelephoneCodeField;
    
    private string areaCodeField;
    
    private string telephoneNumberField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=0)]
    public string CountryTelephoneCode
    {
        get
        {
            return this.countryTelephoneCodeField;
        }
        set
        {
            this.countryTelephoneCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="integer", Order=1)]
    public string AreaCode
    {
        get
        {
            return this.areaCodeField;
        }
        set
        {
            this.areaCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=2)]
    public string TelephoneNumber
    {
        get
        {
            return this.telephoneNumberField;
        }
        set
        {
            this.telephoneNumberField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthLocationMsgType
{
    
    private string addressLine1Field;
    
    private string addressLine2Field;
    
    private string addressLine3Field;
    
    private string addressLine4Field;
    
    private string localityNameField;
    
    private string stateTerritoryNameField;
    
    private string provinceNameField;
    
    private string countryCodeField;
    
    private string postalCodeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=0)]
    public string AddressLine1
    {
        get
        {
            return this.addressLine1Field;
        }
        set
        {
            this.addressLine1Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=1)]
    public string AddressLine2
    {
        get
        {
            return this.addressLine2Field;
        }
        set
        {
            this.addressLine2Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=2)]
    public string AddressLine3
    {
        get
        {
            return this.addressLine3Field;
        }
        set
        {
            this.addressLine3Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=3)]
    public string AddressLine4
    {
        get
        {
            return this.addressLine4Field;
        }
        set
        {
            this.addressLine4Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=4)]
    public string LocalityName
    {
        get
        {
            return this.localityNameField;
        }
        set
        {
            this.localityNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=5)]
    public string StateTerritoryName
    {
        get
        {
            return this.stateTerritoryNameField;
        }
        set
        {
            this.stateTerritoryNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=6)]
    public string ProvinceName
    {
        get
        {
            return this.provinceNameField;
        }
        set
        {
            this.provinceNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=7)]
    public string CountryCode
    {
        get
        {
            return this.countryCodeField;
        }
        set
        {
            this.countryCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=8)]
    public string PostalCode
    {
        get
        {
            return this.postalCodeField;
        }
        set
        {
            this.postalCodeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthClientContactMsgType
{
    
    private string usageCodeField;
    
    private System.Nullable<bool> healthPrimaryContactFlagField;
    
    private string commentTextField;
    
    private object itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=0)]
    public string UsageCode
    {
        get
        {
            return this.usageCodeField;
        }
        set
        {
            this.usageCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=1)]
    public System.Nullable<bool> HealthPrimaryContactFlag
    {
        get
        {
            return this.healthPrimaryContactFlagField;
        }
        set
        {
            this.healthPrimaryContactFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=2)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("EmailAddress", typeof(string), Namespace="http://www.immi.gov.au/Namespace/Address/Core/V1.0", DataType="token", Order=3)]
    [System.Xml.Serialization.XmlElementAttribute("HealthLocationMsg", typeof(healthLocationMsgType), Order=3)]
    [System.Xml.Serialization.XmlElementAttribute("HealthTelephoneMsg", typeof(healthTelephoneMsgType), Order=3)]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthIdentityDocumentMsgType
{
    
    private string documentTypeCodeField;
    
    private string documentTypeField;
    
    private string documentNumberField;
    
    private string issuingCountryNameField;
    
    private cachedUnstructuredDateType cachedIssueDateField;
    
    private cachedUnstructuredDateType cachedExpiryDateField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=0)]
    public string DocumentTypeCode
    {
        get
        {
            return this.documentTypeCodeField;
        }
        set
        {
            this.documentTypeCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=1)]
    public string DocumentType
    {
        get
        {
            return this.documentTypeField;
        }
        set
        {
            this.documentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=2)]
    public string DocumentNumber
    {
        get
        {
            return this.documentNumberField;
        }
        set
        {
            this.documentNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=3)]
    public string IssuingCountryName
    {
        get
        {
            return this.issuingCountryNameField;
        }
        set
        {
            this.issuingCountryNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=4)]
    public cachedUnstructuredDateType CachedIssueDate
    {
        get
        {
            return this.cachedIssueDateField;
        }
        set
        {
            this.cachedIssueDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=5)]
    public cachedUnstructuredDateType CachedExpiryDate
    {
        get
        {
            return this.cachedExpiryDateField;
        }
        set
        {
            this.cachedExpiryDateField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(cachedExpectedDeliveryDateType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedUnstructuredDateType
{
    
    private string unstructuredYearField;
    
    private string unstructuredMonthField;
    
    private string unstructuredDayField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=0)]
    public string UnstructuredYear
    {
        get
        {
            return this.unstructuredYearField;
        }
        set
        {
            this.unstructuredYearField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=1)]
    public string UnstructuredMonth
    {
        get
        {
            return this.unstructuredMonthField;
        }
        set
        {
            this.unstructuredMonthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=2)]
    public string UnstructuredDay
    {
        get
        {
            return this.unstructuredDayField;
        }
        set
        {
            this.unstructuredDayField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedExpectedDeliveryDateType : cachedUnstructuredDateType
{
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedUnstructuredBirthDayType
{
    
    private string unstructuredDayField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=0)]
    public string UnstructuredDay
    {
        get
        {
            return this.unstructuredDayField;
        }
        set
        {
            this.unstructuredDayField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedUnstructuredBirthMonthType
{
    
    private string unstructuredMonthField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=0)]
    public string UnstructuredMonth
    {
        get
        {
            return this.unstructuredMonthField;
        }
        set
        {
            this.unstructuredMonthField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class cachedUnstructuredBirthYearType
{
    
    private string unstructuredYearField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=0)]
    public string UnstructuredYear
    {
        get
        {
            return this.unstructuredYearField;
        }
        set
        {
            this.unstructuredYearField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
public partial class registerHealthCaseClientBiographicalDetailsType
{
    
    private string titleField;
    
    private string givenNameField;
    
    private string familyNameField;
    
    private sexTypeType sexTypeField;
    
    private cachedUnstructuredBirthYearType cachedBirthYearField;
    
    private cachedUnstructuredBirthMonthType cachedBirthMonthField;
    
    private cachedUnstructuredBirthDayType cachedBirthDayField;
    
    private string birthCountryCodeField;
    
    private string relationshipToPrimaryApplicantField;
    
    private healthIdentityDocumentMsgType healthIdentityDocumentMsgField;
    
    private healthClientContactMsgType[] healthClientContactListMsgField;
    
    private registerHealthCaseVisaContextType[] registerHealthCaseVisaContextField;
    
    private registerHealthCaseRequirementType[] registerHealthCaseRequirementListField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=0)]
    public string Title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=1)]
    public string GivenName
    {
        get
        {
            return this.givenNameField;
        }
        set
        {
            this.givenNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=2)]
    public string FamilyName
    {
        get
        {
            return this.familyNameField;
        }
        set
        {
            this.familyNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", Order=3)]
    public sexTypeType SexType
    {
        get
        {
            return this.sexTypeField;
        }
        set
        {
            this.sexTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=4)]
    public cachedUnstructuredBirthYearType CachedBirthYear
    {
        get
        {
            return this.cachedBirthYearField;
        }
        set
        {
            this.cachedBirthYearField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=5)]
    public cachedUnstructuredBirthMonthType CachedBirthMonth
    {
        get
        {
            return this.cachedBirthMonthField;
        }
        set
        {
            this.cachedBirthMonthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=6)]
    public cachedUnstructuredBirthDayType CachedBirthDay
    {
        get
        {
            return this.cachedBirthDayField;
        }
        set
        {
            this.cachedBirthDayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=7)]
    public string BirthCountryCode
    {
        get
        {
            return this.birthCountryCodeField;
        }
        set
        {
            this.birthCountryCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Party/Core/V1.0", DataType="token", Order=8)]
    public string RelationshipToPrimaryApplicant
    {
        get
        {
            return this.relationshipToPrimaryApplicantField;
        }
        set
        {
            this.relationshipToPrimaryApplicantField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=9)]
    public healthIdentityDocumentMsgType HealthIdentityDocumentMsg
    {
        get
        {
            return this.healthIdentityDocumentMsgField;
        }
        set
        {
            this.healthIdentityDocumentMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=10)]
    [System.Xml.Serialization.XmlArrayItemAttribute("HealthClientContactMsg", IsNullable=false)]
    public healthClientContactMsgType[] HealthClientContactListMsg
    {
        get
        {
            return this.healthClientContactListMsgField;
        }
        set
        {
            this.healthClientContactListMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegisterHealthCaseVisaContext", Order=11)]
    public registerHealthCaseVisaContextType[] RegisterHealthCaseVisaContext
    {
        get
        {
            return this.registerHealthCaseVisaContextField;
        }
        set
        {
            this.registerHealthCaseVisaContextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Order=12)]
    [System.Xml.Serialization.XmlArrayItemAttribute("RegisterHealthCaseRequirement", IsNullable=false)]
    public registerHealthCaseRequirementType[] RegisterHealthCaseRequirementList
    {
        get
        {
            return this.registerHealthCaseRequirementListField;
        }
        set
        {
            this.registerHealthCaseRequirementListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
public enum sexTypeType
{
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("-")]
    Item,
    
    /// <remarks/>
    F,
    
    /// <remarks/>
    M,
    
    /// <remarks/>
    U,
    
    /// <remarks/>
    X,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthClinicIdentifierMsgType
{
    
    private string healthClinicIdentifierField;
    
    private string healthClinicIdentifierTypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string HealthClinicIdentifier
    {
        get
        {
            return this.healthClinicIdentifierField;
        }
        set
        {
            this.healthClinicIdentifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string HealthClinicIdentifierType
    {
        get
        {
            return this.healthClinicIdentifierTypeField;
        }
        set
        {
            this.healthClinicIdentifierTypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public partial class healthCaseIdentifierType
{
    
    private string healthCaseIdentifierValueField;
    
    private string healthCaseIdentifierTypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
    public string HealthCaseIdentifierValue
    {
        get
        {
            return this.healthCaseIdentifierValueField;
        }
        set
        {
            this.healthCaseIdentifierValueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=1)]
    public string HealthCaseIdentifierType
    {
        get
        {
            return this.healthCaseIdentifierTypeField;
        }
        set
        {
            this.healthCaseIdentifierTypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthCaseIdentifierMsgType
{
    
    private healthCaseIdentifierType healthCaseIdentifierField;
    
    private assessmentTypeType assessmentTypeField;
    
    private bool assessmentTypeFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=0)]
    public healthCaseIdentifierType HealthCaseIdentifier
    {
        get
        {
            return this.healthCaseIdentifierField;
        }
        set
        {
            this.healthCaseIdentifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public assessmentTypeType AssessmentType
    {
        get
        {
            return this.assessmentTypeField;
        }
        set
        {
            this.assessmentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool AssessmentTypeSpecified
    {
        get
        {
            return this.assessmentTypeFieldSpecified;
        }
        set
        {
            this.assessmentTypeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
public enum assessmentTypeType
{
    
    /// <remarks/>
    IME,
    
    /// <remarks/>
    DHC,
    
    /// <remarks/>
    ESC,
    
    /// <remarks/>
    PHC,
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
public partial class RegisterHealthCaseRequest
{
    
    private string correlationIDField;
    
    private cachedUnstructuredDateType cachedCreationDateField;
    
    private healthCaseIdentifierMsgType[] healthCaseIdentifierMsgField;
    
    private healthClinicIdentifierMsgType healthClinicIdentifierMsgField;
    
    private registerHealthCaseClientBiographicalDetailsType registerHealthCaseClientBiographicalDetailsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string CorrelationID
    {
        get
        {
            return this.correlationIDField;
        }
        set
        {
            this.correlationIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public cachedUnstructuredDateType CachedCreationDate
    {
        get
        {
            return this.cachedCreationDateField;
        }
        set
        {
            this.cachedCreationDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseIdentifierMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=2)]
    public healthCaseIdentifierMsgType[] HealthCaseIdentifierMsg
    {
        get
        {
            return this.healthCaseIdentifierMsgField;
        }
        set
        {
            this.healthCaseIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=3)]
    public healthClinicIdentifierMsgType HealthClinicIdentifierMsg
    {
        get
        {
            return this.healthClinicIdentifierMsgField;
        }
        set
        {
            this.healthClinicIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public registerHealthCaseClientBiographicalDetailsType RegisterHealthCaseClientBiographicalDetails
    {
        get
        {
            return this.registerHealthCaseClientBiographicalDetailsField;
        }
        set
        {
            this.registerHealthCaseClientBiographicalDetailsField = value;
        }
    }
}


[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class RegisterHealthCaseResponse
{
    
    public acknowledgementMessageType AcknowledgementMessage;
    
    public RegisterHealthCaseResponse()
    {
    }
    
    public RegisterHealthCaseResponse(acknowledgementMessageType AcknowledgementMessage)
    {
        this.AcknowledgementMessage = AcknowledgementMessage;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class notifyMedicalExaminationStatusRequestType
{
    
    private string correlationIDField;
    
    private healthCaseIdentifierMsgType[] healthCaseIdentifierMsgField;
    
    private cachedUnstructuredDateType cachedCreationDateField;
    
    private object itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string CorrelationID
    {
        get
        {
            return this.correlationIDField;
        }
        set
        {
            this.correlationIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseIdentifierMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=1)]
    public healthCaseIdentifierMsgType[] HealthCaseIdentifierMsg
    {
        get
        {
            return this.healthCaseIdentifierMsgField;
        }
        set
        {
            this.healthCaseIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=2)]
    public cachedUnstructuredDateType CachedCreationDate
    {
        get
        {
            return this.cachedCreationDateField;
        }
        set
        {
            this.cachedCreationDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseStatusUpdate", typeof(healthCaseStatusUpdateType), Order=3)]
    [System.Xml.Serialization.XmlElementAttribute("NotifyMedicalExaminationStatusRequestHealthRequirement", typeof(notifyMedicalExaminationStatusRequestHealthRequirementType), Order=3)]
    [System.Xml.Serialization.XmlElementAttribute("NotifyMedicalStatusRequestHealthClientContext", typeof(notifyMedicalStatusRequestHealthClientContextType), Order=3)]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class healthCaseStatusUpdateType
{
    
    private string statusField;
    
    private System.DateTime statusTimestampField;
    
    private bool statusTimestampFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=0)]
    public string Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public System.DateTime StatusTimestamp
    {
        get
        {
            return this.statusTimestampField;
        }
        set
        {
            this.statusTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool StatusTimestampSpecified
    {
        get
        {
            return this.statusTimestampFieldSpecified;
        }
        set
        {
            this.statusTimestampFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class notifyMedicalExaminationStatusRequestHealthRequirementType
{
    
    private string healthRequirementTypeField;
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    private string healthRequirementStatusCodeField;
    
    private cachedUnstructuredDateTimeType cachedStatusTimestampField;
    
    private healthRequirementIdentifierMsgType healthRequirementIdentifierMsgField;
    
    private notifyMedicalExaminationStatusRequestExaminationType notifyMedicalExaminationStatusRequestExaminationField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="integer", Order=0)]
    public string HealthRequirementType
    {
        get
        {
            return this.healthRequirementTypeField;
        }
        set
        {
            this.healthRequirementTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=2)]
    public string HealthRequirementStatusCode
    {
        get
        {
            return this.healthRequirementStatusCodeField;
        }
        set
        {
            this.healthRequirementStatusCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=3)]
    public cachedUnstructuredDateTimeType CachedStatusTimestamp
    {
        get
        {
            return this.cachedStatusTimestampField;
        }
        set
        {
            this.cachedStatusTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=4)]
    public healthRequirementIdentifierMsgType HealthRequirementIdentifierMsg
    {
        get
        {
            return this.healthRequirementIdentifierMsgField;
        }
        set
        {
            this.healthRequirementIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public notifyMedicalExaminationStatusRequestExaminationType NotifyMedicalExaminationStatusRequestExamination
    {
        get
        {
            return this.notifyMedicalExaminationStatusRequestExaminationField;
        }
        set
        {
            this.notifyMedicalExaminationStatusRequestExaminationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthRequirementIdentifierMsgType
{
    
    private string healthRequirementIdentifierField;
    
    private string healthRequirementIdentifierTypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string HealthRequirementIdentifier
    {
        get
        {
            return this.healthRequirementIdentifierField;
        }
        set
        {
            this.healthRequirementIdentifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string HealthRequirementIdentifierType
    {
        get
        {
            return this.healthRequirementIdentifierTypeField;
        }
        set
        {
            this.healthRequirementIdentifierTypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class notifyMedicalExaminationStatusRequestExaminationType
{
    
    private string examinationStatusField;
    
    private cachedUnstructuredDateTimeType cachedStatusTimestampField;
    
    private cachedExpectedDeliveryDateType cachedExpectedDeliveryDateField;
    
    private string clinicIDField;
    
    private string userIdField;
    
    private string userNameField;
    
    private string commentTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string ExaminationStatus
    {
        get
        {
            return this.examinationStatusField;
        }
        set
        {
            this.examinationStatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=1)]
    public cachedUnstructuredDateTimeType CachedStatusTimestamp
    {
        get
        {
            return this.cachedStatusTimestampField;
        }
        set
        {
            this.cachedStatusTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=2)]
    public cachedExpectedDeliveryDateType CachedExpectedDeliveryDate
    {
        get
        {
            return this.cachedExpectedDeliveryDateField;
        }
        set
        {
            this.cachedExpectedDeliveryDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=3)]
    public string ClinicID
    {
        get
        {
            return this.clinicIDField;
        }
        set
        {
            this.clinicIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=4)]
    public string UserId
    {
        get
        {
            return this.userIdField;
        }
        set
        {
            this.userIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=5)]
    public string UserName
    {
        get
        {
            return this.userNameField;
        }
        set
        {
            this.userNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=6)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class notifyMedicalStatusRequestHealthClientContextType
{
    
    private string titleField;
    
    private string givenNameField;
    
    private string familyNameField;
    
    private sexTypeType sexTypeField;
    
    private cachedUnstructuredBirthYearType cachedBirthYearField;
    
    private cachedUnstructuredBirthMonthType cachedBirthMonthField;
    
    private cachedUnstructuredBirthDayType cachedBirthDayField;
    
    private string birthCountryCodeField;
    
    private string relationshipToPrimaryApplicantField;
    
    private healthIdentityDocumentMsgType healthIdentityDocumentMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=0)]
    public string Title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=1)]
    public string GivenName
    {
        get
        {
            return this.givenNameField;
        }
        set
        {
            this.givenNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=2)]
    public string FamilyName
    {
        get
        {
            return this.familyNameField;
        }
        set
        {
            this.familyNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", Order=3)]
    public sexTypeType SexType
    {
        get
        {
            return this.sexTypeField;
        }
        set
        {
            this.sexTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=4)]
    public cachedUnstructuredBirthYearType CachedBirthYear
    {
        get
        {
            return this.cachedBirthYearField;
        }
        set
        {
            this.cachedBirthYearField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=5)]
    public cachedUnstructuredBirthMonthType CachedBirthMonth
    {
        get
        {
            return this.cachedBirthMonthField;
        }
        set
        {
            this.cachedBirthMonthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=6)]
    public cachedUnstructuredBirthDayType CachedBirthDay
    {
        get
        {
            return this.cachedBirthDayField;
        }
        set
        {
            this.cachedBirthDayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=7)]
    public string BirthCountryCode
    {
        get
        {
            return this.birthCountryCodeField;
        }
        set
        {
            this.birthCountryCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Party/Core/V1.0", DataType="token", Order=8)]
    public string RelationshipToPrimaryApplicant
    {
        get
        {
            return this.relationshipToPrimaryApplicantField;
        }
        set
        {
            this.relationshipToPrimaryApplicantField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=9)]
    public healthIdentityDocumentMsgType HealthIdentityDocumentMsg
    {
        get
        {
            return this.healthIdentityDocumentMsgField;
        }
        set
        {
            this.healthIdentityDocumentMsgField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class NotifyMedicalExaminationStatusRequest
{
    
    public notifyMedicalExaminationStatusRequestType NotifyMedicalExaminationStatusRequest1;
    
    public NotifyMedicalExaminationStatusRequest()
    {
    }
    
    public NotifyMedicalExaminationStatusRequest(notifyMedicalExaminationStatusRequestType NotifyMedicalExaminationStatusRequest1)
    {
        this.NotifyMedicalExaminationStatusRequest1 = NotifyMedicalExaminationStatusRequest1;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class NotifyMedicalExaminationStatusResponse
{
    
    public acknowledgementMessageType AcknowledgementMessage;
    
    public NotifyMedicalExaminationStatusResponse()
    {
    }
    
    public NotifyMedicalExaminationStatusResponse(acknowledgementMessageType AcknowledgementMessage)
    {
        this.AcknowledgementMessage = AcknowledgementMessage;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class deleteCachedHealthCaseRequestType
{
    
    private string correlationIDField;
    
    private healthCaseIdentifierMsgType[] healthCaseIdentifierMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string CorrelationID
    {
        get
        {
            return this.correlationIDField;
        }
        set
        {
            this.correlationIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseIdentifierMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=1)]
    public healthCaseIdentifierMsgType[] HealthCaseIdentifierMsg
    {
        get
        {
            return this.healthCaseIdentifierMsgField;
        }
        set
        {
            this.healthCaseIdentifierMsgField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class DeleteCachedHealthCaseRequest
{
    
    public deleteCachedHealthCaseRequestType DeleteCachedHealthCaseRequest1;
    
    public DeleteCachedHealthCaseRequest()
    {
    }
    
    public DeleteCachedHealthCaseRequest(deleteCachedHealthCaseRequestType DeleteCachedHealthCaseRequest1)
    {
        this.DeleteCachedHealthCaseRequest1 = DeleteCachedHealthCaseRequest1;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class DeleteCachedHealthCaseResponse
{
    
    public acknowledgementMessageType AcknowledgementMessage;
    
    public DeleteCachedHealthCaseResponse()
    {
    }
    
    public DeleteCachedHealthCaseResponse(acknowledgementMessageType AcknowledgementMessage)
    {
        this.AcknowledgementMessage = AcknowledgementMessage;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class registerMedicalExaminationsResultsRequestType
{
    
    private string correlationIDField;
    
    private healthCaseIdentifierMsgType[] healthCaseIdentifierMsgField;
    
    private registerMedicalExaminationsResultsRequestIdentityDocumentType registerMedicalExaminationsResultsRequestIdentityDocumentField;
    
    private healthFacialImageMsgType healthFacialImageMsgField;
    
    private healthCaseDetailFormType healthCaseDetailFormField;
    
    private healthCaseAttachmentMsgType[] healthCaseAttachmentMsgField;
    
    private registerMedicalExaminationsResultsRequestHealthRequirementType[] registerMedicalExaminationsResultsRequestHealthRequirementField;
    
    private string processingUnitField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string CorrelationID
    {
        get
        {
            return this.correlationIDField;
        }
        set
        {
            this.correlationIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseIdentifierMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=1)]
    public healthCaseIdentifierMsgType[] HealthCaseIdentifierMsg
    {
        get
        {
            return this.healthCaseIdentifierMsgField;
        }
        set
        {
            this.healthCaseIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public registerMedicalExaminationsResultsRequestIdentityDocumentType RegisterMedicalExaminationsResultsRequestIdentityDocument
    {
        get
        {
            return this.registerMedicalExaminationsResultsRequestIdentityDocumentField;
        }
        set
        {
            this.registerMedicalExaminationsResultsRequestIdentityDocumentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=3)]
    public healthFacialImageMsgType HealthFacialImageMsg
    {
        get
        {
            return this.healthFacialImageMsgField;
        }
        set
        {
            this.healthFacialImageMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public healthCaseDetailFormType HealthCaseDetailForm
    {
        get
        {
            return this.healthCaseDetailFormField;
        }
        set
        {
            this.healthCaseDetailFormField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseAttachmentMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=5)]
    public healthCaseAttachmentMsgType[] HealthCaseAttachmentMsg
    {
        get
        {
            return this.healthCaseAttachmentMsgField;
        }
        set
        {
            this.healthCaseAttachmentMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegisterMedicalExaminationsResultsRequestHealthRequirement", Order=6)]
    public registerMedicalExaminationsResultsRequestHealthRequirementType[] RegisterMedicalExaminationsResultsRequestHealthRequirement
    {
        get
        {
            return this.registerMedicalExaminationsResultsRequestHealthRequirementField;
        }
        set
        {
            this.registerMedicalExaminationsResultsRequestHealthRequirementField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=7)]
    public string ProcessingUnit
    {
        get
        {
            return this.processingUnitField;
        }
        set
        {
            this.processingUnitField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class registerMedicalExaminationsResultsRequestIdentityDocumentType
{
    
    private string documentTypeCodeField;
    
    private string documentTypeField;
    
    private string documentNumberField;
    
    private string issuingCountryNameField;
    
    private cachedUnstructuredDateType cachedIssueDateField;
    
    private cachedUnstructuredDateType cachedExpiryDateField;
    
    private System.Nullable<bool> identityDocumentedPresentedFlagField;
    
    private bool identityDocumentedPresentedFlagFieldSpecified;
    
    private System.Nullable<bool> identityConcernsFlagField;
    
    private bool identityConcernsFlagFieldSpecified;
    
    private string identityConcernsCommentField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=0)]
    public string DocumentTypeCode
    {
        get
        {
            return this.documentTypeCodeField;
        }
        set
        {
            this.documentTypeCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=1)]
    public string DocumentType
    {
        get
        {
            return this.documentTypeField;
        }
        set
        {
            this.documentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=2)]
    public string DocumentNumber
    {
        get
        {
            return this.documentNumberField;
        }
        set
        {
            this.documentNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=3)]
    public string IssuingCountryName
    {
        get
        {
            return this.issuingCountryNameField;
        }
        set
        {
            this.issuingCountryNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=4)]
    public cachedUnstructuredDateType CachedIssueDate
    {
        get
        {
            return this.cachedIssueDateField;
        }
        set
        {
            this.cachedIssueDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=5)]
    public cachedUnstructuredDateType CachedExpiryDate
    {
        get
        {
            return this.cachedExpiryDateField;
        }
        set
        {
            this.cachedExpiryDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=6)]
    public System.Nullable<bool> IdentityDocumentedPresentedFlag
    {
        get
        {
            return this.identityDocumentedPresentedFlagField;
        }
        set
        {
            this.identityDocumentedPresentedFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IdentityDocumentedPresentedFlagSpecified
    {
        get
        {
            return this.identityDocumentedPresentedFlagFieldSpecified;
        }
        set
        {
            this.identityDocumentedPresentedFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=7)]
    public System.Nullable<bool> IdentityConcernsFlag
    {
        get
        {
            return this.identityConcernsFlagField;
        }
        set
        {
            this.identityConcernsFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IdentityConcernsFlagSpecified
    {
        get
        {
            return this.identityConcernsFlagFieldSpecified;
        }
        set
        {
            this.identityConcernsFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=8)]
    public string IdentityConcernsComment
    {
        get
        {
            return this.identityConcernsCommentField;
        }
        set
        {
            this.identityConcernsCommentField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthFacialImageMsgType
{
    
    private object itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthPhotoAttachedMsg", typeof(healthPhotoAttachedMsgType), Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("HealthPhotoNotAttachedMsg", typeof(healthPhotoNotAttachedMsgType), Order=0)]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthPhotoAttachedMsgType
{
    
    private byte[] personImageField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="base64Binary", Order=0)]
    public byte[] PersonImage
    {
        get
        {
            return this.personImageField;
        }
        set
        {
            this.personImageField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthPhotoNotAttachedMsgType
{
    
    private string cannotAttachReasonField;
    
    private string cannotAttachDetailsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=0)]
    public string CannotAttachReason
    {
        get
        {
            return this.cannotAttachReasonField;
        }
        set
        {
            this.cannotAttachReasonField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=1)]
    public string CannotAttachDetails
    {
        get
        {
            return this.cannotAttachDetailsField;
        }
        set
        {
            this.cannotAttachDetailsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class healthCaseDetailFormType
{
    
    private healthFormMsgType healthFormMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=0)]
    public healthFormMsgType HealthFormMsg
    {
        get
        {
            return this.healthFormMsgField;
        }
        set
        {
            this.healthFormMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthFormMsgType
{
    
    private object itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthFormExcDCMsg", typeof(healthFormExcDCMsgType), Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("HealthFormIncDCMsg", typeof(healthFormIncDCMsgType), Order=0)]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthFormExcDCMsgType
{
    
    private string formCodeField;
    
    private string versionNumberField;
    
    private string languageTypeField;
    
    private healthSectionExcDCMsgType[] healthSectionExcDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string FormCode
    {
        get
        {
            return this.formCodeField;
        }
        set
        {
            this.formCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="integer", Order=1)]
    public string VersionNumber
    {
        get
        {
            return this.versionNumberField;
        }
        set
        {
            this.versionNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=2)]
    public string LanguageType
    {
        get
        {
            return this.languageTypeField;
        }
        set
        {
            this.languageTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthSectionExcDCMsg", Order=3)]
    public healthSectionExcDCMsgType[] HealthSectionExcDCMsg
    {
        get
        {
            return this.healthSectionExcDCMsgField;
        }
        set
        {
            this.healthSectionExcDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthSectionExcDCMsgType
{
    
    private string sectionIDField;
    
    private string sectionCodeField;
    
    private string sectionTextField;
    
    private string sequenceField;
    
    private healthSectionExcDCMsgType[] childSectionField;
    
    private healthQuestionExcDCMsgType[] healthQuestionExcDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string SectionID
    {
        get
        {
            return this.sectionIDField;
        }
        set
        {
            this.sectionIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=1)]
    public string SectionCode
    {
        get
        {
            return this.sectionCodeField;
        }
        set
        {
            this.sectionCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=2)]
    public string SectionText
    {
        get
        {
            return this.sectionTextField;
        }
        set
        {
            this.sectionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="integer", Order=3)]
    public string Sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ChildSection", Order=4)]
    public healthSectionExcDCMsgType[] ChildSection
    {
        get
        {
            return this.childSectionField;
        }
        set
        {
            this.childSectionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthQuestionExcDCMsg", Order=5)]
    public healthQuestionExcDCMsgType[] HealthQuestionExcDCMsg
    {
        get
        {
            return this.healthQuestionExcDCMsgField;
        }
        set
        {
            this.healthQuestionExcDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthQuestionExcDCMsgType
{
    
    private string questionIDField;
    
    private string questionCodeField;
    
    private string questionTextField;
    
    private string sequenceField;
    
    private healthQuestionExcDCMsgType[] childQuestionField;
    
    private healthAnswerExcDCMsgType healthAnswerExcDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string QuestionID
    {
        get
        {
            return this.questionIDField;
        }
        set
        {
            this.questionIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=1)]
    public string QuestionCode
    {
        get
        {
            return this.questionCodeField;
        }
        set
        {
            this.questionCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=2)]
    public string QuestionText
    {
        get
        {
            return this.questionTextField;
        }
        set
        {
            this.questionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="integer", Order=3)]
    public string Sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ChildQuestion", Order=4)]
    public healthQuestionExcDCMsgType[] ChildQuestion
    {
        get
        {
            return this.childQuestionField;
        }
        set
        {
            this.childQuestionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public healthAnswerExcDCMsgType HealthAnswerExcDCMsg
    {
        get
        {
            return this.healthAnswerExcDCMsgField;
        }
        set
        {
            this.healthAnswerExcDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthAnswerExcDCMsgType
{
    
    private string answerTypeCodeField;
    
    private string answerMetadataField;
    
    private string practitionerIDField;
    
    private string userNameField;
    
    private string valueField;
    
    private string valueDescriptionField;
    
    private string commentTextField;
    
    private string commentPractitionerIDField;
    
    private System.Nullable<bool> abnormalFlagField;
    
    private bool abnormalFlagFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string AnswerTypeCode
    {
        get
        {
            return this.answerTypeCodeField;
        }
        set
        {
            this.answerTypeCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string AnswerMetadata
    {
        get
        {
            return this.answerMetadataField;
        }
        set
        {
            this.answerMetadataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=2)]
    public string PractitionerID
    {
        get
        {
            return this.practitionerIDField;
        }
        set
        {
            this.practitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=3)]
    public string UserName
    {
        get
        {
            return this.userNameField;
        }
        set
        {
            this.userNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=4)]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=5)]
    public string ValueDescription
    {
        get
        {
            return this.valueDescriptionField;
        }
        set
        {
            this.valueDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=6)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=7)]
    public string CommentPractitionerID
    {
        get
        {
            return this.commentPractitionerIDField;
        }
        set
        {
            this.commentPractitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=8)]
    public System.Nullable<bool> AbnormalFlag
    {
        get
        {
            return this.abnormalFlagField;
        }
        set
        {
            this.abnormalFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool AbnormalFlagSpecified
    {
        get
        {
            return this.abnormalFlagFieldSpecified;
        }
        set
        {
            this.abnormalFlagFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthFormIncDCMsgType
{
    
    private string formCodeField;
    
    private string versionNumberField;
    
    private string languageTypeField;
    
    private healthSectionIncDCMsgType[] healthSectionIncDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string FormCode
    {
        get
        {
            return this.formCodeField;
        }
        set
        {
            this.formCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="integer", Order=1)]
    public string VersionNumber
    {
        get
        {
            return this.versionNumberField;
        }
        set
        {
            this.versionNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0", DataType="token", Order=2)]
    public string LanguageType
    {
        get
        {
            return this.languageTypeField;
        }
        set
        {
            this.languageTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthSectionIncDCMsg", Order=3)]
    public healthSectionIncDCMsgType[] HealthSectionIncDCMsg
    {
        get
        {
            return this.healthSectionIncDCMsgField;
        }
        set
        {
            this.healthSectionIncDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthSectionIncDCMsgType
{
    
    private string sectionIDField;
    
    private string sectionCodeField;
    
    private string sectionTextField;
    
    private string sequenceField;
    
    private healthSectionIncDCMsgType[] childSectionField;
    
    private healthQuestionIncDCMsgType[] healthQuestionIncDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string SectionID
    {
        get
        {
            return this.sectionIDField;
        }
        set
        {
            this.sectionIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=1)]
    public string SectionCode
    {
        get
        {
            return this.sectionCodeField;
        }
        set
        {
            this.sectionCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=2)]
    public string SectionText
    {
        get
        {
            return this.sectionTextField;
        }
        set
        {
            this.sectionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="integer", Order=3)]
    public string Sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ChildSection", Order=4)]
    public healthSectionIncDCMsgType[] ChildSection
    {
        get
        {
            return this.childSectionField;
        }
        set
        {
            this.childSectionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthQuestionIncDCMsg", Order=5)]
    public healthQuestionIncDCMsgType[] HealthQuestionIncDCMsg
    {
        get
        {
            return this.healthQuestionIncDCMsgField;
        }
        set
        {
            this.healthQuestionIncDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthQuestionIncDCMsgType
{
    
    private string questionIDField;
    
    private string questionCodeField;
    
    private string questionTextField;
    
    private string sequenceField;
    
    private healthQuestionIncDCMsgType[] childQuestionField;
    
    private healthAnswerIncDCMsgType healthAnswerIncDCMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string QuestionID
    {
        get
        {
            return this.questionIDField;
        }
        set
        {
            this.questionIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=1)]
    public string QuestionCode
    {
        get
        {
            return this.questionCodeField;
        }
        set
        {
            this.questionCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=2)]
    public string QuestionText
    {
        get
        {
            return this.questionTextField;
        }
        set
        {
            this.questionTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="integer", Order=3)]
    public string Sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ChildQuestion", Order=4)]
    public healthQuestionIncDCMsgType[] ChildQuestion
    {
        get
        {
            return this.childQuestionField;
        }
        set
        {
            this.childQuestionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public healthAnswerIncDCMsgType HealthAnswerIncDCMsg
    {
        get
        {
            return this.healthAnswerIncDCMsgField;
        }
        set
        {
            this.healthAnswerIncDCMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthAnswerIncDCMsgType
{
    
    private string answerTypeCodeField;
    
    private string answerMetadataField;
    
    private string practitionerIDField;
    
    private string userNameField;
    
    private string valueField;
    
    private string valueDescriptionField;
    
    private string commentTextField;
    
    private string commentPractitionerIDField;
    
    private System.Nullable<bool> abnormalFlagField;
    
    private bool abnormalFlagFieldSpecified;
    
    private healthDoctorCommentMsgType[] healthDoctorCommentMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0", DataType="token", Order=0)]
    public string AnswerTypeCode
    {
        get
        {
            return this.answerTypeCodeField;
        }
        set
        {
            this.answerTypeCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string AnswerMetadata
    {
        get
        {
            return this.answerMetadataField;
        }
        set
        {
            this.answerMetadataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=2)]
    public string PractitionerID
    {
        get
        {
            return this.practitionerIDField;
        }
        set
        {
            this.practitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=3)]
    public string UserName
    {
        get
        {
            return this.userNameField;
        }
        set
        {
            this.userNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=4)]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=5)]
    public string ValueDescription
    {
        get
        {
            return this.valueDescriptionField;
        }
        set
        {
            this.valueDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=6)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=7)]
    public string CommentPractitionerID
    {
        get
        {
            return this.commentPractitionerIDField;
        }
        set
        {
            this.commentPractitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=8)]
    public System.Nullable<bool> AbnormalFlag
    {
        get
        {
            return this.abnormalFlagField;
        }
        set
        {
            this.abnormalFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool AbnormalFlagSpecified
    {
        get
        {
            return this.abnormalFlagFieldSpecified;
        }
        set
        {
            this.abnormalFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthDoctorCommentMsg", Order=9)]
    public healthDoctorCommentMsgType[] HealthDoctorCommentMsg
    {
        get
        {
            return this.healthDoctorCommentMsgField;
        }
        set
        {
            this.healthDoctorCommentMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthDoctorCommentMsgType
{
    
    private string clinicIDField;
    
    private string practitionerIDField;
    
    private string commentTextField;
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string ClinicID
    {
        get
        {
            return this.clinicIDField;
        }
        set
        {
            this.clinicIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string PractitionerID
    {
        get
        {
            return this.practitionerIDField;
        }
        set
        {
            this.practitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=2)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=3)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthCaseAttachmentMsgType
{
    
    private healthAttachmentIdentifierMsgType healthAttachmentIdentifierMsgField;
    
    private string statusCodeField;
    
    private string documentTypeField;
    
    private string sendingMethodField;
    
    private string fileNameField;
    
    private string detailField;
    
    private string fileSizeField;
    
    private string mIMEContentTypeField;
    
    private string commentTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public healthAttachmentIdentifierMsgType HealthAttachmentIdentifierMsg
    {
        get
        {
            return this.healthAttachmentIdentifierMsgField;
        }
        set
        {
            this.healthAttachmentIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=1)]
    public string StatusCode
    {
        get
        {
            return this.statusCodeField;
        }
        set
        {
            this.statusCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=2)]
    public string DocumentType
    {
        get
        {
            return this.documentTypeField;
        }
        set
        {
            this.documentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0", DataType="token", Order=3)]
    public string SendingMethod
    {
        get
        {
            return this.sendingMethodField;
        }
        set
        {
            this.sendingMethodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", Order=4)]
    public string FileName
    {
        get
        {
            return this.fileNameField;
        }
        set
        {
            this.fileNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=5)]
    public string Detail
    {
        get
        {
            return this.detailField;
        }
        set
        {
            this.detailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="nonNegativeInteger", Order=6)]
    public string FileSize
    {
        get
        {
            return this.fileSizeField;
        }
        set
        {
            this.fileSizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=7)]
    public string MIMEContentType
    {
        get
        {
            return this.mIMEContentTypeField;
        }
        set
        {
            this.mIMEContentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=8)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthAttachmentIdentifierMsgType
{
    
    private string attachmentIdentifierField;
    
    private string attachmentIdentifierTypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=0)]
    public string AttachmentIdentifier
    {
        get
        {
            return this.attachmentIdentifierField;
        }
        set
        {
            this.attachmentIdentifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Document/Core/V1.0", DataType="token", Order=1)]
    public string AttachmentIdentifierType
    {
        get
        {
            return this.attachmentIdentifierTypeField;
        }
        set
        {
            this.attachmentIdentifierTypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class registerMedicalExaminationsResultsRequestHealthRequirementType
{
    
    private healthRequirementMsgType healthRequirementMsgField;
    
    private healthRequirementIdentifierMsgType healthRequirementIdentifierMsgField;
    
    private registerMedicalExaminationsResultsRequestExaminationType registerMedicalExaminationsResultsRequestExaminationField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=0)]
    public healthRequirementMsgType HealthRequirementMsg
    {
        get
        {
            return this.healthRequirementMsgField;
        }
        set
        {
            this.healthRequirementMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=1)]
    public healthRequirementIdentifierMsgType HealthRequirementIdentifierMsg
    {
        get
        {
            return this.healthRequirementIdentifierMsgField;
        }
        set
        {
            this.healthRequirementIdentifierMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public registerMedicalExaminationsResultsRequestExaminationType RegisterMedicalExaminationsResultsRequestExamination
    {
        get
        {
            return this.registerMedicalExaminationsResultsRequestExaminationField;
        }
        set
        {
            this.registerMedicalExaminationsResultsRequestExaminationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthRequirementMsgType
{
    
    private string healthRequirementTypeField;
    
    private string healthRequirementDescriptionField;
    
    private string healthRequirementReasonField;
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    private string healthRequirementStatusCodeField;
    
    private cachedUnstructuredDateTimeType cachedStatusTimestampField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="integer", Order=0)]
    public string HealthRequirementType
    {
        get
        {
            return this.healthRequirementTypeField;
        }
        set
        {
            this.healthRequirementTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string HealthRequirementDescription
    {
        get
        {
            return this.healthRequirementDescriptionField;
        }
        set
        {
            this.healthRequirementDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=2)]
    public string HealthRequirementReason
    {
        get
        {
            return this.healthRequirementReasonField;
        }
        set
        {
            this.healthRequirementReasonField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=3)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=4)]
    public string HealthRequirementStatusCode
    {
        get
        {
            return this.healthRequirementStatusCodeField;
        }
        set
        {
            this.healthRequirementStatusCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=5)]
    public cachedUnstructuredDateTimeType CachedStatusTimestamp
    {
        get
        {
            return this.cachedStatusTimestampField;
        }
        set
        {
            this.cachedStatusTimestampField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class registerMedicalExaminationsResultsRequestExaminationType
{
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    private string createUserIdField;
    
    private string createUsernameField;
    
    private string countryCodeField;
    
    private string clinicIDField;
    
    private examUpdatedType examUpdatedField;
    
    private cachedUnstructuredDateType cachedEffectiveStartDateField;
    
    private cachedUnstructuredDateType cachedEffectiveEndDateField;
    
    private System.Nullable<bool> examinationManuallyReceivedFlagField;
    
    private bool examinationManuallyReceivedFlagFieldSpecified;
    
    private System.Nullable<bool> declarationFlagField;
    
    private bool declarationFlagFieldSpecified;
    
    private string examinationGradingField;
    
    private string gradingPractitionerIDField;
    
    private string commentTextField;
    
    private string practitionerIDField;
    
    private string examinationStatusReasonField;
    
    private string examinationStatusCommentField;
    
    private proxySubmittingUserType proxySubmittingUserField;
    
    private healthReferralMsgType healthReferralMsgField;
    
    private registerMedicalExaminationsResultsRequestIdentityDocumentType registerMedicalExaminationsResultsRequestIdentityDocumentField;
    
    private healthCaseAttachmentMsgType[] healthCaseAttachmentMsgField;
    
    private healthFormMsgType healthFormMsgField;
    
    private healthMedicalHistoryMsgType healthMedicalHistoryMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=0)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=1)]
    public string CreateUserId
    {
        get
        {
            return this.createUserIdField;
        }
        set
        {
            this.createUserIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=2)]
    public string CreateUsername
    {
        get
        {
            return this.createUsernameField;
        }
        set
        {
            this.createUsernameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=3)]
    public string CountryCode
    {
        get
        {
            return this.countryCodeField;
        }
        set
        {
            this.countryCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=4)]
    public string ClinicID
    {
        get
        {
            return this.clinicIDField;
        }
        set
        {
            this.clinicIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public examUpdatedType ExamUpdated
    {
        get
        {
            return this.examUpdatedField;
        }
        set
        {
            this.examUpdatedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=6)]
    public cachedUnstructuredDateType CachedEffectiveStartDate
    {
        get
        {
            return this.cachedEffectiveStartDateField;
        }
        set
        {
            this.cachedEffectiveStartDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=7)]
    public cachedUnstructuredDateType CachedEffectiveEndDate
    {
        get
        {
            return this.cachedEffectiveEndDateField;
        }
        set
        {
            this.cachedEffectiveEndDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=8)]
    public System.Nullable<bool> ExaminationManuallyReceivedFlag
    {
        get
        {
            return this.examinationManuallyReceivedFlagField;
        }
        set
        {
            this.examinationManuallyReceivedFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ExaminationManuallyReceivedFlagSpecified
    {
        get
        {
            return this.examinationManuallyReceivedFlagFieldSpecified;
        }
        set
        {
            this.examinationManuallyReceivedFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=9)]
    public System.Nullable<bool> DeclarationFlag
    {
        get
        {
            return this.declarationFlagField;
        }
        set
        {
            this.declarationFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DeclarationFlagSpecified
    {
        get
        {
            return this.declarationFlagFieldSpecified;
        }
        set
        {
            this.declarationFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=10)]
    public string ExaminationGrading
    {
        get
        {
            return this.examinationGradingField;
        }
        set
        {
            this.examinationGradingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=11)]
    public string GradingPractitionerID
    {
        get
        {
            return this.gradingPractitionerIDField;
        }
        set
        {
            this.gradingPractitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=12)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=13)]
    public string PractitionerID
    {
        get
        {
            return this.practitionerIDField;
        }
        set
        {
            this.practitionerIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=14)]
    public string ExaminationStatusReason
    {
        get
        {
            return this.examinationStatusReasonField;
        }
        set
        {
            this.examinationStatusReasonField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=15)]
    public string ExaminationStatusComment
    {
        get
        {
            return this.examinationStatusCommentField;
        }
        set
        {
            this.examinationStatusCommentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=16)]
    public proxySubmittingUserType ProxySubmittingUser
    {
        get
        {
            return this.proxySubmittingUserField;
        }
        set
        {
            this.proxySubmittingUserField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=17)]
    public healthReferralMsgType HealthReferralMsg
    {
        get
        {
            return this.healthReferralMsgField;
        }
        set
        {
            this.healthReferralMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=18)]
    public registerMedicalExaminationsResultsRequestIdentityDocumentType RegisterMedicalExaminationsResultsRequestIdentityDocument
    {
        get
        {
            return this.registerMedicalExaminationsResultsRequestIdentityDocumentField;
        }
        set
        {
            this.registerMedicalExaminationsResultsRequestIdentityDocumentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HealthCaseAttachmentMsg", Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=19)]
    public healthCaseAttachmentMsgType[] HealthCaseAttachmentMsg
    {
        get
        {
            return this.healthCaseAttachmentMsgField;
        }
        set
        {
            this.healthCaseAttachmentMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=20)]
    public healthFormMsgType HealthFormMsg
    {
        get
        {
            return this.healthFormMsgField;
        }
        set
        {
            this.healthFormMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=21)]
    public healthMedicalHistoryMsgType HealthMedicalHistoryMsg
    {
        get
        {
            return this.healthMedicalHistoryMsgField;
        }
        set
        {
            this.healthMedicalHistoryMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class examUpdatedType
{
    
    private cachedUnstructuredDateTimeType cachedCreatedTimestampField;
    
    private string createUserIdField;
    
    private string createUsernameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", Order=0)]
    public cachedUnstructuredDateTimeType CachedCreatedTimestamp
    {
        get
        {
            return this.cachedCreatedTimestampField;
        }
        set
        {
            this.cachedCreatedTimestampField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=1)]
    public string CreateUserId
    {
        get
        {
            return this.createUserIdField;
        }
        set
        {
            this.createUserIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=2)]
    public string CreateUsername
    {
        get
        {
            return this.createUsernameField;
        }
        set
        {
            this.createUsernameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class proxySubmittingUserType
{
    
    private string userIdField;
    
    private string userNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=0)]
    public string UserId
    {
        get
        {
            return this.userIdField;
        }
        set
        {
            this.userIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", DataType="token", Order=1)]
    public string UserName
    {
        get
        {
            return this.userNameField;
        }
        set
        {
            this.userNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthReferralMsgType
{
    
    private string clinicNameField;
    
    private System.Nullable<bool> referralIdentityConfirmationFlagField;
    
    private bool referralIdentityConfirmationFlagFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string ClinicName
    {
        get
        {
            return this.clinicNameField;
        }
        set
        {
            this.clinicNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=1)]
    public System.Nullable<bool> ReferralIdentityConfirmationFlag
    {
        get
        {
            return this.referralIdentityConfirmationFlagField;
        }
        set
        {
            this.referralIdentityConfirmationFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ReferralIdentityConfirmationFlagSpecified
    {
        get
        {
            return this.referralIdentityConfirmationFlagFieldSpecified;
        }
        set
        {
            this.referralIdentityConfirmationFlagFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healthMedicalHistoryMsgType
{
    
    private string clinicIDField;
    
    private System.Nullable<bool> clientDeclarationFlagField;
    
    private bool clientDeclarationFlagFieldSpecified;
    
    private string commentTextField;
    
    private healthFormMsgType healthFormMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string ClinicID
    {
        get
        {
            return this.clinicIDField;
        }
        set
        {
            this.clinicIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=1)]
    public System.Nullable<bool> ClientDeclarationFlag
    {
        get
        {
            return this.clientDeclarationFlagField;
        }
        set
        {
            this.clientDeclarationFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ClientDeclarationFlagSpecified
    {
        get
        {
            return this.clientDeclarationFlagFieldSpecified;
        }
        set
        {
            this.clientDeclarationFlagFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0", Order=2)]
    public string CommentText
    {
        get
        {
            return this.commentTextField;
        }
        set
        {
            this.commentTextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public healthFormMsgType HealthFormMsg
    {
        get
        {
            return this.healthFormMsgField;
        }
        set
        {
            this.healthFormMsgField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class RegisterMedicalExaminationsResultsRequest
{
    
    public registerMedicalExaminationsResultsRequestType RegisterMedicalExaminationsResultsRequest1;
    
    public RegisterMedicalExaminationsResultsRequest()
    {
    }
    
    public RegisterMedicalExaminationsResultsRequest(registerMedicalExaminationsResultsRequestType RegisterMedicalExaminationsResultsRequest1)
    {
        this.RegisterMedicalExaminationsResultsRequest1 = RegisterMedicalExaminationsResultsRequest1;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class RegisterMedicalExaminationsResultsResponse
{
    
    public acknowledgementMessageType AcknowledgementMessage;
    
    public RegisterMedicalExaminationsResultsResponse()
    {
    }
    
    public RegisterMedicalExaminationsResultsResponse(acknowledgementMessageType AcknowledgementMessage)
    {
        this.AcknowledgementMessage = AcknowledgementMessage;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Service/V1.0")]
public partial class notifyCachedHealthClientDetailsUpdateResponseType
{
    
    private string correlationIDField;
    
    private healthCaseIdentifierMsgType[] healthCaseIdentifierListResponseMsgField;
    
    private System.Nullable<bool> successFlagField;
    
    private healtheMedicalErrorResponseMsgType healtheMedicalErrorResponseMsgField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string CorrelationID
    {
        get
        {
            return this.correlationIDField;
        }
        set
        {
            this.correlationIDField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=1)]
    [System.Xml.Serialization.XmlArrayItemAttribute("HealthCaseIdentifierMsg", IsNullable=false)]
    public healthCaseIdentifierMsgType[] HealthCaseIdentifierListResponseMsg
    {
        get
        {
            return this.healthCaseIdentifierListResponseMsgField;
        }
        set
        {
            this.healthCaseIdentifierListResponseMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", IsNullable=true, Order=2)]
    public System.Nullable<bool> SuccessFlag
    {
        get
        {
            return this.successFlagField;
        }
        set
        {
            this.successFlagField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0", Order=3)]
    public healtheMedicalErrorResponseMsgType HealtheMedicalErrorResponseMsg
    {
        get
        {
            return this.healtheMedicalErrorResponseMsgField;
        }
        set
        {
            this.healtheMedicalErrorResponseMsgField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0")]
public partial class healtheMedicalErrorResponseMsgType
{
    
    private string eMedicalErrorCodeField;
    
    private string eMedicalErrorMessageField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=0)]
    public string eMedicalErrorCode
    {
        get
        {
            return this.eMedicalErrorCodeField;
        }
        set
        {
            this.eMedicalErrorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.immi.gov.au/Namespace/Health/Core/V1.0", DataType="token", Order=1)]
    public string eMedicalErrorMessage
    {
        get
        {
            return this.eMedicalErrorMessageField;
        }
        set
        {
            this.eMedicalErrorMessageField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class NotifyCachedHealthClientDetailsUpdateResponseRequest
{
    
    public notifyCachedHealthClientDetailsUpdateResponseType NotifyCachedHealthClientDetailsUpdateResponse;
    
    public NotifyCachedHealthClientDetailsUpdateResponseRequest()
    {
    }
    
    public NotifyCachedHealthClientDetailsUpdateResponseRequest(notifyCachedHealthClientDetailsUpdateResponseType NotifyCachedHealthClientDetailsUpdateResponse)
    {
        this.NotifyCachedHealthClientDetailsUpdateResponse = NotifyCachedHealthClientDetailsUpdateResponse;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "8.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
public partial class NotifyCachedHealthClientDetailsUpdateResponseResponse
{
    
    public acknowledgementMessageType AcknowledgementMessage;
    
    public NotifyCachedHealthClientDetailsUpdateResponseResponse()
    {
    }
    
    public NotifyCachedHealthClientDetailsUpdateResponseResponse(acknowledgementMessageType AcknowledgementMessage)
    {
        this.AcknowledgementMessage = AcknowledgementMessage;
    }
}

}

