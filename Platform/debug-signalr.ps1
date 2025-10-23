#!/usr/bin/env pwsh
# SignalR Status Update Debug Script

Write-Host "=== SignalR Flow Debug Test ===" -ForegroundColor Cyan

# Step 1: Test SignalR negotiate endpoint
Write-Host "`n1. Testing SignalR negotiate endpoint..." -ForegroundColor Yellow
try {
    $negotiateResponse = Invoke-RestMethod -Uri "http://localhost:7071/api/negotiate" -Method POST -ContentType "application/json" -Body '{}'
    Write-Host "✅ SignalR negotiate working" -ForegroundColor Green
    Write-Host "   Hub URL: $($negotiateResponse.Url.Substring(0,50))..." -ForegroundColor Gray
} catch {
    Write-Host "❌ SignalR negotiate failed: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

# Step 2: Test bulk upload API
Write-Host "`n2. Testing bulk upload API..." -ForegroundColor Yellow
$correlationId = [System.Guid]::NewGuid().ToString()
$uploadPayload = @{
    uploadId = "test-upload-" + (Get-Date -Format "HHmmss")
    correlationId = $correlationId
    fileName = "debug-test.csv"
    userId = "debug-user"
    records = @(
        @{
            recordId = [System.Guid]::NewGuid().ToString()
            firstName = "Debug"
            lastName = "Test"
            dateOfBirth = "1990-01-01"
            nationality = "Syrian"
            documentType = "Passport"  
            documentNumber = "DEBUG123456"
            caseStatus = "PENDING"
            email = "debug@test.com"
        }
    )
} | ConvertTo-Json -Depth 10

try {
    Write-Host "   Correlation ID: $correlationId" -ForegroundColor Gray
    $uploadResponse = Invoke-RestMethod -Uri "http://localhost:7071/api/beneficiary/bulk-upload" -Method POST -ContentType "application/json" -Body $uploadPayload
    Write-Host "✅ Upload API working" -ForegroundColor Green
    Write-Host "   Response: $($uploadResponse | ConvertTo-Json -Compress)" -ForegroundColor Gray
} catch {
    Write-Host "❌ Upload API failed: $($_.Exception.Message)" -ForegroundColor Red
    if ($_.Exception.Response) {
        $errorStream = $_.Exception.Response.GetResponseStream()
        $reader = New-Object System.IO.StreamReader($errorStream)
        $errorBody = $reader.ReadToEnd()
        Write-Host "   Error details: $errorBody" -ForegroundColor Red
    }
}

# Step 3: Wait and check for timeout logs
Write-Host "`n3. Waiting 10 seconds for saga timeout to fire..." -ForegroundColor Yellow
Write-Host "   Check the Platform Endpoint terminal for timeout logs" -ForegroundColor Gray
Start-Sleep -Seconds 10

# Step 4: Test SignalR endpoints manually  
Write-Host "`n4. Testing SignalR functions..." -ForegroundColor Yellow

# Test progress endpoint
$progressPayload = @{
    correlationId = $correlationId
    uploadId = "test-upload-123"
    processedRecords = 1
    totalRecords = 1
    percentageComplete = 100.0
    currentStatus = "Manual test progress"
} | ConvertTo-Json

try {
    $progressResponse = Invoke-RestMethod -Uri "http://localhost:7071/api/SendUploadProgress" -Method POST -ContentType "application/json" -Body $progressPayload
    Write-Host "✅ SendUploadProgress working" -ForegroundColor Green
} catch {
    Write-Host "❌ SendUploadProgress failed: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`n=== Debug Test Complete ===" -ForegroundColor Cyan
Write-Host "Check browser console for SignalR messages!" -ForegroundColor Yellow