# Beneficiary Validation Rules

## Overview

This document serves as the **central source of truth** for all payment validation rules across the AcmeCorp Platform. These rules are implemented in multiple locations and should be kept in sync:



## Validation Categories

### Validation Strategy Overview

The payments validation system employs a **multi-layered approach** with different types of validation rules that work together to ensure data quality, security, and business compliance:

#### **🔒 Data Integrity Validation**
- **Required Field Validation**: Ensures critical information is always provided
- **Format Validation**: Enforces consistent data formats (dates, emails, phone numbers)
- **Length Constraints**: Prevents data overflow and ensures database compatibility
- **Type Safety**: Validates data types and prevents injection attacks

#### **📋 Business Rule Validation**
- **Uniqueness Rules**: Prevents duplicate payments based on document information
- **Reference Data Validation**: Ensures nationality and case worker references are valid
- **Workflow State Management**: Validates case status transitions and business processes
- **External System Integration**: Validates against external country and worker databases

#### **🛡️ Security & Compliance Validation**
- **Input Sanitization**: Prevents malicious input and injection attacks
- **Data Privacy**: Ensures sensitive information meets privacy standards
- **Audit Trail**: Tracks validation decisions for compliance reporting
- **Access Control**: Validates user permissions for data modification

#### **⚡ Performance Optimization Validation**
- **Client-Side Pre-validation**: Reduces server load with frontend validation
- **Bulk Operation Validation**: Optimizes validation for large data imports
- **Caching Strategy**: Leverages cached reference data for faster validation
- **Asynchronous Processing**: Handles complex validations without blocking user interface

---

### 1. Required Fields

#### Core Personal Information

| Field | Property | Required | Length Constraints | Format/Values | Validation Rules | Business Rules |
|-------|----------|----------|-------------------|---------------|------------------|----------------|
| **First Name** | `firstName` | ✅ Yes | Max: 45 chars | String | Non-empty, trimmed | - |
| **Last Name** | `lastName` | ✅ Yes | Max: 100 chars | String | Non-empty, trimmed | - |
| **Date of Birth** | `dateOfBirth` | ✅ Yes | - | `YYYY-MM-DD` (ISO 8601) | Must be valid date, not future, not >150 years ago | Must parse with `DateTime.TryParseExact` |
| **Nationality** | `nationality` | ✅ Yes | Max: 50 chars | String | Non-empty, trimmed | Must exist in supported countries list (TODO) |

#### Core Document Information

| Field | Property | Required | Length Constraints | Format/Values | Validation Rules | Business Rules |
|-------|----------|----------|-------------------|---------------|------------------|----------------|
| **Document Type** | `documentType` | ✅ Yes | Max: 50 chars | Enum | Must be one of allowed values | - |
| **Document Number** | `documentNumber` | ✅ Yes | Min: 3, Max: 50 chars | String | Non-empty, trimmed | Must be unique per document type |

**Valid Document Types:**
- `"Passport"`
- `"National ID"`
- `"Driver License"`
- `"Birth Certificate"`
- `"Other"`

#### Core Case Information

| Field | Property | Required | Length Constraints | Format/Values | Validation Rules | Business Rules |
|-------|----------|----------|-------------------|---------------|------------------|----------------|
| **Case Status** | `caseStatus` | ✅ Yes | - | Enum | Must be one of allowed values | Case-insensitive, normalized to uppercase |

**Valid Case Statuses:**
- `"PENDING"` (Default)
- `"ACTIVE"`
- `"COMPLETED"`
- `"SUSPENDED"`

### 2. Optional Fields with Validation

#### Contact Information

| Field | Property | Required | Length Constraints | Format/Validation | Attributes | Business Rules |
|-------|----------|----------|-------------------|-------------------|------------|----------------|
| **Email** | `email` | ❌ No | Max: 200 chars | Valid email format when provided<br/>Regex: `/^[^\s@]+@[^\s@]+\.[^\s@]+$/` | `[EmailAddress]` | - |
| **Phone** | `phone` | ❌ No | Max: 20 chars | Valid phone format when provided | `[Phone]` | - |

#### Address Information

