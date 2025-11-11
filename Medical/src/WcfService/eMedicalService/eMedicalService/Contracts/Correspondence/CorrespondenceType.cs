using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Complete correspondence type combining all correspondence components
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public class CorrespondenceType
    {
        /// <summary>
        /// Correspondence header information
        /// </summary>
        [DataMember]
        public CorrespondenceHeaderType Header { get; set; }

        /// <summary>
        /// Correspondence participants (sender, recipients, etc.)
        /// </summary>
        [DataMember]
        public CorrespondenceParticipantListType Participants { get; set; }

        /// <summary>
        /// Correspondence body content
        /// </summary>
        [DataMember]
        public BodyContentBinaryType BodyContent { get; set; }

        /// <summary>
        /// Correspondence attachments
        /// </summary>
        [DataMember]
        public CorrespondenceAttachmentListType Attachments { get; set; }

        /// <summary>
        /// Delivery channels used
        /// </summary>
        [DataMember]
        public List<DeliveryChannelTypeType> DeliveryChannels { get; set; } = new List<DeliveryChannelTypeType>();
    }
}