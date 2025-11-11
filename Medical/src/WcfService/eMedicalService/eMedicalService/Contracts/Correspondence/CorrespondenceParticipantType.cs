using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Correspondence participant type for sender/recipient information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceParticipantType
    {
        /// <summary>
        /// Role in the correspondence
        /// </summary>
        [DataMember]
        public CorrespondenceRoleTypeType Role { get; set; }

        /// <summary>
        /// Participant name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [DataMember]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Postal address
        /// </summary>
        [DataMember]
        public string PostalAddress { get; set; }

        /// <summary>
        /// Fax number
        /// </summary>
        [DataMember]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Party identifier for the participant
        /// </summary>
        [DataMember]
        public string PartyIdentifier { get; set; }

        /// <summary>
        /// Preferred delivery channel
        /// </summary>
        [DataMember]
        public DeliveryChannelTypeType? PreferredDeliveryChannel { get; set; }
    }
}