| Field | Property | Required | Length Constraints | Format/Validation | Attributes | Business Rules |
|-------|----------|----------|-------------------|-------------------|------------|----------------|
| **Address** | `address` | ❌ No | Max: 500 chars | String | - | - |
| **City** | `city` | ❌ No | Max: 100 chars | String | - | - |
| **Country** | `country` | ❌ No | Max: 100 chars | String | - | - |

#### Emergency Contact

| Field | Property | Required | Length Constraints | Format/Validation | Attributes | Business Rules |
|-------|----------|----------|-------------------|-------------------|------------|----------------|
| **Emergency Contact** | `emergencyContact` | ❌ No | Max: 200 chars | String | - | - |
| **Emergency Phone** | `emergencyPhone` | ❌ No | Max: 20 chars | Valid phone format when provided | `[Phone]` | - |

#### Medical Information

| Field | Property | Required | Length Constraints | Format/Validation | Attributes | Business Rules |
|-------|----------|----------|-------------------|-------------------|------------|----------------|
| **Medical Conditions** | `medicalConditions` | ❌ No | Max: 1000 chars | String | - | - |
| **Special Needs** | `specialNeeds` | ❌ No | Max: 1000 chars | String | - | - |

#### Case Management

| Field | Property | Required | Length Constraints | Format/Validation | Attributes | Business Rules |
|-------|----------|----------|-------------------|-------------------|------------|----------------|
| **Case Worker** | `caseWorker` | ❌ No | Max: 200 chars | String | - | Must exist and be active when provided (TODO) |
| **Notes** | `notes` | ❌ No | Max: 2000 chars | String | - | - |

### 3. Tracking Fields (Internal Use)

| Field | Property | Required | Format | Usage | Business Rules |
|-------|----------|----------|--------|-------|----------------|
| **Record ID** | `recordId` | ❌ No | GUID string | Individual record tracking in bulk operations | Auto-generated for bulk uploads |
| **Correlation ID** | `correlationId` | ❌ No | GUID string | Saga correlation and bulk operation tracking | - |
| **Upload ID** | `uploadId` | ❌ No | GUID string | Bulk upload batch identifier | - |

---

## Validation Summary

| Category | Required Fields | Optional Fields | Total Fields | Key Constraints |
|----------|----------------|-----------------|--------------|-----------------|
| **Personal Information** | 4 (firstName, lastName, dateOfBirth, nationality) | 0 | 4 | Date format, length limits |
| **Document Information** | 2 (documentType, documentNumber) | 0 | 2 | Enum values, uniqueness |
| **Case Information** | 1 (caseStatus) | 1 (caseWorker) | 2 | Enum values, external validation |
| **Contact Information** | 0 | 2 (email, phone) | 2 | Format validation |
| **Address Information** | 0 | 3 (address, city, country) | 3 | Length limits |
| **Emergency Contact** | 0 | 2 (emergencyContact, emergencyPhone) | 2 | Format validation |
| **Medical Information** | 0 | 2 (medicalConditions, specialNeeds) | 2 | Length limits |
| **Additional Notes** | 0 | 1 (notes) | 1 | Length limits |
| **Tracking Fields** | 0 | 3 (recordId, correlationId, uploadId) | 3 | GUID format |
| **TOTAL** | **6** | **14** | **20** | - |

## Business Rules & Validations

### 1. Duplicate Prevention Rules

#### Document Uniqueness
```csharp
// Check for duplicate beneficiary based on document number
var isDuplicateDocument = await CheckForDuplicateDocumentAsync(
    registrationDto.DocumentType, 
    registrationDto.DocumentNumber
);

if (isDuplicateDocument)
{
    return ValidationError($"A beneficiary with document {documentType} {documentNumber} already exists");
}
```
## Validation Implementation Layers

| Layer | File Location | Purpose | Validation Type | Technology |
|-------|---------------|---------|-----------------|------------|
| **Frontend Bulk Upload** | `BeneficiaryBulkImport.tsx` | Client-side CSV/Excel validation | Real-time bulk validation | TypeScript/React |
| **Validation Rules Dialog** | `ValidationRulesDialog.tsx` | User guidance and rule display | UI assistance | TypeScript/React |
| **Retry Form Validation** | `RetryBeneficiaryForm.tsx` | Individual record retry validation | Form validation | TypeScript/React |
| **DTO Validation** | `BeneficiaryRegistrationDto.cs` | Data contract validation | Attribute-based validation | C# Data Annotations |
| **Business Logic** | `BeneficiaryManager.cs` | Server-side business rules | Business rule validation | C# Service Layer |


