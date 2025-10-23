# Azure SignalR Service Provisioning Script for IOM Platform
# This script creates an Azure SignalR Service instance with appropriate configuration

param(
    [Parameter(Mandatory=$false)]
    [string]$SubscriptionId = "b95901bc-99a5-4969-baa7-21902b593dcd",
    
    [Parameter(Mandatory=$false)]
    [string]$ResourceGroupName = "rg-apim-apim.iom.demo-dev-eastus2-938",
    
    [Parameter(Mandatory=$false)]
    [string]$Location = "eastus",
    
    [Parameter(Mandatory=$false)]
    [string]$Environment = "dev",
    
    [Parameter(Mandatory=$false)]
    [ValidateSet("Free_F1", "Standard_S1", "Premium_P1")]
    [string]$Sku = "Free_F1"
)

# Set error action preference
$ErrorActionPreference = "Stop"

# Define resource names using Azure naming conventions
$signalRServiceName = "signalr-iom-platform-$Environment-eastus"
$keyVaultName = "kv-iom-platform-$Environment-eus"  # Key Vault names must be globally unique and ≤ 24 chars

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "Azure SignalR Service Provisioning Script" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "Configuration:" -ForegroundColor Yellow
Write-Host "  Subscription ID: $SubscriptionId" -ForegroundColor White
Write-Host "  Resource Group:  $ResourceGroupName" -ForegroundColor White
Write-Host "  Location:        $Location" -ForegroundColor White
Write-Host "  Environment:     $Environment" -ForegroundColor White
Write-Host "  SignalR Name:    $signalRServiceName" -ForegroundColor White
Write-Host "  SKU:             $Sku" -ForegroundColor White
Write-Host ""

# Check if Azure CLI is installed
try {
    $azVersion = az version --output json | ConvertFrom-Json
    Write-Host "✓ Azure CLI version $($azVersion.'azure-cli') detected" -ForegroundColor Green
} catch {
    Write-Host "✗ Azure CLI not found. Please install Azure CLI first." -ForegroundColor Red
    Write-Host "  Download from: https://aka.ms/installazurecliwindows" -ForegroundColor Yellow
    exit 1
}

# Login check
Write-Host "Checking Azure authentication..." -ForegroundColor Yellow
try {
    $currentAccount = az account show --output json | ConvertFrom-Json
    Write-Host "✓ Logged in as: $($currentAccount.user.name)" -ForegroundColor Green
} catch {
    Write-Host "✗ Not logged in to Azure. Running 'az login'..." -ForegroundColor Yellow
    az login
}

# Set subscription
Write-Host "Setting active subscription..." -ForegroundColor Yellow
az account set --subscription $SubscriptionId
Write-Host "✓ Active subscription set to: $SubscriptionId" -ForegroundColor Green

# Check if resource group exists
Write-Host "Checking resource group..." -ForegroundColor Yellow
$rgExists = az group exists --name $ResourceGroupName
if ($rgExists -eq "false") {
    Write-Host "✗ Resource group '$ResourceGroupName' does not exist!" -ForegroundColor Red
    Write-Host "Please create the resource group first or update the script with the correct name." -ForegroundColor Yellow
    exit 1
}
Write-Host "✓ Resource group '$ResourceGroupName' found" -ForegroundColor Green

# Check if SignalR service already exists
Write-Host "Checking if SignalR service already exists..." -ForegroundColor Yellow
$existingSignalR = az signalr show --name $signalRServiceName --resource-group $ResourceGroupName --output json 2>$null
if ($existingSignalR) {
    $signalRInfo = $existingSignalR | ConvertFrom-Json
    Write-Host "⚠ SignalR service '$signalRServiceName' already exists!" -ForegroundColor Yellow
    Write-Host "  Current SKU: $($signalRInfo.sku.name)" -ForegroundColor White
    Write-Host "  Current Status: $($signalRInfo.provisioningState)" -ForegroundColor White
    
    $continue = Read-Host "Do you want to continue and update configuration? (y/N)"
    if ($continue -ne "y" -and $continue -ne "Y") {
        Write-Host "Operation cancelled." -ForegroundColor Yellow
        exit 0
    }
} else {
    Write-Host "✓ SignalR service name '$signalRServiceName' is available" -ForegroundColor Green
}

# Create or update SignalR service
Write-Host ""
Write-Host "Creating/Updating Azure SignalR Service..." -ForegroundColor Yellow
Write-Host "This may take a few minutes..." -ForegroundColor Gray

