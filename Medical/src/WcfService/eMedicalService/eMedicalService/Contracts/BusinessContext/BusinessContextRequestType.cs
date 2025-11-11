using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business context request type for context operations
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessContextRequestType
    {
        /// <summary>
        /// Business context information
        /// </summary>
        [DataMember]
        public BusinessContextType BusinessContext { get; set; }

        /// <summary>
        /// Business service identifiers
        /// </summary>
        [DataMember]
        public BusinessServiceIdentifierListType ServiceIdentifiers { get; set; }

        /// <summary>
        /// Business workflow information
        /// </summary>
        [DataMember]
        public BusinessWorkflowType Workflow { get; set; }

        /// <summary>
        /// Request timestamp
        /// </summary>
        [DataMember]
        public DateTime RequestTimestamp { get; set; }

        /// <summary>
        /// Requesting user or system identifier
        /// </summary>
        [DataMember]
        public string RequestorId { get; set; }
    }
}