**SQL Query Pattern:**
```sql
SELECT COUNT(*) FROM Beneficiaries 
WHERE DocumentNumber = @documentNumber 
AND DocumentType = @documentType
```

#### Person Duplication Warning
```csharp
// Check for potential duplicate person (warning, not blocking)
var isPotentialDuplicatePerson = await CheckForDuplicatePersonAsync(
    registrationDto.FirstName, 
    registrationDto.LastName, 
    registrationDto.DateOfBirth
);

if (isPotentialDuplicatePerson)
{
    LogWarning($"Potential duplicate person detected: {firstName} {lastName} DOB: {dateOfBirth}");
    // Continue processing but log warning
}
```

**SQL Query Pattern:**
```sql
SELECT COUNT(*) FROM Beneficiaries 
WHERE FirstName = @firstName 
AND LastName = @lastName 
AND DateOfBirth = @dateOfBirth
```

### 2. External Validation Rules

#### Nationality Validation
```csharp
var isValidNationality = await ValidateNationalityAsync(registrationDto.Nationality);
if (!isValidNationality)
{
    return ValidationError($"Nationality '{nationality}' is not supported");
}
```

**Implementation Pattern:**
```sql
SELECT COUNT(*) FROM SupportedCountries 
WHERE CountryCode = @nationality 
OR CountryName = @nationality
```

#### Case Worker Validation
```csharp
if (!string.IsNullOrEmpty(registrationDto.CaseWorker))
{
    var isValidCaseWorker = await ValidateCaseWorkerAsync(registrationDto.CaseWorker);
    if (!isValidCaseWorker)
    {
        return ValidationError($"Case worker '{caseWorker}' is not found or inactive");
    }
}
```

**Implementation Pattern:**
```sql
SELECT IsActive FROM CaseWorkers 
WHERE Name = @caseWorker 
AND IsActive = 1
```

### 3. Data Format Rules

#### Date Format Validation
```csharp
// Date of birth validation
if (!DateTime.TryParseExact(dateOfBirth, "yyyy-MM-dd", null, DateTimeStyles.None, out var date))
{
    return ValidationError("Date of birth must be in YYYY-MM-DD format");
}

if (date > DateTime.Today)
{
    return ValidationError("Date of birth cannot be in the future");
}

if (date < DateTime.Today.AddYears(-150))
{
    return ValidationError("Date of birth cannot be more than 150 years ago");
}
```

#### Email Format Validation
```javascript
// Frontend regex
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
if (email && !emailRegex.test(email)) {
    return ValidationError("Invalid email format");
}
```

```csharp
// Backend attribute
[EmailAddress(ErrorMessage = "Invalid email format")]
```

## Implementation Patterns

### Frontend Validation (TypeScript/React)

```typescript
interface ValidationError {
  row: number;
  field: string;
  message: string;
  value: any;
}

const validateBeneficiaryRecord = (record: any, rowIndex: number): ValidationError[] => {
  const errors: ValidationError[] = [];

  // Required fields validation
  const requiredFields = ['firstName', 'lastName', 'dateOfBirth', 'nationality', 'documentType', 'documentNumber', 'caseStatus'];
  
  for (const field of requiredFields) {
    if (!record[field] || record[field].toString().trim() === '') {
      errors.push({
        row: rowIndex,
        field,
        message: `${field} is required`,
        value: record[field],
      });
    }
  }

  // Date validation
  if (record.dateOfBirth) {
    const dateRegex = /^\d{4}-\d{2}-\d{2}$/;
    if (!dateRegex.test(record.dateOfBirth)) {
      errors.push({
        row: rowIndex,
        field: 'dateOfBirth',
        message: 'Date of birth must be in YYYY-MM-DD format',
        value: record.dateOfBirth,
      });
    } else {
      const date = new Date(record.dateOfBirth);
      if (isNaN(date.getTime()) || date > new Date()) {
        errors.push({
          row: rowIndex,
          field: 'dateOfBirth',
          message: 'Invalid date or future date not allowed',
          value: record.dateOfBirth,
        });
      }
    }
  }

  // Email validation
  if (record.email && record.email.trim() !== '') {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(record.email)) {
      errors.push({
        row: rowIndex,
        field: 'email',
        message: 'Invalid email format',
        value: record.email,
      });
    }
  }

  // Case status validation
  const validStatuses = ['PENDING', 'ACTIVE', 'COMPLETED', 'SUSPENDED'];
  if (record.caseStatus && !validStatuses.includes(record.caseStatus.toUpperCase())) {
    errors.push({
      row: rowIndex,
      field: 'caseStatus',
      message: `Case status must be one of: ${validStatuses.join(', ')}`,
      value: record.caseStatus,
    });
  }

  // Document number validation
  if (record.documentNumber && record.documentNumber.toString().length < 3) {
    errors.push({
      row: rowIndex,
      field: 'documentNumber',
      message: 'Document number must be at least 3 characters',
      value: record.documentNumber,
    });
  }

  return errors;
};
```

