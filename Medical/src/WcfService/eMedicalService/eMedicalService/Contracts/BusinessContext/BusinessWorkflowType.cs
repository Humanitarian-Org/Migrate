using System.Runtime.Serialization;

namespace eMedicalService.Contracts.BusinessContext.Core.V1
{
    /// <summary>
    /// Business workflow type for workflow management
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0")]
    public class BusinessWorkflowType
    {
        /// <summary>
        /// Workflow identifier
        /// </summary>
        [DataMember]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Workflow name or title
        /// </summary>
        [DataMember]
        public string WorkflowName { get; set; }

        /// <summary>
        /// Current workflow status
        /// </summary>
        [DataMember]
        public string WorkflowStatus { get; set; }

        /// <summary>
        /// Business context associated with the workflow
        /// </summary>
        [DataMember]
        public BusinessContextType BusinessContext { get; set; }

        /// <summary>
        /// Events associated with the workflow
        /// </summary>
        [DataMember]
        public BusinessEventListType WorkflowEvents { get; set; }

        /// <summary>
        /// Lodgement channel used for the workflow
        /// </summary>
        [DataMember]
        public LodgementChannelTypeType? LodgementChannel { get; set; }
    }
}