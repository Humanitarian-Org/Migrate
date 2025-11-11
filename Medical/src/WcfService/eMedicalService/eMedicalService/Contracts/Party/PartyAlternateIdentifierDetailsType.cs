using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Detailed alternate party identifier with metadata
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class PartyAlternateIdentifierDetailsType
    {
        [DataMember]
        public string AlternateIdentifier { get; set; }

        [DataMember]
        public string AlternateIdentifierType { get; set; }

        [DataMember]
        public DateTime? EffectiveFromDateTime { get; set; }

        [DataMember]
        public DateTime? EffectiveToDateTime { get; set; }
    }
}