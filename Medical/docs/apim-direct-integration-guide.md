# Azure APIM: Direct SOAP to NServiceBus Transformation

This guide shows how to configure Azure APIM to transform incoming SOAP XML directly into NServiceBus JSON messages and send them to Azure Service Bus, **eliminating the need for the HTTP Function gateway**.

## Architecture

```
External System (SOAP XML)
    ↓ POST
Azure APIM
    ↓ Transform XML → NServiceBus JSON
    ↓ POST to Service Bus Topic
Azure Service Bus
    ↓
NServiceBus Handler
    ↓ message.SoapEnvelope (populated!)
Process SOAP Message
```

## Prerequisites

1. Azure API Management instance
2. Azure Service Bus namespace with topic created
3. NServiceBus configured with JSON serialization (SystemJsonSerializer)

## Step 1: Create APIM API

### 1.1 Create API in Azure Portal

1. Go to your APIM instance
2. **APIs** → **+ Add API** → **HTTP**
3. Configure:
   - **Display name**: Medical SOAP Intake
   - **Name**: medical-soap-intake
   - **Web service URL**: `https://migrate.servicebus.windows.net` (placeholder)
   - **API URL suffix**: `medical/soap`

### 1.2 Add Operation

1. **+ Add operation**
2. Configure:
   - **Display name**: Receive SOAP Message
   - **Name**: receive-soap
   - **URL**: POST `/`
   - **Request body**: 
     - Content type: `application/xml`
     - Sample: Paste your SOAP XML sample

## Step 2: Configure APIM Policy

### 2.1 Apply the Inbound Policy

Click on the operation → **Inbound processing** → **Code editor** (</>) and paste:

```xml
<inbound>
    <base />
    
    <!-- Read incoming SOAP XML -->
    <set-variable name="soapXml" value="@(context.Request.Body.As<string>(preserveContent: true))" />
    
    <!-- Transform to NServiceBus JSON message -->
    <set-body>@{
        using System.Text.Json;
        using System.Text.Json.Nodes;
        
        var soapXmlBody = (string)context.Variables["soapXml"];
        
        // Create NServiceBus JSON message
        var message = new JsonObject
        {
            ["$type"] = "Medical.Domain.Contracts.Events.eMedicalMsgRecieved, Medical.Domain",
            ["SoapEnvelope"] = soapXmlBody
        };
        
        return message.ToJsonString();
    }</set-body>
    
    <!-- Set Content-Type -->
    <set-header name="Content-Type" exists-action="override">
        <value>application/json; charset=utf-8</value>
    </set-header>
    
    <!-- NServiceBus Headers -->
    <set-header name="NServiceBus.EnclosedMessageTypes" exists-action="override">
        <value>Medical.Domain.Contracts.Events.eMedicalMsgRecieved</value>
    </set-header>
    
    <set-header name="NServiceBus.MessageId" exists-action="override">
        <value>@(Guid.NewGuid().ToString())</value>
    </set-header>
    
    <set-header name="NServiceBus.ContentType" exists-action="override">
        <value>application/json</value>
    </set-header>
    
    <!-- Route to Service Bus Topic -->
    <set-backend-service base-url="https://migrate.servicebus.windows.net" />
    <rewrite-uri template="/medical.domain.contracts.events.emedicalmsgrecieved/messages" />
    
    <!-- Authenticate with Service Bus using Managed Identity -->
    <authentication-managed-identity resource="https://servicebus.azure.net" />
</inbound>
```

### 2.2 Configure Outbound Response

```xml
<outbound>
    <base />
    <set-status code="202" reason="Accepted" />
    <set-header name="Content-Type" exists-action="override">
        <value>application/json</value>
    </set-header>
    <set-body>@{
        return "{\"status\":\"accepted\",\"message\":\"SOAP message queued for processing\"}";
    }</set-body>
</outbound>
```

## Step 3: Configure Service Bus Authentication

### Option 1: Managed Identity (Recommended)

1. **Enable Managed Identity on APIM**:
   - APIM → **Managed identities** → Enable **System assigned**

2. **Grant APIM Access to Service Bus**:
   ```bash
   # Get APIM Managed Identity Principal ID
   $apimPrincipalId = az apim show --name your-apim --resource-group your-rg --query identity.principalId -o tsv
   
   # Grant "Azure Service Bus Data Sender" role
   az role assignment create \
     --assignee $apimPrincipalId \
     --role "Azure Service Bus Data Sender" \
     --scope /subscriptions/{subscription-id}/resourceGroups/{rg}/providers/Microsoft.ServiceBus/namespaces/migrate
   ```

3. **Add authentication to policy** (already in policy above):
   ```xml
   <authentication-managed-identity resource="https://servicebus.azure.net" />
   ```

### Option 2: SAS Token (Alternative)

