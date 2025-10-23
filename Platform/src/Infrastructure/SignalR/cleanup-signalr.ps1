# Azure SignalR Service Cleanup Script for IOM Platform
# This script removes the Azure SignalR Service instance

param(
    [Parameter(Mandatory=$false)]
    [string]$SubscriptionId = "b95901bc-99a5-4969-baa7-21902b593dcd",
    
    [Parameter(Mandatory=$false)]
    [string]$ResourceGroupName = "rg-apim-apim.iom.demo-dev-eastus2-938",
    
    [Parameter(Mandatory=$false)]
    [string]$Environment = "dev",
    
    [Parameter(Mandatory=$false)]
    [switch]$Force
)

# Set error action preference
$ErrorActionPreference = "Stop"

# Define resource names
$signalRServiceName = "signalr-iom-platform-$Environment-eastus2"

Write-Host "============================================" -ForegroundColor Red
Write-Host "Azure SignalR Service Cleanup Script" -ForegroundColor Red
Write-Host "============================================" -ForegroundColor Red
Write-Host ""

Write-Host "⚠ WARNING: This will DELETE the following resources:" -ForegroundColor Yellow
Write-Host "  SignalR Service: $signalRServiceName" -ForegroundColor White
Write-Host "  Resource Group:  $ResourceGroupName" -ForegroundColor White
Write-Host ""

if (-not $Force) {
    $confirm = Read-Host "Are you sure you want to continue? Type 'DELETE' to confirm"
    if ($confirm -ne "DELETE") {
        Write-Host "Operation cancelled." -ForegroundColor Yellow
        exit 0
    }
}

# Set subscription
az account set --subscription $SubscriptionId

# Delete SignalR service
Write-Host "Deleting SignalR service..." -ForegroundColor Yellow
try {
    az signalr delete --name $signalRServiceName --resource-group $ResourceGroupName --yes
    Write-Host "✓ SignalR service deleted successfully!" -ForegroundColor Green
} catch {
    Write-Host "✗ Failed to delete SignalR service: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""
Write-Host "Cleanup completed!" -ForegroundColor Green