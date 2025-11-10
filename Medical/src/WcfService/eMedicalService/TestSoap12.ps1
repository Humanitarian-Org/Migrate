# PowerShell script to test SOAP 1.2 service endpoint
# This tests the corrected eMedical service with SOAP 1.2 support

$soap12Envelope = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope">
   <soap:Header>
      <wsa:Action xmlns:wsa="http://www.w3.org/2005/08/addressing">http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseRequest</wsa:Action>
   </soap:Header>
   <soap:Body>
      <ns6:RegisterHealthCaseRequest xmlns:ns6="http://www.immi.gov.au/Namespace/Health/Service/V2.0">
         <CorrelationID xmlns="http://www.immi.gov.au/Namespace/Health/Core/V1.0">TEST-POWERSHELL-12345</CorrelationID>
         <CachedCreationDate xmlns="http://www.immi.gov.au/Namespace/Health/Core/V1.0">
            <ns3:UnstructuredYear xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">2025</ns3:UnstructuredYear>
            <ns3:UnstructuredMonth xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">11</ns3:UnstructuredMonth>
            <ns3:UnstructuredDay xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">10</ns3:UnstructuredDay>
         </CachedCreationDate>
         <ns6:RegisterHealthCaseClientBiographicalDetails>
            <ns4:GivenName xmlns:ns4="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0">PowerShell</ns4:GivenName>
            <ns4:FamilyName xmlns:ns4="http://www.immi.gov.au/Namespace/Enterprise/Core/V1.0">Test</ns4:FamilyName>
            <ns3:SexType xmlns:ns3="http://www.immi.gov.au/Namespace/PersonIdentity/Core/V1.0">M</ns3:SexType>
         </ns6:RegisterHealthCaseClientBiographicalDetails>
      </ns6:RegisterHealthCaseRequest>
   </soap:Body>
</soap:Envelope>
"@

Write-Host "Testing SOAP 1.2 eMedical Service..." -ForegroundColor Green

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

Write-Host "`nPress any key to continue..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")