using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Enterprise.Core.V1
{
    /// <summary>
    /// Represents an unstructured date type based on the Java UnstructuredDateType
    /// </summary>
    [DataContract(Name = "unstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    [XmlType(TypeName = "unstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    public class UnstructuredDateType
    {
        [DataMember(Order = 0)]
        [XmlElement("UnstructuredDay", IsNullable = true)]
        public string UnstructuredDay { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("UnstructuredMonth", IsNullable = true)]
        public string UnstructuredMonth { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        [XmlElement("UnstructuredYear")]
        public string UnstructuredYear { get; set; }
    }

    /// <summary>
    /// Represents audit information for tracking changes
    /// </summary>
    [DataContract(Name = "auditInformationType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    [XmlType(TypeName = "auditInformationType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    public class AuditInformationType
    {
        [DataMember(Order = 0)]
        [XmlElement("CreateUserId")]
        public string CreateUserId { get; set; }

        [DataMember(Order = 1)]
        [XmlElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Order = 2)]
        [XmlElement("UpdateUserId")]
        public string UpdateUserId { get; set; }

        [DataMember(Order = 3)]
        [XmlElement("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }
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

    /// <summary>
    /// Note text field
    /// </summary>
    [DataContract(Name = "noteTextType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    [XmlType(TypeName = "noteTextType", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0")]
    public class NoteTextType
    {
        [DataMember]
        [XmlText]
        public string Value { get; set; }
    }
}