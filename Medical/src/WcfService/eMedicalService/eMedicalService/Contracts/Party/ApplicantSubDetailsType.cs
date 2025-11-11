using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Party.Core.V1
{
    /// <summary>
    /// Applicant sub details type for applicant-specific information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Party/Core/V1.0")]
    public class ApplicantSubDetailsType
    {
        [DataMember]
        public string ApplicantType { get; set; }

        [DataMember]
        public string ApplicantStatus { get; set; }

        [DataMember]
        public DateTime? ApplicationDate { get; set; }
    }
}