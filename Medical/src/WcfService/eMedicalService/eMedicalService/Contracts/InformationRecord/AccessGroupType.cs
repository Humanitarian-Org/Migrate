using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Access group type for record access control
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public class AccessGroupType
    {
        /// <summary>
        /// Access group identifier
        /// </summary>
        [DataMember]
        public string AccessGroupId { get; set; }

        /// <summary>
        /// Access group name
        /// </summary>
        [DataMember]
        public string AccessGroupName { get; set; }

        /// <summary>
        /// Access group description
        /// </summary>
        [DataMember]
        public string AccessGroupDescription { get; set; }

        /// <summary>
        /// Access level or permissions
        /// </summary>
        [DataMember]
        public string AccessLevel { get; set; }
    }
}