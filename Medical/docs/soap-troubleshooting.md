# SOAP Message Processing - Troubleshooting Guide

## Problem: `message.SoapEnvelope` is NULL in Handler

### Root Cause
You're sending raw SOAP XML directly to Azure Service Bus topic. NServiceBus cannot deserialize raw SOAP XML into the `eMedicalMsgRecieved` class because it expects messages in its own serialization format.

## Solution: Use HTTP Function as Gateway

### Architecture Flow
```
External System (APIM) 
    → POST /api/soap (HTTP Function)
    → Publishes eMedicalMsgRecieved to NServiceBus
    → Service Bus Topic
    → eMedicalMsgRecievedHandler receives message
```

### Implementation

#### 1. **Receive SOAP via HTTP Function** ✅ RECOMMENDED
Use `ReceiveSoapMessageFunction.cs` which:
- Accepts raw SOAP XML via HTTP POST
- Wraps it in `eMedicalMsgRecieved` NServiceBus event
- Publishes to Service Bus via NServiceBus (proper serialization)

**Test locally:**
```bash
# Using the sample file
curl -X POST http://localhost:7071/api/soap \
  -H "Content-Type: application/xml" \
  --data @Medical/src/Test/SampleMessages/00_sv445_1.xml
```

**PowerShell:**
```powershell
$soapXml = Get-Content -Path "Medical/src/Test/SampleMessages/00_sv445_1.xml" -Raw
Invoke-RestMethod -Uri "http://localhost:7071/api/soap" `
  -Method Post `
  -ContentType "application/xml" `
  -Body $soapXml
```

#### 2. **Configure APIM** (For Production)

Update your APIM policy to route to the HTTP Function instead of directly to Service Bus:

```xml
<policies>
  <inbound>
    <base />
    <!-- Route to Azure Function instead of Service Bus -->
    <set-backend-service base-url="https://your-function-app.azurewebsites.net/api" />
    <rewrite-uri template="/soap" />
    
    <!-- Ensure Content-Type is set -->
    <set-header name="Content-Type" exists-action="override">
      <value>application/xml</value>
    </set-header>
    
    <!-- Optional: Add correlation ID header -->
    <set-header name="X-Correlation-Id" exists-action="override">
      <value>@(Guid.NewGuid().ToString())</value>
    </set-header>
  </inbound>
  
  <backend>
    <base />
  </backend>
  
  <outbound>
    <base />
  </outbound>
  
  <on-error>
    <base />
  </on-error>
</policies>
```

## Why Direct Service Bus Posting Doesn't Work

### What Happens When You POST Raw SOAP to Service Bus Topic:

1. **Raw SOAP XML arrives at Service Bus**
   ```xml
   <soap:Envelope>...</soap:Envelope>
   ```

2. **NServiceBus tries to deserialize into `eMedicalMsgRecieved`**
   - Expects: `{ "SoapEnvelope": "<soap:Envelope>...</soap:Envelope>" }`
   - Receives: `<soap:Envelope>...</soap:Envelope>`
   - Result: ❌ `SoapEnvelope` property is NULL

### What Happens With HTTP Function Approach:

1. **HTTP Function receives raw SOAP XML**
   ```csharp
   string soapXmlString = await new StreamReader(req.Body).ReadToEndAsync();
   ```

2. **Creates proper NServiceBus message**
   ```csharp
   var medicalMsg = new eMedicalMsgRecieved
   {
       SoapEnvelope = soapXmlString  // ✅ Property populated
   };
   ```

3. **NServiceBus publishes with correct serialization**
   ```json
   {
     "$type": "Medical.Domain.Contracts.Events.eMedicalMsgRecieved",
     "SoapEnvelope": "<soap:Envelope>...</soap:Envelope>"
   }
   ```

4. **Handler receives properly deserialized message**
   ```csharp
   // ✅ message.SoapEnvelope contains the SOAP XML string
   ```

## Debugging Steps

### 1. Check Handler Logs

When message arrives at handler, you should see:
```
[Information] === eMedicalMsgRecieved Handler Started ===
[Information] Message received - Type: Medical.Domain.Contracts.Events.eMedicalMsgRecieved
[Information] === NServiceBus Message Headers ===
[Information]   NServiceBus.MessageId = xxx-xxx-xxx
[Information]   NServiceBus.ContentType = text/xml
[Information]   NServiceBus.EnclosedMessageTypes = Medical.Domain.Contracts.Events.eMedicalMsgRecieved
[Information] SoapEnvelope property populated - Length: 15234 characters
[Information] Successfully parsed SOAP XML - Root element: Envelope
[Information] CorrelationID extracted: 362291741250712573
```

### 2. If `SoapEnvelope` is NULL

Check the logs:
```
[Warning] SoapEnvelope is NULL or empty
[Warning] This means the message was not properly formatted when sent to Service Bus
[Warning] Expected: NServiceBus message wrapper containing SoapEnvelope property
```

**Solution:** Use the HTTP Function approach instead of posting directly to Service Bus.

### 3. Check HTTP Function Logs

When SOAP XML arrives at HTTP function:
```
[Information] === ReceiveSoapMessage Function Started ===
[Information] Content-Type: application/xml
[Information] Received SOAP XML: 15234 bytes
[Information] SOAP XML is valid
[Information] Publishing eMedicalMsgRecieved event to NServiceBus
[Information] Successfully published eMedicalMsgRecieved event
```

## NServiceBus Configuration

Verify XML serialization is configured in `NServiceBusConfigurationExtensions.cs`:

```csharp
var xmlSerialization = endpointConfiguration.UseSerialization<XmlSerializer>();
xmlSerialization.DontWrapRawXml(); // Preserves raw XML in properties
```

✅ This is already configured in your codebase.

## Testing Checklist

- [ ] HTTP Function (`ReceiveSoapMessageFunction`) is deployed
- [ ] Test locally with `soap-test.http` file
- [ ] Verify handler logs show `SoapEnvelope` populated
- [ ] Verify SOAP XML can be parsed to `XDocument`
- [ ] Verify CorrelationID is extracted correctly
- [ ] Update APIM policy to route to HTTP Function
- [ ] Test end-to-end from APIM

## Alternative: Custom NServiceBus Deserializer (Advanced)

If you absolutely must send raw SOAP directly to Service Bus, you would need to create a custom NServiceBus deserializer. **This is NOT recommended** as it's complex and the HTTP Function approach is simpler and more maintainable.

## Summary

**✅ DO:**
- Use `ReceiveSoapMessageFunction` as HTTP endpoint
- Have APIM/external systems POST SOAP XML to `/api/soap`
- Let NServiceBus handle proper message serialization

**❌ DON'T:**
- Send raw SOAP XML directly to Service Bus topic
- Try to manually construct NServiceBus message format
- Mix serialization formats (raw XML + NServiceBus XML)

## Testing Commands

```bash
# Local test with full SOAP file
curl -X POST http://localhost:7071/api/soap \
  -H "Content-Type: application/xml" \
  --data @Medical/src/Test/SampleMessages/00_sv445_1.xml

# Check logs for both functions
# 1. ReceiveSoapMessage function logs (API)
# 2. eMedicalMsgRecievedHandler logs (Endpoint.In)
```

Expected successful flow:
1. ✅ HTTP Function receives SOAP XML
2. ✅ HTTP Function publishes `eMedicalMsgRecieved` event
3. ✅ NServiceBus serializes message correctly
4. ✅ Service Bus receives NServiceBus-formatted message
5. ✅ Handler receives message with `SoapEnvelope` populated
6. ✅ Handler parses SOAP XML to `XDocument`
7. ✅ Handler extracts data from SOAP message
