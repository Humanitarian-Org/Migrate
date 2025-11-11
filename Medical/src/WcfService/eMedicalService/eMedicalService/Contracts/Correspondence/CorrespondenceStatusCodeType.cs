using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Correspondence.Core.V1
{
    /// <summary>
    /// Enumeration for correspondence status codes
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0")]
    public enum CorrespondenceStatusCodeType
    {
        /// <summary>
        /// Correspondence has been deleted
        /// </summary>
        [EnumMember]
        DELETED,

        /// <summary>
        /// Correspondence has been sent
        /// </summary>
        [EnumMember]
        SENT,

        /// <summary>
        /// Sent but storage failed
        /// </summary>
        [EnumMember]
        SENT_STORAGE_FAILED,

        /// <summary>
        /// Sent and pending storage
        /// </summary>
        [EnumMember]
        SENT_PENDING_STORAGE,

        /// <summary>
        /// Sent and pending delivery
        /// </summary>
        [EnumMember]
        SENT_PENDING_DELIVERY,

        /// <summary>
        /// Correspondence has been generated
        /// </summary>
        [EnumMember]
        GENERATED,

        /// <summary>
        /// Generated and pending storage
        /// </summary>
        [EnumMember]
        GENERATED_PENDING_STORAGE,

        /// <summary>
        /// Generated but storage failed
        /// </summary>
        [EnumMember]
        GENERATED_STORAGE_FAILED,

        /// <summary>
        /// Draft delivery failed
        /// </summary>
        [EnumMember]
        DRAFT_DELIVERY_FAILED,

        /// <summary>
        /// Correspondence is in draft status
        /// </summary>
        [EnumMember]
        DRAFT,

        /// <summary>
        /// Correspondence is in pre-draft status
        /// </summary>
        [EnumMember]
        PRE_DRAFT
    }
}