try {
    $signalRResult = az signalr create `
        --name $signalRServiceName `
        --resource-group $ResourceGroupName `
        --location $Location `
        --sku $Sku `
        --unit-count 1 `
        --service-mode "Default" `
        --enable-message-logs false `
        --tags "Environment=$Environment" "Project=IOM-Platform" "Component=SignalR" `
        --output json

    $signalRInfo = $signalRResult | ConvertFrom-Json
    Write-Host "✓ SignalR service created successfully!" -ForegroundColor Green
    
} catch {
    Write-Host "✗ Failed to create SignalR service: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

# Get connection string
Write-Host ""
Write-Host "Retrieving connection string..." -ForegroundColor Yellow
try {
    $connectionString = az signalr key list `
        --name $signalRServiceName `
        --resource-group $ResourceGroupName `
        --query "primaryConnectionString" `
        --output tsv

    Write-Host "✓ Connection string retrieved" -ForegroundColor Green
} catch {
    Write-Host "✗ Failed to retrieve connection string" -ForegroundColor Red
    exit 1
}

# Display results
Write-Host ""
Write-Host "============================================" -ForegroundColor Green
Write-Host "SignalR Service Provisioning Complete!" -ForegroundColor Green
Write-Host "============================================" -ForegroundColor Green
Write-Host ""

Write-Host "Resource Details:" -ForegroundColor Yellow
Write-Host "  Service Name:    $signalRServiceName" -ForegroundColor White
Write-Host "  Resource Group:  $ResourceGroupName" -ForegroundColor White
Write-Host "  Location:        $($signalRInfo.location)" -ForegroundColor White
Write-Host "  SKU:             $($signalRInfo.sku.name)" -ForegroundColor White
Write-Host "  Endpoint:        $($signalRInfo.hostName)" -ForegroundColor White
Write-Host "  Status:          $($signalRInfo.provisioningState)" -ForegroundColor White
Write-Host ""

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "APPLICATION CONFIGURATION" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "1. Update your local.settings.json files:" -ForegroundColor Yellow
Write-Host ""
Write-Host "Platform/src/Api/local.settings.json:" -ForegroundColor Gray
Write-Host @"
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "AzureWebJobsServiceBus": "your-service-bus-connection-string",
    "CosmosDbConnectionString": "your-cosmos-connection-string",
    "AzureSignalRConnectionString": "$connectionString"
  }
}
"@ -ForegroundColor White

Write-Host ""
Write-Host "Platform/src/Endpoint.In/local.settings.json:" -ForegroundColor Gray
Write-Host @"
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "AzureWebJobsServiceBus": "your-service-bus-connection-string",
    "CosmosDbConnectionString": "your-cosmos-connection-string",
    "SignalRFunctionBaseUrl": "http://localhost:7071/api"
  }
}
"@ -ForegroundColor White

Write-Host ""
Write-Host "2. For Production/Azure deployment, set these App Settings:" -ForegroundColor Yellow
Write-Host "   AzureSignalRConnectionString = $connectionString" -ForegroundColor White
Write-Host ""

Write-Host "3. Azure Portal Links:" -ForegroundColor Yellow
Write-Host "   SignalR Service: https://portal.azure.com/#@iom.int/resource/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.SignalRService/SignalR/$signalRServiceName" -ForegroundColor Cyan
Write-Host ""

Write-Host "4. Connection String (for reference):" -ForegroundColor Yellow
Write-Host "   $connectionString" -ForegroundColor Green
Write-Host ""

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "NEXT STEPS" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

Write-Host "1. Update your local.settings.json files with the connection string above" -ForegroundColor White
Write-Host "2. Test your SignalR functions:" -ForegroundColor White
Write-Host "   cd Platform/src/Api" -ForegroundColor Gray
Write-Host "   func start --port 7071" -ForegroundColor Gray
Write-Host ""
Write-Host "3. Test the negotiate endpoint:" -ForegroundColor White
Write-Host "   POST http://localhost:7071/api/negotiate" -ForegroundColor Gray
Write-Host ""
Write-Host "4. Monitor SignalR service in Azure Portal" -ForegroundColor White
Write-Host "5. Configure CORS if needed for production" -ForegroundColor White
Write-Host ""

Write-Host "============================================" -ForegroundColor Green
Write-Host "Script completed successfully!" -ForegroundColor Green
Write-Host "============================================" -ForegroundColor Green

# Save connection string to file for easy reference
$connectionStringFile = "signalr-connection-string.txt"
$connectionString | Out-File -FilePath $connectionStringFile -Encoding UTF8
Write-Host ""
Write-Host "Connection string saved to: $connectionStringFile" -ForegroundColor Cyan