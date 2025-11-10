# eMedical WCF Service - Sample XML Messages

This folder contains comprehensive sample XML messages for all operations supported by the eMedical WCF Service. These samples are based on real data from the legacy eMedical system and demonstrate the full structure of each message type.

## Sample Files Overview

### Request Messages

1. **01_RegisterHealthCaseRequest.xml**
   - **Operation**: `RegisterHealthCase`
   - **Description**: Registers a new health case with complete patient biographical details, case identifiers, clinic information, and health requirements
   - **Key Elements**: Patient details (Maria Mañego), multiple case identifiers, clinic information, identity documents, contact details, visa context, and health requirements (501, 502)
   - **Based on**: Real data from MañegoMa-100000000000000001

2. **02_NotifyMedicalExaminationStatusRequest.xml**
   - **Operation**: `NotifyMedicalExaminationStatus`
   - **Description**: Notifies the system of medical examination status updates
   - **Key Elements**: Health case identifiers, status updates, examination details, and client context
   - **Sample Data**: Examination completed status with detailed results

3. **03_DeleteCachedHealthCaseRequest.xml**
   - **Operation**: `DeleteCachedHealthCase`
   - **Description**: Requests deletion of cached health case information
   - **Key Elements**: Case identifiers, deletion reason, requesting user details, and deletion timestamp
   - **Use Case**: Case completion and archival

4. **04_RegisterMedicalExaminationsResultsRequest.xml**
   - **Operation**: `RegisterMedicalExaminationsResults`
   - **Description**: Submits comprehensive medical examination results with attachments
   - **Key Elements**: Identity documents, facial images, medical forms, attachments (X-rays, blood tests), examination results for multiple requirements (501: General Medical, 502: Chest X-ray)
   - **Attachments**: Sample base64-encoded image and PDF data

5. **05_NotifyCachedHealthClientDetailsUpdateResponse.xml**
   - **Operation**: `NotifyCachedHealthClientDetailsUpdateResponse`
   - **Description**: Responds to client details update notifications
   - **Key Elements**: Update outcomes, field-level changes tracking, client details, and audit information
   - **Sample Updates**: Email, phone number, and address changes

### Response Messages

6. **06_AcknowledgementMessage_SuccessResponse.xml**
   - **Type**: Success Response
   - **Description**: Standard successful acknowledgement with informational messages and warnings
   - **Structure**: Informations (successful processing notifications), Warnings (non-critical alerts), Acknowledgement (SUCCESS status)
   - **Use Case**: Normal successful processing with informational feedback

7. **07_EnterpriseErrors_FaultResponse.xml**
   - **Type**: Error Response (SOAP Fault)
   - **Description**: Error response when validation or processing failures occur
   - **Structure**: SOAP fault with detailed EnterpriseErrors information including error codes, descriptions, and field-level validation details
   - **Use Case**: Document format validation error with suggested corrections

## Message Structure Patterns

### Common Elements Across Messages

- **CorrelationID**: Unique identifier for message tracking (e.g., "100000000000000001")
- **SOAP Security**: WS-Security headers with timestamps and binary security tokens
- **WS-Addressing**: Action, MessageID, To, ReplyTo headers for proper message routing
- **Namespace Declarations**: Proper XML namespaces for all Australian immigration message schemas

### Health Case Identifiers

All messages use multiple case identifier types:
- **UMI** (Unique Migration Identifier): U000010002
- **IME** (Immigration Medical Examination): 40033127  
- **IOMGID** (IOM Global Identifier): 9191

### Date/Time Formats

The system uses both structured and unstructured date formats:
- **Structured**: ISO 8601 format (2025-11-10T10:15:00Z)
- **Unstructured**: Separate year, month, day, hour, minute, second elements

### Document Types

- **Type "01"**: Standard identity document (passport/national ID)
- **Issuing Countries**: Three-letter codes (AFG for Afghanistan)

## Testing the Service

### Using the Samples

1. **Start the WCF Service**: Run the eMedical service on http://localhost:55766/eMedicalIntegrationService.svc
2. **View WSDL**: Navigate to http://localhost:55766/eMedicalIntegrationService.svc?wsdl
3. **Test with SOAP Client**: Use tools like SoapUI, Postman, or .NET HttpClient to send the sample XML
4. **Modify Sample Data**: Update correlation IDs, case numbers, and patient details as needed

### Expected Responses

- **Success**: Returns AcknowledgementMessage with SUCCESS status and optional informational messages
- **Validation Errors**: Returns SOAP fault with EnterpriseErrors detailing validation failures
- **System Errors**: Returns appropriate fault codes with error descriptions

## Data Validation Notes

### Required Fields
- CorrelationID must be unique per message
- Health case identifiers are required for all case-related operations
- Patient biographical details must include given name, family name, and date of birth
- Document numbers must follow specific format patterns per document type

### Optional Elements
- Warning messages in responses are optional and appear only when relevant
- Some biographical details (address, phone) are optional but recommended
- Attachments are optional except when specifically required for examination results

## Security Considerations

- All messages include WS-Security headers with certificates
- Production systems require valid certificates and proper authentication
- Timestamps must be within acceptable time windows
- Message signing and encryption may be required in production

## Version Information

- **Service Version**: Based on Australian Immigration eMedical Service V2.0
- **Schema Versions**: Health Service V2.0, Health Core V1.0, Enterprise Core V1.0
- **Sample Data Date**: November 2025 (updated from original 2019 data)
- **WCF Framework**: .NET Framework 4.8

## Support

For questions about these samples or the eMedical service implementation, refer to:
- Original WSDL: https://api-test.iom.int/eMedicalInterface/services/eMedicalPort12?wsdl
- XSD Schema files in the `Contracts` folder
- Java legacy implementation in the `javacode` folder