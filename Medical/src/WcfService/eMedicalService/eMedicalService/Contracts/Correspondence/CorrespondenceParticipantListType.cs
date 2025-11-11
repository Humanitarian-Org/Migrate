using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// List of correspondence participants
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceParticipantListType
    {
        /// <summary>
        /// Collection of participants
        /// </summary>
        [DataMember]
        public List<CorrespondenceParticipantType> Participant { get; set; } = new List<CorrespondenceParticipantType>();
    }
}