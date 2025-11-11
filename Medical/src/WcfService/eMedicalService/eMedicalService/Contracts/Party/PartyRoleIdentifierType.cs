using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Party role identifier containing role identifier and role type
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyRoleIdentifierType
    {
        [DataMember]
        public string RoleIdentifier { get; set; }

        [DataMember]
        public RoleIdentifierTypeType RoleIdentifierType { get; set; }
    }
}