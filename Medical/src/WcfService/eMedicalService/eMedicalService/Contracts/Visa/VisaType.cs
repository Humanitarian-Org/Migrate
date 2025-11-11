using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eMedicalService.Contracts.Visa.Core.V1
{
    /// <summary>
    /// Core visa type for comprehensive visa information
    /// </summary>
    [DataContract(Namespace = "http://www.immi.gov.au/Namespace/Visa/Core/V1.0")]
    public class VisaType
    {
        /// <summary>
        /// Visa grant number
        /// </summary>
        [DataMember]
        public string VisaGrantNumber { get; set; }

        /// <summary>
        /// Visa grant date
        /// </summary>
        [DataMember]
        public DateTime GrantDate { get; set; }

        /// <summary>
        /// Grant by code (granting authority)
        /// </summary>
        [DataMember]
        public string GrantByCode { get; set; }

        /// <summary>
        /// Visa class code
        /// </summary>
        [DataMember]
        public string VisaClassCode { get; set; }

        /// <summary>
        /// Visa subclass code
        /// </summary>
        [DataMember]
        public string VisaSubclassCode { get; set; }

        /// <summary>
        /// Visa stream
        /// </summary>
        [DataMember]
        public string VisaStream { get; set; }

        /// <summary>
        /// Visa entries allowed code
        /// </summary>
        [DataMember]
        public string VisaEntriesAllowedCode { get; set; }

        /// <summary>
        /// Visa entry expiry date
        /// </summary>
        [DataMember]
        public DateTime? VisaEntryExpiryDate { get; set; }

        /// <summary>
        /// Visa stay period code
        /// </summary>
        [DataMember]
        public string VisaStayPeriodCode { get; set; }

        /// <summary>
        /// Date until which visa is in effect
        /// </summary>
        [DataMember]
        public DateTime? VisaInEffectUntilDate { get; set; }

        /// <summary>
        /// Initial visa stay until date
        /// </summary>
        [DataMember]
        public DateTime? InitialVisaStayUntilDate { get; set; }

        /// <summary>
        /// Migrant entry expiry date
        /// </summary>
        [DataMember]
        public DateTime? MigrantEntryExpiryDate { get; set; }

        /// <summary>
        /// Visa condition codes
        /// </summary>
        [DataMember]
        public List<int> VisaConditionCode { get; set; } = new List<int>();

        /// <summary>
        /// Detailed visa conditions
        /// </summary>
        [DataMember]
        public VisaConditionListType VisaConditions { get; set; }

        /// <summary>
        /// Visa classification
        /// </summary>
        [DataMember]
        public VisaClassificationType VisaClassification { get; set; }

        /// <summary>
        /// Current visa status
        /// </summary>
        [DataMember]
        public VisaStatusType VisaStatus { get; set; }

        /// <summary>
        /// Preferred travel document
        /// </summary>
        [DataMember]
        public PreferredTravelIdentityDocumentType PreferredTravelDocument { get; set; }

        /// <summary>
        /// Lodgement method
        /// </summary>
        [DataMember]
        public LodgementMethodTypeType? LodgementMethod { get; set; }
    }
}