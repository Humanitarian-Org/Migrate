# Simple script to add all issues to project
# Project number: 1 (App Dev with GitHub Practice)
# Issues: #110-128

$owner = "AIS-Commercial-Business-Unit"
$repo = "github-enablement" 
$projectNumber = 1

Write-Host "Adding issues #110-128 to project #$projectNumber..." -ForegroundColor Cyan

$successCount = 0
$errorCount = 0

for ($issueNum = 110; $issueNum -le 128; $issueNum++) {
    try {
        $url = "https://github.com/$owner/$repo/issues/$issueNum"
        Write-Host "Adding issue #$issueNum..." -ForegroundColor Yellow
        
        $result = gh project item-add $projectNumber --owner $owner --url $url 2>&1
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "  ✓ Success" -ForegroundColor Green
            $successCount++
        } else {
            Write-Host "  ⚠ Warning: $result" -ForegroundColor Yellow
        }
    }
    catch {
        Write-Host "  ✗ Error: $($_.Exception.Message)" -ForegroundColor Red
        $errorCount++
    }
    
    Start-Sleep -Milliseconds 200  # Small delay to avoid rate limiting
}

Write-Host "`nSummary:" -ForegroundColor Cyan
Write-Host "Successfully added: $successCount issues" -ForegroundColor Green
if ($errorCount -gt 0) {
    Write-Host "Errors: $errorCount issues" -ForegroundColor Red
}

Write-Host "`nView project: https://github.com/orgs/$owner/projects/$projectNumber" -ForegroundColor Cyan