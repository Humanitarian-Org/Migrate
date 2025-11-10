# eMedical Service - Complete Contract Recreation

This document outlines the systematic recreation of all Java contracts for the eMedical WCF service.

## Discovered Domains from Java Analysis

Based on the directory structure analysis of `au.gov.immi.namespace`, we have the following domains:

### 1. Address Domain (✅ COMPLETED)
- **Namespace:** `http://www.immi.gov.au/Namespace/Address/Core/V1.0`  
- **Location:** `c:\Dev\Humanitarian-org\Migrate\Medical\src\WcfService\eMedicalService\eMedicalService\Contracts\Address\AddressTypes.cs`
- **Types:** ContactMethodTypeType, PartyAddressType, SemistructuredAddressType, TelephoneLineType, FaxAddressType

### 2. BusinessContext Domain
- **Java Package:** `au.gov.immi.namespace.businesscontext.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/BusinessContext/Core/V1.0`
- **Key Types:** BusinessContextType, BusinessEventType, BusinessServiceIdentifierType, LodgementChannelTypeType

### 3. Correspondence Domain  
- **Java Package:** `au.gov.immi.namespace.correspondence.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/Correspondence/Core/V1.0`

### 4. Departmental Domain
- **Java Package:** `au.gov.immi.namespace.departmental.core.v1`  
- **Namespace:** `http://www.immi.gov.au/Namespace/Departmental/Core/V1.0`

### 5. Document Domain
- **Java Package:** `au.gov.immi.namespace.document.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/Document/Core/V1.0`

### 6. Enterprise Domain (🔄 PARTIALLY COMPLETE)
- **Java Package:** `au.gov.immi.namespace.enterprise.{core|acknowledgementmessage|errormessages|informationmessages|warningmessages}.v1`
- **Existing:** Basic core types in CoreTypes.cs
- **Need to Add:** All sub-domains (acknowledgement, error, information, warning messages)

### 7. Health Domain (🔄 PARTIALLY COMPLETE)
- **Java Package:** `au.gov.immi.namespace.health.{core|messaging|service}.{v1|v2}`
- **Existing:** Core types and service messages
- **Need to Add:** Health service v1, v2 types, additional messaging types

### 8. InformationRecord Domain
- **Java Package:** `au.gov.immi.namespace.informationrecord.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/InformationRecord/Core/V1.0`

### 9. Party Domain
- **Java Package:** `au.gov.immi.namespace.party.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/Party/Core/V1.0`  
- **Key Types:** PartyIdentifierType, PartyRoleIdentifierType, PartySystemIdentifierType, SearchIndexIdentifierType

### 10. PersonIdentity Domain
- **Java Package:** `au.gov.immi.namespace.personidentity.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0`

### 11. Visa Domain
- **Java Package:** `au.gov.immi.namespace.visa.core.v1`
- **Namespace:** `http://www.immi.gov.au/Namespace/Visa/Core/V1.0`
- **Key Types:** VisaType, VisaStatusType, VisaConditionType, UnstructuredGrantDateType

## Contract Organization Strategy

```
Contracts/
├── Address/
│   └── AddressTypes.cs ✅
├── BusinessContext/  
│   └── BusinessContextTypes.cs
├── Correspondence/
│   └── CorrespondenceTypes.cs  
├── Departmental/
│   └── DepartmentalTypes.cs
├── Document/
│   └── DocumentTypes.cs
├── Enterprise/
│   ├── CoreTypes.cs ✅ (basic)
│   ├── AcknowledgementTypes.cs
│   ├── ErrorTypes.cs
│   ├── InformationTypes.cs
│   └── WarningTypes.cs
├── Health/
│   ├── HealthTypes.cs ✅ (basic)  
│   ├── ServiceMessages.cs ✅ (basic)
│   ├── ServiceResponses.cs ✅ (basic)
│   ├── ServiceV1Types.cs
│   ├── ServiceV2Types.cs
│   └── MessagingTypes.cs
├── InformationRecord/
│   └── InformationRecordTypes.cs
├── Party/
│   └── PartyTypes.cs
├── PersonIdentity/
│   └── PersonIdentityTypes.cs
└── Visa/
    └── VisaTypes.cs
```

## Implementation Approach

### Immediate Priority (Core System Dependencies)
1. **Enterprise Domain** - Complete all missing types (acknowledgement, error, information, warning)
2. **Health Domain** - Complete service v1/v2 and messaging types  
3. **Party Domain** - Identifier and role types used throughout system
4. **Document Domain** - Document types and attachments

### Secondary Priority (Extended Functionality)  
5. **PersonIdentity Domain** - Biographic and identity information
6. **Visa Domain** - Visa-related types and statuses
7. **BusinessContext Domain** - Business process contexts
8. **Departmental Domain** - Department-specific types

### Utility Priority (Supporting Types)
9. **Correspondence Domain** - Communication and messaging
10. **InformationRecord Domain** - Information management types

## Java File Count Analysis

Total Java files found: **664** in `au.gov.immi.namespace` packages

This represents a comprehensive type system that needs systematic recreation to match the Java legacy system exactly.

## Next Steps

1. Create contracts systematically by domain priority
2. Focus on types that are referenced in service operations first
3. Ensure all namespace mappings match Java package structure exactly  
4. Test contract generation and XML serialization with existing samples
5. Update service interface to use complete type system