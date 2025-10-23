# 🔐 Local Development Setup - IMPORTANT SECURITY INFORMATION

## ⚠️ Before You Start

**NEVER commit `local.settings.json` files to git!** They contain sensitive connection strings and are automatically excluded by `.gitignore`.

## Setting Up Your Local Environment

### 1. Copy Template Files

Copy the template files and replace placeholders with your actual connection strings:

```powershell
# Medical API
Copy-Item "Medical\src\Api\local.settings.json.template" "Medical\src\Api\local.settings.json"

# Platform API  
Copy-Item "Platform\src\Api\local.settings.json.template" "Platform\src\Api\local.settings.json"

# Beneficiary API
Copy-Item "Beneficiary\src\Api\local.settings.json.template" "Beneficiary\src\Api\local.settings.json"

# Add other endpoint local.settings.json files as needed
```

### 2. Replace Placeholders

In each `local.settings.json` file, replace these placeholders:

- `<<ASB_CONNECTION_STRING>>` - Your Azure Service Bus connection string
- `<<COSMOS_DB_CONNECTION_STRING>>` - Your CosmosDB connection string  
- `<<SIGNALR_CONNECTION_STRING>>` - Your SignalR connection string (Platform API only)

### 3. For SignalR Connection String

Copy the template file for SignalR:
```powershell
Copy-Item "Platform\src\Infrastructure\SignalR\signalr-connection-string.txt" "Platform\src\Infrastructure\SignalR\signalr-connection-string.local.txt"
```

Then edit `signalr-connection-string.local.txt` with your actual SignalR connection string.

## Example Values

### Local Development
- **Azure Storage**: Use `UseDevelopmentStorage=true` (Azurite emulator)
- **CosmosDB**: Use CosmosDB Emulator: `AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==`

### Production/Staging
- Get actual connection strings from Azure portal
- Store them securely (Azure Key Vault recommended)

## 🔒 Security Best Practices

1. **Never commit** actual connection strings
2. **Use placeholders** in any committed files
3. **Store secrets** in environment variables or Azure Key Vault
4. **Rotate keys** regularly
5. **Use least privilege** access for connection strings

## Files Excluded from Git

The following files are automatically ignored:
- `**/local.settings.json`
- `*connection-string*.txt`
- `**/appsettings.Development.json`
- `**/appsettings.Local.json`

## If You Accidentally Commit Secrets

1. **Stop immediately** - don't push to remote
2. **Rotate the exposed keys** in Azure portal
3. **Remove from git history** using `git filter-branch` or BFG Repo-Cleaner
4. **Update your local files** with new connection strings