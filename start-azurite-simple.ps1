# Ultra Simple Azurite Starter
# This script starts Azurite with the absolute minimum complexity

Write-Host "🚀 Starting Azurite Storage Emulator..." -ForegroundColor Green

# Test azurite first
Write-Host "🔍 Testing azurite command..." -ForegroundColor Yellow
try {
    $version = azurite --version
    Write-Host "✅ Azurite version: $version" -ForegroundColor Green
} catch {
    Write-Host "❌ Azurite not working: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

# Create storage directory
$storageDir = "c:\temp\azurite"
Write-Host "📁 Creating storage directory: $storageDir" -ForegroundColor Cyan
New-Item -ItemType Directory -Path $storageDir -Force | Out-Null

# Start Azurite in the simplest way possible
Write-Host "🚀 Starting Azurite in new terminal..." -ForegroundColor Green

# Use cmd for maximum compatibility
$azuriteCommand = "azurite --silent --location `"c:\temp\azurite`""

# Try Windows Terminal first
if (Get-Command "wt" -ErrorAction SilentlyContinue) {
    Write-Host "Using Windows Terminal..." -ForegroundColor Cyan
    
    # Use cmd.exe to run azurite to avoid PowerShell complexity
    Start-Process -FilePath "wt" -ArgumentList @(
        "new-tab", "--title", "Azurite", 
        "cmd", "/k", "echo Starting Azurite Storage Emulator && echo Storage: c:\temp\azurite && echo. && $azuriteCommand"
    )
} else {
    Write-Host "Using regular command prompt..." -ForegroundColor Cyan
    
    # Fallback to cmd window
    Start-Process -FilePath "cmd" -ArgumentList @(
        "/k", "title Azurite Storage && echo Starting Azurite Storage Emulator && echo Storage: c:\temp\azurite && echo. && $azuriteCommand"
    )
}

Write-Host ""
Write-Host "✅ Azurite should now be starting..." -ForegroundColor Green
Write-Host ""
Write-Host "🌐 When running, Azurite will be available at:" -ForegroundColor Cyan
Write-Host "  • Blob Storage:  http://localhost:10000" -ForegroundColor White
Write-Host "  • Queue Storage: http://localhost:10001" -ForegroundColor White  
Write-Host "  • Table Storage: http://localhost:10002" -ForegroundColor White
Write-Host ""
Write-Host "💡 Check the new terminal window to see if Azurite started successfully" -ForegroundColor Yellow
