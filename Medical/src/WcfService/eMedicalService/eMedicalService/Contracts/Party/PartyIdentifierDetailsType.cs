using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Detailed party identifier with effective dates
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyIdentifierDetailsType
    {
        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public IdentifierTypeType IdentifierType { get; set; }

        [DataMember]
        public DateTime? EffectiveFromDateTime { get; set; }

        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }
}