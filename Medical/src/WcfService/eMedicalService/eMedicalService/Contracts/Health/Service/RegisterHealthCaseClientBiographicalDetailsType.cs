using System;
using System.Runtime.Serialization;
using eMedicalService.Contracts.Health.Messaging;
using eMedicalService.Contracts.Address;

namespace eMedicalService.Contracts.Health.Service
{
    [DataContract(Name = "RegisterHealthCaseClientBiographicalDetailsType", Namespace = "http://www.immi.gov.au/Namespace/Health/Service/V2.0")]
    public class RegisterHealthCaseClientBiographicalDetailsType
    {
        [DataMember]
        public string Title { get; set; } = string.Empty;

        [DataMember]
        public string GivenName { get; set; } = string.Empty;

        [DataMember]
        public string FamilyName { get; set; } = string.Empty;

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string Gender { get; set; } = string.Empty;

        [DataMember]
        public string CountryOfBirth { get; set; } = string.Empty;

        [DataMember]
        public string Nationality { get; set; } = string.Empty;

        [DataMember]
        public HealthIdentityDocumentMsgType HealthIdentityDocument { get; set; }

        [DataMember]
        public AddressMsgType Address { get; set; }

        [DataMember]
        public string EmailAddress { get; set; } = string.Empty;

        [DataMember]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}