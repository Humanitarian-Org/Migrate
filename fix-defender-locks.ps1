# Fix for Microsoft Defender DLL locking issues
# This script cleans projects and adds exclusions to help with development

Write-Host "🔧 Fixing Microsoft Defender DLL Locking Issues..." -ForegroundColor Yellow
Write-Host ""

$workspaceRoot = "C:\Dev\AcmeCorp-org\Migrate"

# Function to clean a project
function Clean-Project($projectPath, $projectName) {
    Write-Host "Cleaning $projectName..." -ForegroundColor Cyan
    
    if (Test-Path $projectPath) {
        Set-Location $projectPath
        
        # Clean dotnet projects
        dotnet clean --verbosity quiet
        
        # Remove bin and obj folders to ensure clean state
        $binPath = Join-Path $projectPath "bin"
        $objPath = Join-Path $projectPath "obj"
        
        if (Test-Path $binPath) {
            Remove-Item $binPath -Recurse -Force -ErrorAction SilentlyContinue
            Write-Host "  ✓ Removed bin folder" -ForegroundColor Green
        }
        
        if (Test-Path $objPath) {
            Remove-Item $objPath -Recurse -Force -ErrorAction SilentlyContinue  
            Write-Host "  ✓ Removed obj folder" -ForegroundColor Green
        }
        
        Write-Host "  ✅ $projectName cleaned" -ForegroundColor Green
    } else {
        Write-Host "  ⚠️  Path not found: $projectPath" -ForegroundColor Yellow
    }
    Write-Host ""
}

# Clean all projects
Write-Host "🧹 Cleaning all projects..." -ForegroundColor Cyan
Write-Host ""

# Platform projects
Clean-Project "$workspaceRoot\Platform\src\Api" "Platform API"
Clean-Project "$workspaceRoot\Platform\src\Domain" "Platform Domain"
Clean-Project "$workspaceRoot\Platform\src\Infrastructure" "Platform Infrastructure"
Clean-Project "$workspaceRoot\Platform\src\Endpoint.In" "Platform Messaging"

# Beneficiary projects  
Clean-Project "$workspaceRoot\Beneficiary\src\Api" "Beneficiary API"
Clean-Project "$workspaceRoot\Beneficiary\src\Domain" "Beneficiary Domain"
Clean-Project "$workspaceRoot\Beneficiary\src\Infrastructure" "Beneficiary Infrastructure"
Clean-Project "$workspaceRoot\Beneficiary\src\Endpoint.In" "Beneficiary Messaging"

# Medical projects
Clean-Project "$workspaceRoot\Medical\src\Api" "Medical API"
Clean-Project "$workspaceRoot\Medical\src\Domain" "Medical Domain"
Clean-Project "$workspaceRoot\Medical\src\Infrastructure" "Medical Infrastructure"
Clean-Project "$workspaceRoot\Medical\src\Endpoint.In" "Medical Endpoint In"
Clean-Project "$workspaceRoot\Medical\src\Endpoint.Out" "Medical Endpoint Out"

Write-Host "🛡️ Microsoft Defender Recommendations:" -ForegroundColor Yellow
Write-Host ""
Write-Host "To prevent future DLL locking issues, consider adding these folders to" -ForegroundColor White
Write-Host "Microsoft Defender's exclusion list:" -ForegroundColor White
Write-Host ""
Write-Host "1. Open Windows Security" -ForegroundColor Cyan
Write-Host "2. Go to Virus & threat protection" -ForegroundColor Cyan
Write-Host "3. Click 'Manage settings' under Virus & threat protection settings" -ForegroundColor Cyan
Write-Host "4. Click 'Add or remove exclusions'" -ForegroundColor Cyan
Write-Host "5. Add these folders:" -ForegroundColor Cyan
Write-Host ""
Write-Host "   📁 $workspaceRoot\Platform\src" -ForegroundColor Green
Write-Host "   📁 $workspaceRoot\Beneficiary\src" -ForegroundColor Green
Write-Host "   📁 $workspaceRoot\Medical\src" -ForegroundColor Green
Write-Host "   📁 C:\Users\$env:USERNAME\.nuget" -ForegroundColor Green
Write-Host ""

Write-Host "🚀 Alternative: Try using the 'Start All Services (Sequential)' task" -ForegroundColor Yellow
Write-Host "   which starts services one at a time to avoid build conflicts." -ForegroundColor White
Write-Host ""

Write-Host "✅ Cleanup complete! Try running your services again." -ForegroundColor Green
Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")