### DTO Validation (C# Data Annotations)

```csharp
public class BeneficiaryRegistrationDto
{
    // Required Personal Information
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
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

    // Case Information
    [Required(ErrorMessage = "Case status is required")]
    [RegularExpression("^(PENDING|ACTIVE|COMPLETED|SUSPENDED)$", 
        ErrorMessage = "Case status must be PENDING, ACTIVE, COMPLETED, or SUSPENDED")]
    public string CaseStatus { get; set; } = "PENDING";

    // Custom Validation
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
        if (!string.IsNullOrEmpty(DateOfBirth))
        {
            if (!DateTime.TryParseExact(DateOfBirth, "yyyy-MM-dd", null, DateTimeStyles.None, out var date))
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
}
```

### Business Logic Validation (C# Service Layer)

```csharp
public async Task<BeneficiaryRegistrationResult> RegisterBeneficiaryAsync(BeneficiaryRegistrationDto registrationDto)
{
    try
    {
        // Step 1: Validate input DTO
        var validationResults = registrationDto.Validate();
        if (validationResults.Any())
        {
            var validationErrors = validationResults.Select(v => v.ErrorMessage ?? "Validation error").ToList();
            return new BeneficiaryRegistrationResult
            {
                IsSuccess = false,
                ErrorMessage = "Validation failed",
                ValidationErrors = validationErrors
            };
        }

        // Step 2: Perform business validation
        var businessValidationResult = await ValidateBusinessRulesAsync(registrationDto);
        if (!businessValidationResult.IsValid)
        {
            return new BeneficiaryRegistrationResult
            {
                IsSuccess = false,
                ErrorMessage = businessValidationResult.ErrorMessage,
                ValidationErrors = new List<string> { businessValidationResult.ErrorMessage ?? "Business validation failed" }
            };
        }

        // Step 3: Register the beneficiary
        var beneficiaryId = await CreateBeneficiaryRecordAsync(registrationDto);
        
        return new BeneficiaryRegistrationResult
        {
            IsSuccess = true,
            BeneficiaryId = beneficiaryId
        };
    }
    catch (Exception ex)
    {
        return new BeneficiaryRegistrationResult
        {
            IsSuccess = false,
            ErrorMessage = $"Registration failed: {ex.Message}"
        };
    }
}

private async Task<BusinessValidationResult> ValidateBusinessRulesAsync(BeneficiaryRegistrationDto registrationDto)
{
    // Check for duplicate document
    var isDuplicateDocument = await CheckForDuplicateDocumentAsync(registrationDto.DocumentType, registrationDto.DocumentNumber);
    if (isDuplicateDocument)
    {
        return new BusinessValidationResult 
        { 
            IsValid = false, 
            ErrorMessage = $"A beneficiary with document {registrationDto.DocumentType} {registrationDto.DocumentNumber} already exists" 
        };
    }

    // Check for potential duplicate person (warning only)
    var isPotentialDuplicatePerson = await CheckForDuplicatePersonAsync(registrationDto.FirstName, registrationDto.LastName, registrationDto.DateOfBirth);
    if (isPotentialDuplicatePerson)
    {
        _logger.LogWarning($"Potential duplicate person detected: {registrationDto.FirstName} {registrationDto.LastName} DOB: {registrationDto.DateOfBirth}");
    }

    // Validate nationality
    var isValidNationality = await ValidateNationalityAsync(registrationDto.Nationality);
    if (!isValidNationality)
    {
        return new BusinessValidationResult 
        { 
            IsValid = false, 
            ErrorMessage = $"Nationality '{registrationDto.Nationality}' is not supported" 
        };
    }

    // Validate case worker if provided
    if (!string.IsNullOrEmpty(registrationDto.CaseWorker))
    {
        var isValidCaseWorker = await ValidateCaseWorkerAsync(registrationDto.CaseWorker);
        if (!isValidCaseWorker)
        {
            return new BusinessValidationResult 
            { 
                IsValid = false, 
                ErrorMessage = $"Case worker '{registrationDto.CaseWorker}' is not found or inactive" 
            };
        }
    }

    return new BusinessValidationResult { IsValid = true };
}
```

