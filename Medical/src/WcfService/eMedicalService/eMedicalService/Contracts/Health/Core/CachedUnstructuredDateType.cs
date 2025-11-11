using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Core
{
    [XmlType(TypeName = "CachedCreationDate", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class CachedUnstructuredDateType
    {
        [XmlElement("UnstructuredYear", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredYear { get; set; } = string.Empty;

        [XmlElement("UnstructuredMonth", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredMonth { get; set; } = string.Empty;

        [XmlElement("UnstructuredDay", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredDay { get; set; } = string.Empty;

        [XmlElement("UnstructuredHour", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredHour { get; set; } = string.Empty;

        [XmlElement("UnstructuredMinute", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredMinute { get; set; } = string.Empty;

        [XmlElement("UnstructuredSecond", Namespace = "http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0")]
        public string UnstructuredSecond { get; set; } = string.Empty;
    }
}