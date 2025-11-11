using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Departmental.Core.V1
{
    /// <summary>
    /// Departmental organizational unit type for department structure
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Departmental/Core/V1.0")]
    public class DepartmentalUnitType
    {
        /// <summary>
        /// Unit identifier
        /// </summary>
        [DataMember]
        public string UnitId { get; set; }

        /// <summary>
        /// Unit name
        /// </summary>
        [DataMember]
        public string UnitName { get; set; }

        /// <summary>
        /// Unit type or category
        /// </summary>
        [DataMember]
        public string UnitType { get; set; }

        /// <summary>
        /// Parent unit identifier
        /// </summary>
        [DataMember]
        public string ParentUnitId { get; set; }

        /// <summary>
        /// Unit manager or supervisor
        /// </summary>
        [DataMember]
        public DepartmentalOfficerType UnitManager { get; set; }

        /// <summary>
        /// Unit location
        /// </summary>
        [DataMember]
        public string UnitLocation { get; set; }
    }
}