## Error Message Standards

### Standardized Error Messages

| Validation Type | Error Message Template | Example |
|----------------|----------------------|---------|
| Required Field | `{fieldName} is required` | `First name is required` |
| Max Length | `{fieldName} cannot exceed {maxLength} characters` | `Email cannot exceed 200 characters` |
| Min Length | `{fieldName} must be at least {minLength} characters` | `Document number must be at least 3 characters` |
| Format | `{fieldName} must be in {format} format` | `Date of birth must be in YYYY-MM-DD format` |
| Invalid Value | `{fieldName} must be one of: {validValues}` | `Case status must be one of: PENDING, ACTIVE, COMPLETED, SUSPENDED` |
| Business Rule | `{businessRuleDescription}` | `A beneficiary with document Passport ABC123 already exists` |
| Date Range | `{fieldName} cannot be {constraint}` | `Date of birth cannot be in the future` |
| Email Format | `Invalid email format` | `Invalid email format` |
| Phone Format | `Invalid phone number format` | `Invalid phone number format` |

### Multi-Language Support (Future)

```csharp
// Future implementation for localized error messages
public static class BeneficiaryValidationMessages
{
    public static string GetRequiredFieldMessage(string fieldName, string culture = "en-US")
    {
        return culture switch
        {
            "en-US" => $"{fieldName} is required",
            "fr-FR" => $"{fieldName} est requis",
            "es-ES" => $"{fieldName} es requerido",
            _ => $"{fieldName} is required"
        };
    }
}
```

## TODO: Future Enhancements

| Category | Enhancement | Priority | Description | Status |
|----------|-------------|----------|-------------|---------|
| **Database Validation** | SupportedCountries table | High | Create table for nationality validation | ⏳ Pending |
| **Database Validation** | CaseWorkers table | High | Create table for case worker validation | ⏳ Pending |
| **Database Validation** | DocumentTypes configuration | Medium | Create table for document types | ⏳ Pending |
| **Database Validation** | ValidationRules configuration | Low | Create table for dynamic rules | ⏳ Pending |
| **Advanced Features** | Fuzzy matching | Medium | Duplicate person detection improvement | ⏳ Pending |
| **Advanced Features** | Country-specific phone validation | Medium | Phone format validation by country | ⏳ Pending |
| **Advanced Features** | Address validation | Low | External address validation services | ⏳ Pending |
| **Advanced Features** | Document format validation | Medium | Document number format by type | ⏳ Pending |
| **Performance** | Country list caching | High | Cache supported countries list | ⏳ Pending |
| **Performance** | Batch validation | Medium | Bulk operations optimization | ⏳ Pending |
| **Performance** | Async validation | Medium | Asynchronous validation where appropriate | ⏳ Pending |
| **Monitoring** | Validation failure tracking | High | Track failure rates by field | ⏳ Pending |
| **Monitoring** | Business rule monitoring | Medium | Monitor business rule violations | ⏳ Pending |
| **Monitoring** | Pattern alerting | Low | Alert on unusual validation patterns | ⏳ Pending |

## Version History

| Version | Date | Changes | Author |
|---------|------|---------|--------|
| 1.0 | 2025-10-18 | Initial comprehensive validation rules documentation | GitHub Copilot |

---

**Note:** This document should be updated whenever validation rules change in any of the implementation locations. Use this document as the source of truth for generating validation code across Frontend, DTO, and Business Logic layers.
