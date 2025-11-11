using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Enterprise.Core.V1
{
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
}