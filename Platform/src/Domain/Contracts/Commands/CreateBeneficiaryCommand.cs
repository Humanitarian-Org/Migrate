namespace Platform.Domain.Contracts.Commands
{
    public class CreateBeneficiaryCommand
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public string RecordId { get; set; } // GUID to track individual beneficiary record
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string MedicalConditions { get; set; }
        public string SpecialNeeds { get; set; }
        public string CaseStatus { get; set; }
        public string CaseWorker { get; set; }
        public string Notes { get; set; }
    }
}