# PowerShell script to test SOAP 1.2 service endpoint
# This tests the corrected eMedical service with SOAP 1.2 support

$soap12Envelope = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope">
   <soap:Header>
      <wsa:Action xmlns:wsa="http://www.w3.org/2005/08/addressing">http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterMedicalExaminationsResultsRequest</wsa:Action>
   </soap:Header>
   <soap:Body>
      <RegisterMedicalExaminationsResultsRequest xmlns="http://www.immi.gov.au/Namespace/Health/Service/V1.0">
         <ns1:CorrelationID xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">TEST-POWERSHELL-12345</ns1:CorrelationID>
         <ns0:HealthCaseIdentifierMsg xmlns:ns0="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0">
            <ns1:HealthCaseIdentifier xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">
               <ns1:HealthCaseIdentifierValue>40033127</ns1:HealthCaseIdentifierValue>
               <ns1:HealthCaseIdentifierType>IME</ns1:HealthCaseIdentifierType>
            </ns1:HealthCaseIdentifier>
         </ns0:HealthCaseIdentifierMsg>
         <ns0:HealthCaseIdentifierMsg xmlns:ns0="http://www.immi.gov.au/Namespace/Health/Messaging/Service/V1.0">
            <ns1:HealthCaseIdentifier xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">
               <ns1:HealthCaseIdentifierValue>U000010002</ns1:HealthCaseIdentifierValue>
               <ns1:HealthCaseIdentifierType>UMI</ns1:HealthCaseIdentifierType>
            </ns1:HealthCaseIdentifier>
         </ns0:HealthCaseIdentifierMsg>
         <RegisterMedicalExaminationsResultsRequestIdentityDocument>
            <ns6:DocumentTypeCode xmlns:ns6="http://www.immi.gov.au/Namespace/Document/Core/V1.0">01</ns6:DocumentTypeCode>
            <ns6:DocumentNumber xmlns:ns6="http://www.immi.gov.au/Namespace/Document/Core/V1.0">12345</ns6:DocumentNumber>
            <ns6:IssuingCountryName xmlns:ns6="http://www.immi.gov.au/Namespace/Document/Core/V1.0">AFG</ns6:IssuingCountryName>
            <ns1:CachedIssueDate xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">
               <ns3:UnstructuredYear xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">2019</ns3:UnstructuredYear>
               <ns3:UnstructuredMonth xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">1</ns3:UnstructuredMonth>
               <ns3:UnstructuredDay xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">1</ns3:UnstructuredDay>
            </ns1:CachedIssueDate>
            <ns1:CachedExpiryDate xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">
               <ns3:UnstructuredYear xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">2025</ns3:UnstructuredYear>
               <ns3:UnstructuredMonth xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">11</ns3:UnstructuredMonth>
               <ns3:UnstructuredDay xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">1</ns3:UnstructuredDay>
            </ns1:CachedExpiryDate>
            <ns1:IdentityDocumentedPresentedFlag xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">true</ns1:IdentityDocumentedPresentedFlag>
            <ns1:IdentityConcernsFlag xmlns:ns1="http://www.immi.gov.au/Namespace/Health/Core/V1.0">false</ns1:IdentityConcernsFlag>
         </RegisterMedicalExaminationsResultsRequestIdentityDocument>
      </RegisterMedicalExaminationsResultsRequest>
   </soap:Body>
</soap:Envelope>
"@

Write-Host "Testing SOAP 1.2 eMedical Service - RegisterMedicalExaminationsResultsRequest..." -ForegroundColor Green

try {
    # Create web request
    $uri = "http://localhost:55766/eMedicalIntegrationServiceCorrect.svc"
    $request = [System.Net.WebRequest]::Create($uri)
    $request.Method = "POST"
    $request.ContentType = "application/soap+xml; charset=utf-8"
    
    # Add request body
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($soap12Envelope)
    $request.ContentLength = $bytes.Length
    $requestStream = $request.GetRequestStream()
    $requestStream.Write($bytes, 0, $bytes.Length)
    $requestStream.Close()
    
    Write-Host "Sending SOAP 1.2 request to: $uri" -ForegroundColor Yellow
    Write-Host "Content-Type: application/soap+xml" -ForegroundColor Yellow
    Write-Host "Operation: RegisterMedicalExaminationsResultsRequest" -ForegroundColor Yellow
    
    # Get response
    $response = $request.GetResponse()
    $responseStream = $response.GetResponseStream()
    $reader = New-Object System.IO.StreamReader($responseStream)
    $responseContent = $reader.ReadToEnd()
    
    Write-Host "Response Status: $($response.StatusCode)" -ForegroundColor Green
    Write-Host "Response Content:" -ForegroundColor Cyan
    Write-Host $responseContent -ForegroundColor White
    
    $reader.Close()
    $responseStream.Close()
    $response.Close()
    
} catch {
    Write-Host "Error occurred:" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    
    if ($_.Exception.Response) {
        $errorStream = $_.Exception.Response.GetResponseStream()
        $errorReader = New-Object System.IO.StreamReader($errorStream)
        $errorContent = $errorReader.ReadToEnd()
        Write-Host "Error Response:" -ForegroundColor Red
        Write-Host $errorContent -ForegroundColor Yellow
        $errorReader.Close()
        $errorStream.Close()
    }
}

# Also check the debug log
Write-Host "`nChecking debug log..." -ForegroundColor Gray
if (Test-Path "C:\temp\wcf_debug.log") {
    Write-Host "Debug Log Contents (last 20 lines):" -ForegroundColor Cyan
    Get-Content "C:\temp\wcf_debug.log" | Select-Object -Last 20 | ForEach-Object {
        Write-Host $_ -ForegroundColor White
    }
} else {
    Write-Host "Debug log not found at C:\temp\wcf_debug.log" -ForegroundColor Yellow
}

Write-Host "`nPress any key to continue..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")