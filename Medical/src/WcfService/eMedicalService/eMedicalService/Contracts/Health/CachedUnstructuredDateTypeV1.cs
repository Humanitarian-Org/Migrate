using System.Runtime.Serialization;
using System.Xml.Serialization;
using eMedicalService.Contracts.Enterprise.Core.V1;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Cached unstructured date type extending the base UnstructuredDateType
    /// </summary>
    [DataContract(Name = "cachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "cachedUnstructuredDateType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType : UnstructuredDateType
    {
        [DataMember(Order = 3)]
        [XmlElement("CachedEntryKey")]
        public string CachedEntryKey { get; set; }

        [DataMember(Order = 4)]
        [XmlElement("CachedEntryText")]
        public string CachedEntryText { get; set; }
    }
}