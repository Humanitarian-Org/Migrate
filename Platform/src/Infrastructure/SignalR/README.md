# Azure SignalR Service Infrastructure Scripts

This folder contains PowerShell scripts to provision and manage Azure SignalR Service for the IOM Platform.

## Scripts

### `provision-signalr.ps1`
Creates an Azure SignalR Service instance with proper naming conventions and configuration.

### `cleanup-signalr.ps1`
Removes the Azure SignalR Service instance (use with caution).

## Prerequisites

1. **Azure CLI** - Install from https://aka.ms/installazurecliwindows
2. **PowerShell 5.1+** or **PowerShell 7+**
3. **Azure subscription access** with Contributor role on the resource group

## Usage

### Basic Provisioning
```powershell
# Run with default parameters
.\provision-signalr.ps1
```

### Custom Parameters
```powershell
# Specify custom environment
.\provision-signalr.ps1 -Environment "staging" -Sku "Standard_S1"

# Different subscription or resource group
.\provision-signalr.ps1 -SubscriptionId "your-sub-id" -ResourceGroupName "your-rg-name"
```

### Available Parameters

| Parameter | Default | Description |
|-----------|---------|-------------|
| `SubscriptionId` | `b95901bc-99a5-4969-baa7-21902b593dcd` | Azure subscription ID |
| `ResourceGroupName` | `rg-apim-apim.iom.demo-dev-eastus2-938` | Target resource group |
| `Location` | `eastus2` | Azure region |
| `Environment` | `dev` | Environment name (dev/staging/prod) |
| `Sku` | `Free_F1` | SignalR SKU (Free_F1/Standard_S1/Premium_P1) |

## Resource Naming Convention

The script follows Azure naming best practices:

- **SignalR Service**: `signalr-iom-platform-{environment}-eastus2`
- **Tags**: Environment, Project, Component for cost tracking

## SKU Options

| SKU | Concurrent Connections | Messages/Day | Price |
|-----|----------------------|--------------|-------|
| `Free_F1` | 20 | 20,000 | Free |
| `Standard_S1` | 1,000 | 1,000,000 | ~$50/month |
| `Premium_P1` | 1,000 | 1,000,000 | ~$500/month |

## Output

The script provides:

1. **Connection String** - For application configuration
2. **Azure Portal Links** - For resource management
3. **Configuration Templates** - Ready to copy into local.settings.json
4. **Connection String File** - Saved locally for reference

## Security Considerations

1. **Connection strings contain sensitive keys** - Never commit to source control
2. **Use Azure Key Vault** for production deployments
3. **Rotate keys periodically** using Azure Portal or CLI
4. **Configure CORS** appropriately for web clients

## Troubleshooting

### Common Issues

1. **"Resource group not found"**
   - Verify the resource group name and subscription
   - Ensure you have access to the subscription

2. **"SignalR name already exists"**
   - SignalR names must be globally unique
   - The script will prompt to update existing resources

3. **"Insufficient permissions"**
   - Ensure you have Contributor role on the resource group
   - Contact your Azure administrator

### Logging

The script provides colored output:
- 🟢 **Green**: Success messages
- 🟡 **Yellow**: Warnings and prompts
- 🔴 **Red**: Errors
- 🔵 **Cyan**: Information headers

## Integration with Application

After running the script, update these files:

### 1. Platform API (`Platform/src/Api/local.settings.json`)
```json
{
  "Values": {
    "AzureSignalRConnectionString": "[COPY FROM SCRIPT OUTPUT]"
  }
}
```

### 2. Endpoint.In (`Platform/src/Endpoint.In/local.settings.json`)
```json
{
  "Values": {
    "SignalRFunctionBaseUrl": "http://localhost:7071/api"
  }
}
```

### 3. Production App Settings
Set `AzureSignalRConnectionString` in your Azure Function App settings.

## Cost Management

- **Development**: Use `Free_F1` SKU
- **Testing/Staging**: Use `Standard_S1` SKU  
- **Production**: Use `Standard_S1` or `Premium_P1` based on scale
- **Monitor usage** in Azure Portal to optimize costs

## Cleanup

To remove resources (⚠️ **DESTRUCTIVE OPERATION**):

```powershell
# Interactive cleanup (prompts for confirmation)
.\cleanup-signalr.ps1

# Force cleanup (no prompts)
.\cleanup-signalr.ps1 -Force
```

## Support

For issues with the infrastructure scripts:
1. Check the troubleshooting section above
2. Verify Azure CLI and PowerShell versions
3. Review Azure portal for resource status
4. Check Azure Activity Log for detailed error messages