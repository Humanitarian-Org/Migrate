using System;

namespace Platform.Domain.Models
{
#nullable enable
    public class BeneficiaryRecord
    {
        public string RecordId { get; set; } = Guid.NewGuid().ToString(); // GUID generated in browser
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? MedicalConditions { get; set; }
        public string? SpecialNeeds { get; set; }
        public string CaseStatus { get; set; } = "PENDING";
        public string? CaseWorker { get; set; }
        public string? Notes { get; set; }
        public ProcessingResult? Result { get; set; } // Processing status and result details
    }
    
    public class ProcessingResult
    {
        public string Status { get; set; } = "Pending"; // "Pending", "Success", "Failed"
        public string? BeneficiaryId { get; set; } // Generated when successful
        public string? ErrorMessage { get; set; } // Error details when failed
        public DateTimeOffset? ProcessedAt { get; set; } // When processing completed
    }

    public class BulkBeneficiaryUploadRequest
    {
        public string UploadId { get; set; } = string.Empty;
        public string CorrelationId { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public BeneficiaryRecord[] Records { get; set; } = Array.Empty<BeneficiaryRecord>();
    }
}