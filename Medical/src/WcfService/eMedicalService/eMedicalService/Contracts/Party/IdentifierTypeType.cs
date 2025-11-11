using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Enumeration for identifier types used in the party system
    /// Includes various system identifiers like CDH_PARTY_ID, CID, CSP_ID, etc.
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public enum IdentifierTypeType
    {
        /// <summary>
        /// Common Data Hub Party Identifier
        /// </summary>
        [EnumMember]
        CDH_PARTY_ID,
        
        /// <summary>
        /// Client Identifier
        /// </summary>
        [EnumMember]
        CID,
        
        /// <summary>
        /// Customer Service Portal Identifier
        /// </summary>
        [EnumMember]
        CSP_ID,
        
        /// <summary>
        /// HATS (Health Assessment and Treatment System) Client Identifier
        /// </summary>
        [EnumMember]
        HATS_CLIENT_ID,
        
        /// <summary>
        /// ICSE (Immigration Case Status Enquiry) Agent Identifier
        /// </summary>
        [EnumMember]
        ICSE_AGENT_ID,
        
        /// <summary>
        /// Migration Agent Registration Authority Identifier
        /// </summary>
        [EnumMember]
        MARA_ID,
        
        /// <summary>
        /// Person Identifier
        /// </summary>
        [EnumMember]
        PID,
        
        /// <summary>
        /// Revenue Receipting Identifier
        /// </summary>
        [EnumMember]
        REVENUE_RECEIPTING_ID,
        
        /// <summary>
        /// Sponsor Client Identifier
        /// </summary>
        [EnumMember]
        SCID
    }
}