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
}