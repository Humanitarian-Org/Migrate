using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eMedicalService.Contracts.Health.Core.V1
{
    /// <summary>
    /// Medical examination type
    /// </summary>
    [DataContract(Name = "medicalExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    [XmlType(TypeName = "medicalExaminationType", Namespace = "http://www.immi.gov.au/Namespace/Health/Core/V1.0")]
    public class MedicalExaminationType
    {
        [DataMember]
        [XmlElement("ExaminationTypeCode")]
        public string ExaminationTypeCode { get; set; }

        [DataMember]
        [XmlElement("ExaminationTypeDescription")]
        public string ExaminationTypeDescription { get; set; }

        [DataMember]
        [XmlElement("Status")]
        public MedicalExaminationStatus Status { get; set; }

        [DataMember]
        [XmlElement("ExaminationDate")]
        public CachedUnstructuredDateType ExaminationDate { get; set; }

        [DataMember]
        [XmlElement("ExaminationCentre")]
        public string ExaminationCentre { get; set; }
    }
}