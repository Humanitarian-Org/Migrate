# Complete SignalR Status Update Testing Guide

## Step 1: Monitor All Terminals
Start monitoring these terminals while testing:

### Terminal 1: Platform API (Port 7071)
Look for:
- "BulkBeneficiaryUpload function executed successfully"
- "Broadcasting upload started message"
- "Broadcasting upload progress message"

### Terminal 2: Platform Endpoint (Port 7072)  
Look for:
- "[BulkBeneficiaryUploadSaga] Saga started"
- "[BulkBeneficiaryProcessHandler] Starting to process bulk beneficiary upload"
- "[BulkBeneficiaryProcessHandler] Sent CreateBeneficiaryCommand for..."
- "[BulkBeneficiaryUploadSaga] Timeout triggered: Checking processing status"
- "[BulkBeneficiaryUploadSaga] Published progress update via SignalR"
- "[SignalRNotificationHandler] Sending upload progress notification"

### Terminal 3: Beneficiary Endpoint (Port 7074)
Look for:
- "[CreateBeneficiaryCommandHandler] Processing create beneficiary command"
- "[CreateBeneficiaryCommandHandler] Successfully registered beneficiary"

## Step 2: Test in Browser
1. Open browser to http://localhost:3000
2. Open Developer Tools (F12) → Console tab
3. Upload the CSV file
4. Look for these console messages:

✅ Expected Messages:
```
SignalR connection established
Upload started: {correlationId: "...", uploadId: "..."}  
Joined upload group for correlation ID: abc-123-def
Upload progress: {processedRecords: X, totalRecords: Y}
```

❌ Missing Messages Mean:
- No "SignalR connection established" = Connection failed
- No "Joined upload group" = Group joining failed  
- No "Upload progress" = Events not reaching UI

## Step 3: Manual SignalR Test
Run this in PowerShell to manually trigger progress:

```powershell
$correlationId = "test-correlation-123"
$progressPayload = @{
    correlationId = $correlationId
    uploadId = "manual-test"
    processedRecords = 5
    totalRecords = 10  
    percentageComplete = 50.0
    currentStatus = "Manual test - 50% complete"
} | ConvertTo-Json

# Manually send progress event
Invoke-RestMethod -Uri "http://localhost:7071/api/SendUploadProgress" -Method POST -ContentType "application/json" -Body $progressPayload
```

If this shows up in the UI, the SignalR infrastructure works but the saga isn't publishing events.

## Step 4: Check File Upload Process
1. Upload beneficiaries_1000_valid.csv through the UI
2. Watch all terminals simultaneously  
3. Look for the sequence:
   - Upload API call → Saga starts → Process handler runs → Commands sent → Timeouts fire → Progress events published

## Quick Fixes to Try:

### Fix 1: Check SignalR Group Joining
In browser console after upload, run:
```javascript
// Check if connection exists
console.log(window.signalRConnection?.connectionId);
```

### Fix 2: Reduce Timeout for Testing
Change saga timeout to 1 second for faster testing:
```csharp
// In BulkBeneficiaryUploadSaga.cs line ~48
await RequestTimeout<BeneficiaryProcessingStatusCheck>(context, TimeSpan.FromSeconds(1), new BeneficiaryProcessingStatusCheck
```

### Fix 3: Force Progress Event
Add this after the upload in BulkBeneficiaryParsedAndSent handler:
```csharp
_logger.LogInformation($"Force publishing initial progress event");
// This will immediately show progress in UI
```