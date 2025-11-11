using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Enterprise.Core.V1
{
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