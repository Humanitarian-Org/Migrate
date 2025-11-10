# eMedical Service - Corrected Contracts

## Overview

This document describes the corrected C# contracts for the eMedical WCF service, now properly mapped to match the Java legacy system implementation.

## Contract Structure Based on Java Analysis

The contracts have been recreated by analyzing the Java source code structure from `au.gov.immi.namespace` packages:

### Package Mapping

| Java Package | C# Namespace | Purpose |
|-------------|-------------|---------|
| `au.gov.immi.namespace.enterprise.core.v1` | `eMedicalService.Contracts.Enterprise.Core.V1` | Core enterprise types |
| `au.gov.immi.namespace.health.core.v1` | `eMedicalService.Contracts.Health.Core.V1` | Health domain types |
| `au.gov.immi.namespace.health.messaging.service.v1` | `eMedicalService.Contracts.Health.Messaging.Service.V1` | Service messages |

### Key Java Classes Analyzed

1. **UnstructuredDateType.java** → `UnstructuredDateType.cs`
   - Basic date structure with UnstructuredDay, UnstructuredMonth, UnstructuredYear

2. **CachedUnstructuredDateType.java** → `CachedUnstructuredDateType.cs`
   - Extends UnstructuredDateType with CachedEntryKey and CachedEntryText

3. **HealthCaseIdentifierMsgType.java** → `HealthCaseIdentifierMsgType.cs`
   - Health case identifier messaging type

4. **CacheHealthCaseDetailsRequestType.java** → `CacheHealthCaseDetailsRequestType.cs`
   - Primary request type for caching operations

## Contract Files

### Core Enterprise Types
**File:** `Contracts/Enterprise/CoreTypes.cs`
- `UnstructuredDateType` - Basic date structure
- `AuditInformationType` - Audit tracking
- `AcknowledgementType` - Success enumeration
- `NoteTextType` - Text field wrapper

**XML Namespace:** `http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0`

### Health Domain Types
**File:** `Contracts/Health/HealthTypes.cs`
- `CachedUnstructuredDateType` - Extended date with caching
- `HealthCaseIdentifierType` - Health case ID wrapper
- `HealthCaseIdentifierMsgType` - Messaging wrapper for identifiers
- `PersonNameType` - Person name structure
- `MedicalExaminationType` - Medical examination details
- `HealthCaseType` - Complete health case information

**XML Namespace:** `http://www.immi.gov.au/Namespace/Health/Core/V1.0`

### Service Request Messages
**File:** `Contracts/Health/ServiceMessages.cs`
- `CacheHealthCaseDetailsRequestType`
- `RegisterHealthCaseRequestType`
- `NotifyMedicalExaminationStatusRequestType`
- `RegisterMedicalExaminationsResultsRequestType`
- `DeleteCachedHealthCaseRequestType`
- `GetCachedHealthCaseRequestType`
- `GetHealthCaseStatusRequestType`
- `UpdateMedicalExaminationRequestType`

**XML Namespace:** `http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0`

### Service Response Messages
**File:** `Contracts/Health/ServiceResponses.cs`
- `AcknowledgementResponseType` - Base response type
- Response types for each request (RegisterHealthCaseResponseType, etc.)

**XML Namespace:** `http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0`

## Service Contract

### Interface
**File:** `IeMedicalIntegrationServiceCorrect.cs`

The service contract now properly defines:
- Correct namespace: `http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0`
- Proper action URIs matching the namespace pattern
- Strongly-typed request/response parameters instead of XML elements

### Implementation
**File:** `eMedicalIntegrationServiceImplementation.cs`

Basic implementation with:
- Proper error handling
- Logging placeholders
- TODO markers for integration with existing Medical system components
- Structured response creation

## Key Improvements Over WSDL-Generated Contracts

1. **Proper Namespace Hierarchy**: Matches Java package structure exactly
2. **Inheritance Patterns**: CachedUnstructuredDateType properly extends UnstructuredDateType
3. **XML Serialization**: Correct XmlElement and DataMember attributes
4. **Type Safety**: Strongly-typed contracts instead of generic XmlElement parameters
5. **Java Compatibility**: Field names and structures match Java JAXB annotations

## XML Namespace Pattern

All namespaces follow the pattern discovered in Java source:
```
http://www.immi.gov.au/Namespace/{Domain}/{Subdomain}/V{Version}.0
```

Examples:
- Enterprise Core: `http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0`
- Health Core: `http://www.immi.gov.au/Namespace/Health/Core/V1.0`
- Health Messaging Service: `http://www.immi.gov.au/Namespace/Health/MessagingService/V1.0`

## Integration with Existing System

To integrate with your existing Medical system Azure Functions and NServiceBus endpoints:

1. **API Layer**: Modify `MessageIntakeFunction` to route to WCF operations
2. **Message Processing**: Use `Endpoint.In` to process health case messages
3. **Data Storage**: Integrate with existing CosmosDB repositories
4. **Event Publishing**: Use existing NServiceBus infrastructure

## Testing

Use the sample XML files in the `Samples` folder to test the corrected contracts:
- RegisterHealthCase-Sample.xml
- NotifyMedicalExaminationStatus-Sample.xml
- RegisterMedicalExaminationsResults-Sample.xml
- DeleteCachedHealthCase-Sample.xml
- GetCachedHealthCase-Sample.xml
- GetHealthCaseStatus-Sample.xml
- UpdateMedicalExamination-Sample.xml
- CacheHealthCaseDetails-Sample.xml

## Next Steps

1. Update the service implementation to integrate with your existing Medical system components
2. Update Web.config to use the new interface (`IeMedicalIntegrationServiceCorrect`)
3. Build and test with sample XML data
4. Implement proper business logic in each operation
5. Add comprehensive error handling and logging
6. Integrate with existing CosmosDB and NServiceBus infrastructure