1. **Create SAS Policy** in Service Bus:
   - Service Bus → **Shared access policies** → **+ Add**
   - Name: `apim-sender`
   - Permissions: **Send**
   - Copy **Primary Connection String**

2. **Add Named Value in APIM**:
   - APIM → **Named values** → **+ Add**
   - Name: `ServiceBusSasToken`
   - Value: Extract the `SharedAccessSignature` part from connection string
   - Mark as **Secret**

3. **Update policy**:
   ```xml
   <set-header name="Authorization" exists-action="override">
       <value>@("{{ServiceBusSasToken}}")</value>
   </set-header>
   ```

## Step 4: Verify NServiceBus Configuration

Ensure your NServiceBus is configured for **JSON serialization** (not XML):

```csharp
// In NServiceBusConfigurationExtensions.cs
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
```

## Step 5: Test the Setup

### 5.1 Test from APIM Test Console

1. Go to your API operation in Azure Portal
2. Click **Test** tab
3. Paste SOAP XML in request body
4. Click **Send**
5. Should receive `202 Accepted`

### 5.2 Test with Postman/cURL

```bash
curl -X POST https://your-apim.azure-api.net/medical/soap \
  -H "Content-Type: application/xml" \
  -H "Ocp-Apim-Subscription-Key: your-subscription-key" \
  --data @Medical/src/Test/SampleMessages/00_sv445_1.xml
```

### 5.3 Verify Handler Receives Message

Check your NServiceBus handler logs:

```
[Information] === eMedicalMsgRecieved Handler Started ===
[Information] Message received - Type: Medical.Domain.Contracts.Events.eMedicalMsgRecieved
[Information] SoapEnvelope property populated - Length: 15234 characters
[Information] Successfully parsed SOAP XML - Root element: Envelope
[Information] CorrelationID extracted: 362291741250712573
```

## Troubleshooting

### Issue: Handler receives NULL SoapEnvelope

**Cause**: NServiceBus is using XML serialization instead of JSON

**Solution**: Change to JSON serialization in `NServiceBusConfigurationExtensions.cs`:
```csharp
endpointConfiguration.UseSerialization<SystemJsonSerializer>();
```

### Issue: 401 Unauthorized from Service Bus

**Cause**: Authentication not configured

**Solutions**:
- Verify Managed Identity is enabled on APIM
- Verify APIM has "Azure Service Bus Data Sender" role
- Or configure SAS token authentication

### Issue: 404 Topic Not Found

**Cause**: Topic name in policy doesn't match actual topic

**Solution**: Verify topic name in `rewrite-uri` matches Service Bus topic exactly

### Issue: Message arrives but wrong format

**Check Service Bus Message**:
1. Service Bus → Topics → Click your topic
2. **Service Bus Explorer** → **Peek messages**
3. Message body should be JSON:
```json
{
  "$type": "Medical.Domain.Contracts.Events.eMedicalMsgRecieved, Medical.Domain",
  "SoapEnvelope": "<soap:Envelope>...</soap:Envelope>"
}
```

## Benefits of APIM Approach

✅ **No Azure Function** - One less service to deploy/maintain
✅ **Lower latency** - Direct path to Service Bus
✅ **Lower cost** - No function execution costs
✅ **Built-in features** - Rate limiting, caching, monitoring in APIM
✅ **Centralized** - All API management in one place

## JSON Escaping Details

The key to this working is the `JsonObject` approach:

```csharp
var message = new JsonObject
{
    ["SoapEnvelope"] = soapXmlBody  // Automatically handles escaping
};
```

This correctly escapes:
- Quotes (`"` → `\"`)
- Newlines (`\n` → `\\n`)
- Backslashes (`\` → `\\`)
- Special XML characters

Result in Service Bus message:
```json
{
  "$type": "Medical.Domain.Contracts.Events.eMedicalMsgRecieved, Medical.Domain",
  "SoapEnvelope": "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\n  <soap:Body>...</soap:Body>\n</soap:Envelope>"
}
```

## Using Named Values (Best Practice)

Create named values in APIM for maintainability:

1. **ServiceBusEndpoint**: `https://migrate.servicebus.windows.net`
2. **MedicalTopicPath**: `/medical.domain.contracts.events.emedicalmsgrecieved/messages`

Update policy:
```xml
<set-backend-service base-url="{{ServiceBusEndpoint}}" />
<rewrite-uri template="{{MedicalTopicPath}}" />
```

## Next Steps

1. ✅ Test with sample SOAP message
2. ✅ Verify handler receives and processes message
3. ✅ Configure production authentication (Managed Identity)
4. ✅ Set up monitoring and alerts
5. ✅ Remove/disable the HTTP Function gateway (if no longer needed)

## Complete Policy Example

See the full policy files:
- `apim-soap-to-nservicebus-policy-v2.xml` - Recommended version
- `apim-soap-to-nservicebus-policy.xml` - Alternative implementation
