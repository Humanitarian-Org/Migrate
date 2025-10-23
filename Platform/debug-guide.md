# Log Monitoring Guide

## What to Watch For:

### 1. Platform API (Port 7071) Terminal:
- Look for: "BulkBeneficiaryUpload function executed successfully"
- Look for: SignalR function calls like "Broadcasting upload started message"

### 2. Platform Endpoint (Port 7072) Terminal:  
- Look for: "[BulkBeneficiaryUploadSaga] Saga started"
- Look for: "[BulkBeneficiaryUploadSaga] Timeout triggered: Checking processing status"
- Look for: "[BulkBeneficiaryUploadSaga] Published progress update via SignalR"
- Look for: "[SignalRNotificationHandler] Sending upload progress notification"

### 3. Browser Developer Console (F12):
- Look for: "SignalR connection established"
- Look for: "Upload started:", "Upload progress:", "Upload completed:"
- Look for: "Joined upload group for correlation ID"

## Common Issues:

❌ **No saga timeout logs** = Saga not receiving messages or timeout not configured
❌ **Timeout logs but no progress events** = IntakeManager.GetBulkBeneficiaryProcessingStatus() failing
❌ **Progress events but no SignalR** = SignalRNotificationHandler not receiving events
❌ **SignalR logs but no UI updates** = UI not connected to correct group or event names wrong

## Quick Test Commands:

# Check if functions are running:
Get-Process func | Select-Object Id,ProcessName,StartTime

# Check ports:
netstat -an | findstr ":7071"
netstat -an | findstr ":7072"

# Test SignalR manually:
.\debug-signalr.ps1