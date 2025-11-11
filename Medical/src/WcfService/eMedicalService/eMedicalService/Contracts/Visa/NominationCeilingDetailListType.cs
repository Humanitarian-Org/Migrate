using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// List of nomination ceiling details
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class NominationCeilingDetailListType
    {
        /// <summary>
        /// Collection of nomination ceiling details
        /// </summary>
        [DataMember]
        public List<NominationCeilingDetailType> NominationCeilingDetail { get; set; } = new List<NominationCeilingDetailType>();
    }
}