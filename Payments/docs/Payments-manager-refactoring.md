# Beneficiary Manager Refactoring

## Overview

Replaced the incorrect `IntakeManager` and `IIntakeManager` with proper domain-driven design using `IBeneficiaryManager` and `BeneficiaryManager`. This creates a clean separation of concerns with proper validation, DTOs, and simulated processing delays.

## Changes Made

### 1. **Removed Old Components**
- ❌ `Beneficiary.Domain.Managers.IntakeManager`
- ❌ `Beneficiary.Domain.Managers.IIntakeManager`

### 2. **Created New Architecture**

#### DTOs (`Beneficiary.Domain.DTOs`)
- ✅ `BeneficiaryRegistrationDto` - Clean DTO with validation attributes
- ✅ `BeneficiaryRegistrationResult` - Result pattern for operations

#### Managers (`Beneficiary.Domain.Managers`)
- ✅ `IBeneficiaryManager` - Interface for beneficiary operations
- ✅ `BeneficiaryManager` - Implementation with business logic

### 3. **Key Features Implemented**

#### Input Validation (DTO Level)
```csharp
[Required(ErrorMessage = "First name is required")]
[StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
public string FirstName { get; set; } = string.Empty;

[EmailAddress(ErrorMessage = "Invalid email format")]
public string? Email { get; set; }

[RegularExpression("^(PENDING|ACTIVE|COMPLETED|SUSPENDED)$")]
public string CaseStatus { get; set; } = "PENDING";
```

#### Business Validation (Manager Level)
- **Duplicate Document Check**: Validates document number uniqueness
- **Duplicate Person Check**: Name + DOB validation with fuzzy matching
- **Nationality Validation**: Checks against supported countries
- **Case Worker Validation**: Verifies active case workers
- **All with TODO comments for actual implementation**

#### Simulated Processing Delays
```csharp
// Simulate database/external service call delay (2-4 seconds)
var delayMs = _random.Next(2000, 4001);
await Task.Delay(delayMs);
```

### 4. **Updated Command Handler**

#### Clean Separation Pattern
```csharp
// Map command to DTO for clean separation
var registrationDto = MapCommandToDto(command);

// Call the domain manager to register the beneficiary
var result = await _beneficiaryManager.RegisterBeneficiaryAsync(registrationDto);
```

#### Smart Exception Handling
- **Retryable Exceptions**: Network, timeouts, throttling
- **Non-Retryable Exceptions**: Validation, business rules, format errors

### 5. **Updated API Function**

#### Modern API Patterns
- JSON deserialization to DTO
- Proper HTTP status codes (201 Created, 400 Bad Request, 500 Internal Server Error)
- Structured JSON responses
- Comprehensive error handling

### 6. **Dependency Injection Updates**

#### Endpoint.In Program.cs
```csharp
services.AddScoped<IBeneficiaryManager, BeneficiaryManager>();
```

#### Api Program.cs
```csharp
services.AddScoped<IBeneficiaryManager, BeneficiaryManager>();
```

## Validation Framework

### Input Validation (Immediate)
- ✅ Data Annotations validation
- ✅ Custom date format validation
- ✅ Required field enforcement
- ✅ String length limits
- ✅ Email/phone format validation

### Business Validation (TODO Comments)
- 🔄 **Duplicate Document Check**:
  ```sql
  SELECT COUNT(*) FROM Beneficiaries 
  WHERE DocumentNumber = @documentNumber AND DocumentType = @documentType
  ```

- 🔄 **Duplicate Person Check**:
  ```sql
  SELECT COUNT(*) FROM Beneficiaries 
  WHERE FirstName = @firstName AND LastName = @lastName AND DateOfBirth = @dateOfBirth
  ```

- 🔄 **Nationality Validation**:
  ```sql
  SELECT COUNT(*) FROM SupportedCountries WHERE CountryCode = @nationality
  ```

- 🔄 **Case Worker Validation**:
  ```sql
  SELECT IsActive FROM CaseWorkers WHERE Name = @caseWorker
  ```

## Database Operations (TODO Comments)

### Create Beneficiary Record
```sql
INSERT INTO Beneficiaries (
    BeneficiaryId, FirstName, LastName, DateOfBirth, Nationality, 
    DocumentType, DocumentNumber, Email, Phone, Address, City, Country, 
    EmergencyContact, EmergencyPhone, MedicalConditions, SpecialNeeds, 
    CaseStatus, CaseWorker, Notes, CreatedAt, CreatedBy
) VALUES (
    @beneficiaryId, @firstName, @lastName, @dateOfBirth, @nationality, 
    @documentType, @documentNumber, @email, @phone, @address, @city, @country, 
    @emergencyContact, @emergencyPhone, @medicalConditions, @specialNeeds, 
    @caseStatus, @caseWorker, @notes, @createdAt, @createdBy
)
```

### Audit Trail
```sql
INSERT INTO BeneficiaryAudit (BeneficiaryId, Action, PerformedBy, PerformedAt, Details) 
VALUES (@beneficiaryId, 'CREATED', @userId, @timestamp, @details)
```

## Performance Characteristics

### Simulated Processing Times
- **Business Validation**: 2-4 seconds (simulated database/service calls)
- **Record Creation**: 2-4 seconds (simulated database operations)
- **Individual Validations**: ~50ms each (simulated lookups)

### Benefits
- **Clean Architecture**: Proper domain separation
- **Testable**: Easy to unit test with mocked dependencies
- **Maintainable**: Clear validation and business logic separation
- **Extensible**: Easy to add new validation rules
- **Observable**: Comprehensive logging throughout

## API Usage

### Single Beneficiary Registration
```http
POST /api/MessageIntakeFunction
Content-Type: application/json

{
    "firstName": "John",
    "lastName": "Doe", 
    "dateOfBirth": "1990-01-15",
    "nationality": "Syrian",
    "documentType": "Passport",
    "documentNumber": "SY123456789",
    "email": "john.doe@email.com",
    "caseStatus": "PENDING"
}
```

### Bulk Upload (via Platform)
The existing bulk upload system now uses the same `BeneficiaryManager` through the command handler, ensuring consistent validation and processing across both single and bulk operations.

## Next Steps for Implementation

1. **Database Schema**: Create tables for Beneficiaries, BeneficiaryAudit, SupportedCountries, CaseWorkers
2. **Validation Services**: Implement actual database validation queries
3. **External Integrations**: Connect to Dataverse or other systems
4. **Configuration**: Add supported countries, document types configuration
5. **Monitoring**: Add performance counters and health checks
6. **Testing**: Create comprehensive unit and integration tests