using System.Runtime.Serialization;

namespace eMedicalService.Contracts.InformationRecord.Core.V1
{
    /// <summary>
    /// Enumeration for address role types in information records
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0")]
    public enum AddressRoleTypeType
    {
        /// <summary>
        /// Primary residential address
        /// </summary>
        [EnumMember]
        PRIMARY_RESIDENTIAL,

        /// <summary>
        /// Secondary or mailing address
        /// </summary>
        [EnumMember]
        MAILING,

        /// <summary>
        /// Business address
        /// </summary>
        [EnumMember]
        BUSINESS,

        /// <summary>
        /// Temporary address
        /// </summary>
        [EnumMember]
        TEMPORARY
    }
}