using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beneficiary.Domain.DTOs
{
#nullable enable
    public class BeneficiaryRegistrationDto
    {
        // Tracking Information
        public string? RecordId { get; set; } // GUID from bulk upload for tracking
        public string? CorrelationId { get; set; } // For saga correlation
        public string? UploadId { get; set; } // Bulk upload identifier

        // Required Personal Information
        [Required(ErrorMessage = "First name is required")]
        [StringLength(40, ErrorMessage = "First name cannot exceed 40 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public string DateOfBirth { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nationality is required")]
        [StringLength(50, ErrorMessage = "Nationality cannot exceed 50 characters")]
        public string Nationality { get; set; } = string.Empty;

        // Required Document Information
        [Required(ErrorMessage = "Document type is required")]
        [StringLength(50, ErrorMessage = "Document type cannot exceed 50 characters")]
        public string DocumentType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Document number is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Document number must be between 3 and 50 characters")]
        public string DocumentNumber { get; set; } = string.Empty;

        // Optional Contact Information
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string? Phone { get; set; }

        // Optional Address Information
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        public string? Address { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string? Country { get; set; }

        // Optional Emergency Contact
        [StringLength(200, ErrorMessage = "Emergency contact name cannot exceed 200 characters")]
        public string? EmergencyContact { get; set; }

        [Phone(ErrorMessage = "Invalid emergency phone number format")]
        [StringLength(20, ErrorMessage = "Emergency phone number cannot exceed 20 characters")]
        public string? EmergencyPhone { get; set; }

        // Optional Medical Information
        [StringLength(1000, ErrorMessage = "Medical conditions cannot exceed 1000 characters")]
        public string? MedicalConditions { get; set; }

        [StringLength(1000, ErrorMessage = "Special needs cannot exceed 1000 characters")]
        public string? SpecialNeeds { get; set; }

        // Required Case Information
        [Required(ErrorMessage = "Case status is required")]
        [RegularExpression("^(PENDING|ACTIVE|COMPLETED|SUSPENDED)$", 
            ErrorMessage = "Case status must be PENDING, ACTIVE, COMPLETED, or SUSPENDED")]
        public string CaseStatus { get; set; } = "PENDING";

        [StringLength(200, ErrorMessage = "Case worker name cannot exceed 200 characters")]
        public string? CaseWorker { get; set; }

        [StringLength(2000, ErrorMessage = "Notes cannot exceed 2000 characters")]
        public string? Notes { get; set; }

        /// <summary>
        /// Validates the DTO and returns validation results
        /// </summary>
        public List<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, true);

            // Additional custom validation
            ValidateDateOfBirth(results);
            ValidateRequiredFields(results);

            return results;
        }

        private void ValidateDateOfBirth(List<ValidationResult> results)
        {
            // TODO: Validate date of birth format (YYYY-MM-DD)
            // TODO: Validate date of birth is not in the future
            // TODO: Validate date of birth is within reasonable range (e.g., not more than 150 years ago)
            if (!string.IsNullOrEmpty(DateOfBirth))
            {
                if (!DateTime.TryParseExact(DateOfBirth, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var date))
                {
                    results.Add(new ValidationResult("Date of birth must be in YYYY-MM-DD format", new[] { nameof(DateOfBirth) }));
                }
                else if (date > DateTime.Today)
                {
                    results.Add(new ValidationResult("Date of birth cannot be in the future", new[] { nameof(DateOfBirth) }));
                }
                else if (date < DateTime.Today.AddYears(-150))
                {
                    results.Add(new ValidationResult("Date of birth cannot be more than 150 years ago", new[] { nameof(DateOfBirth) }));
                }
            }
        }

        private void ValidateRequiredFields(List<ValidationResult> results)
        {
            // TODO: Add any additional business-specific required field validation
            // TODO: Validate document type against allowed values from configuration
            // TODO: Validate nationality against ISO country codes
        }
    }

    public class BeneficiaryRegistrationResult
    {
        public bool IsSuccess { get; set; }
        public string? BeneficiaryId { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> ValidationErrors { get; set; } = new();
        public DateTimeOffset ProcessedAt { get; set; } = DateTimeOffset.UtcNow;
        public bool DryRun { get; set; }
    }
}