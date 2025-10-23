# IOM Development Environment Setup Guide

## Required Services for Local Development

Your IOM Migration Platform requires several services to run locally:

### 1. **Azurite (Azure Storage Emulator)**
- **Purpose**: Emulates Azure Blob Storage, Queue Storage, and Table Storage
- **Required for**: All Azure Functions projects
- **Ports**: 10000 (Blob), 10001 (Queue), 10002 (Table)

### 2. **CosmosDB Emulator** (Optional)
- **Purpose**: Emulates Azure CosmosDB 
- **Required for**: Database operations
- **Port**: 8081

### 3. **Service Bus** (Cloud-based)
- **Purpose**: NServiceBus messaging
- **Connection**: Configured in local.settings.json

## Quick Start Options

### Option 1: VS Code Tasks (Recommended)
```
Ctrl+Shift+P → "Tasks: Run Task" → Select:
- "Start All Services (Sequential)" - Includes Azurite
- "Start All Services + CosmosDB" - Includes Azurite + CosmosDB
```

### Option 2: Manual Setup
```powershell
# 1. Start Azurite
azurite --silent --location c:\temp\azurite

# 2. Start CosmosDB Emulator (optional)
& "C:\Program Files\Azure Cosmos DB Emulator\CosmosDB.Emulator.exe" /NoExplorer /NoUI

# 3. Use VS Code tasks for your services
```

## Installation Commands (if needed)

### Install Azurite
```bash
npm install -g azurite
```

### Install CosmosDB Emulator
Download from: https://aka.ms/cosmosdb-emulator

## Service URLs

| Service | URL | Purpose |
|---------|-----|---------|
| Platform UI | http://localhost:3000 | React App |
| Platform API | http://localhost:7071 | Azure Functions |
| Platform Messaging | http://localhost:7072 | NServiceBus |
| Beneficiary API | http://localhost:7075 | Azure Functions |
| Beneficiary Messaging | http://localhost:7074 | NServiceBus |
| Azurite Blob | http://localhost:10000 | Storage Emulator |
| Azurite Queue | http://localhost:10001 | Queue Emulator |
| Azurite Table | http://localhost:10002 | Table Emulator |
| CosmosDB Emulator | https://localhost:8081 | Database Emulator |

## Troubleshooting

### "Cannot connect to storage account"
- Ensure Azurite is running: `azurite --version`
- Check ports 10000-10002 are not blocked

### "Cannot open DLL for writing"  
- Run: `.\fix-defender-locks.ps1`
- Use "Sequential" startup instead of "Parallel"

### CosmosDB connection issues
- Start CosmosDB Emulator
- Accept the SSL certificate when prompted
- Check https://localhost:8081/_explorer/

## Configuration Files

### Platform API local.settings.json
```json
{
  "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;"
}
```

### Beneficiary API local.settings.json  
```json
{
  "AzureWebJobsStorage": "UseDevelopmentStorage=true"
}
```

Both configurations point to Azurite running locally.