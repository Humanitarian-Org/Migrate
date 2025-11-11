using System;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Enterprise
{
    [DataContract(Name = "AcknowledgementMessage", Namespace = "http://www.immi.gov.au/Namespace/Enterprise/AcknowledgementMessage/V1.0")]
    public class AcknowledgementMessage
    {
        [DataMember(Order = 0)]
        public InformationMessagesType Informations { get; set; }

        [DataMember(Order = 1)]
        public WarningMessagesType Warnings { get; set; }

        [DataMember(Order = 2)]
        public AcknowledgementType Acknowledgement { get; set; }
    }
}