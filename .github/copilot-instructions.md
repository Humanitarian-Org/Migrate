# IOM Migration Platform - Copilot Instructions

## Repository Overview

This is a multi-project migration platform for IOM (International Organization for Migration) containing several business domains with both backend services and frontend applications:

- **Medical**: Medical message integration system (Azure Functions + NServiceBus)
- **Beneficiary**: Beneficiary management system (Azure Functions + NServiceBus + React UI)
- **Platform**: Shared platform components (Azure Functions + NServiceBus + React UI)

### Common Architecture Pattern
All three domains follow a consistent architecture:
- **API**: Azure Functions HTTP trigger endpoints
- **Endpoint.In**: NServiceBus endpoint for processing incoming messages
- **Endpoint.Out**: NServiceBus endpoint for outbound message processing  
- **Domain**: Core business logic and contracts
- **Infrastructure**: Data access, external integrations, and cross-cutting concerns
- **Test**: Unit and integration tests
- **UI** (Platform & Beneficiary): React/TypeScript frontend applications

## Technology Stack

### Backend (.NET)
- **.NET 8** - Core framework
- **Azure Functions (Isolated Worker)** - Serverless compute
- **NServiceBus** - Messaging and sagas
- **Azure CosmosDB** - NoSQL database
- **xUnit** - Testing framework

### Frontend (React)
- **React 18** - UI framework
- **TypeScript** - Type safety
- **Material-UI (MUI)** - Component library with IOM branding
- **Module Federation** - Micro-frontend architecture
- **React Router** - Client-side routing
- **React Hook Form** - Form validation
- **Papa Parse & XLSX** - File parsing (CSV/Excel)

### Infrastructure
- **Azurite** - Azure Storage emulator for local development
- **Azure Service Bus** - Message broker
- **Azure SignalR** - Real-time communication
- **Docker** - Containerization

## Medical Integration System

### Project Overview
A distributed .NET 8 medical message integration system using Azure Functions, NServiceBus, and CosmosDB. The system processes medical messages from external sources and stores them for further processing.

### Message Processing Flow
1. HTTP request received by API Functions
2. Message deserialized using POCOs in Domain/Contracts/Events/POCOs
3. Processed by IntakeManager service
4. Saved to CosmosDB via MedicalRepository
5. Published to NServiceBus for further processing

### XML Message Processing
- POCOs separated into individual files by message type in `POCOs` folder
- Strip SOAP/service contract code - keep only data transfer objects
- Use XML serialization attributes for proper deserialization
- Handle nullable types and optional elements appropriately

## Beneficiary Management System

### Project Overview
A comprehensive beneficiary management system with bulk import capabilities, validation workflows, and real-time UI updates.

### Key Features
- **Bulk Import**: CSV/Excel file upload with validation and preview
- **Business-Driven Validation**: Validation rules defined in markdown, auto-synced to code
- **Real-time Updates**: SignalR integration for live progress notifications
- **Validation Workflow**: Automated GitHub workflow for rule changes

### Bulk Import Process
1. User uploads CSV/Excel file via React UI
2. Frontend validates data format and required fields
3. API receives validated data
4. NServiceBus saga coordinates processing
5. SignalR handler sends real-time progress updates to UI
6. Results displayed with success/error counts

### Validation Rules Management
- Business rules defined in `Beneficiary/docs/beneficiary-validation-rules.md`
- GitHub workflow detects changes and creates issues
- Copilot agent automatically generates code updates across all layers
- Developer reviews and approves changes via PR

## Platform System

### Project Overview
Shared platform components providing common functionality, UI shell, and infrastructure services for all domains.

### UI Architecture (Micro-Frontend)
- **Shell Application**: Main routing, navigation, and shared components
- **Module Federation**: Allows Medical/Beneficiary modules to contribute UI independently
- **IOM Branding**: Consistent color scheme (Blue: #0072CE, Orange: #FF6B35)
- **Shared Components**: Layout, navigation, common utilities

### SignalR Event Architecture
- **Dedicated SignalR Handler**: Separate from business logic
- **Event-Driven**: Multiple handlers process same events independently
- **Failure Isolation**: SignalR failures don't affect business processing
- **Real-time Notifications**: Live updates to UI for long-running operations

## Development Environment

### Required Services
Before running the application locally, ensure these services are running:

1. **Azurite** (Azure Storage Emulator) - Required for all Azure Functions
   - Ports: 10000 (Blob), 10001 (Queue), 10002 (Table)
   - Start: `azurite --silent --location c:\temp\azurite`

2. **CosmosDB Emulator** - Optional for database operations
   - Port: 8081
   - Download: https://aka.ms/cosmosdb-emulator

3. **Azure Service Bus** - Cloud-based messaging (configured in local.settings.json)

### VS Code Workspace Setup
The repository includes a multi-folder workspace (`IOM-Migrate.code-workspace`) with three folders:
- Medical
- Beneficiary  
- Platform

**Recommended Extensions:**
- ms-dotnettools.csharp
- ms-dotnettools.csdevkit

### Starting Services

#### Option 1: VS Code Tasks (Recommended)
```
Ctrl+Shift+P → "Tasks: Run Task" → Select:
- "Start All Services (Sequential)" - Includes Azurite
- "Start All Services + CosmosDB" - Includes Azurite + CosmosDB
```

#### Option 2: VS Code Launch Compounds
- **Launch All Medical Projects**: All Medical services
- **Launch All Platform & Beneficiary Services**: Platform + Beneficiary
- **Launch Everything (All Systems)**: All services across all domains

#### Option 3: Individual Commands
```bash
# Platform UI
cd Platform/src/UI && npm start

# Platform API (conflicts with Medical API port 7071 - run separately)
cd Platform/src/Api && func start --port 7071 --cors "http://localhost:3000"

# Platform Messaging
cd Platform/src/Endpoint.In && func start --port 7072

# Beneficiary API
cd Beneficiary/src/Api && func start --port 7075 --cors "http://localhost:3000"

# Beneficiary Messaging
cd Beneficiary/src/Endpoint.In && func start --port 7074

# Medical API
cd Medical/src/Api && func start --port 7071

# Medical Endpoints
cd Medical/src/Endpoint.In && func start --port 7072
cd Medical/src/Endpoint.Out && func start --port 7073
```

### Service URLs

| Service | URL | Purpose |
|---------|-----|---------|
| Platform UI | http://localhost:3000 | React App |
| Platform API | http://localhost:7071 | Azure Functions (shared port with Medical) |
| Platform Messaging | http://localhost:7072 | NServiceBus (shared port with Medical) |
| Beneficiary API | http://localhost:7075 | Azure Functions |
| Beneficiary Messaging | http://localhost:7074 | NServiceBus |
| Medical API | http://localhost:7071 | Azure Functions (shared port with Platform) |
| Medical Endpoint.In | http://localhost:7072 | NServiceBus (shared port with Platform) |
| Medical Endpoint.Out | http://localhost:7073 | NServiceBus |
| Azurite Blob | http://localhost:10000 | Storage Emulator |
| Azurite Queue | http://localhost:10001 | Queue Emulator |
| Azurite Table | http://localhost:10002 | Table Emulator |
| CosmosDB Emulator | https://localhost:8081 | Database Emulator |

**Note:** Platform and Medical share default ports 7071/7072. When using VS Code launch compounds to run all systems together, Medical services are automatically assigned different ports (see .vscode/launch.json). Alternatively, run Platform or Medical separately to avoid conflicts.

### Environment Variables
Required environment variables are defined in `local.settings.json` files:
- `AzureWebJobsStorage`: For Azure Functions (use Azurite for local dev)
- `CosmosDb__ConnectionString`: CosmosDB connection
- `ServiceBus__ConnectionString`: Azure Service Bus connection
- `SignalRConnectionString`: SignalR connection (Platform API only)

**⚠️ SECURITY: Never commit `local.settings.json` files!**
- Use `local.settings.json.template` files as templates
- Replace placeholders like `<<ASB_CONNECTION_STRING>>` with actual values
- Files are automatically excluded by `.gitignore`

## Code Structure Guidelines

### Backend (.NET) Structure

#### Domain Layer
- **Events**: Contains message contracts and POCOs for XML deserialization
- **Services**: Business logic interfaces
- **Models**: Core domain models
- **Contracts**: Message contracts for NServiceBus

#### Infrastructure Layer
- **Repositories**: CosmosDB data models and repository implementations
- **MessageHandlers**: NServiceBus message handlers
- **Sagas**: Long-running business processes and workflows
- **Services**: External service integrations (SignalR, etc.)

#### API Layer (Azure Functions)
- HTTP trigger endpoints
- Request/response models
- Function-specific configuration

#### Endpoint Layers (NServiceBus)
- **Endpoint.In**: Handles incoming messages and sagas
- **Endpoint.Out**: Handles outbound message processing

### Frontend (React/TypeScript) Structure

```
src/
├── components/
│   ├── layout/          # Header, Sidebar, Footer
│   └── common/          # Reusable UI components
├── pages/               # Page components (Dashboard, BulkImport, etc.)
├── theme/               # MUI theme configuration (IOM branding)
├── types/               # TypeScript type definitions
├── utils/               # Utility functions (validation, parsing)
└── App.tsx              # Main application with routing
```

### UI Development Guidelines
- Use TypeScript for all new code
- Follow React Hooks patterns (no class components)
- Use React Hook Form for form management
- Apply MUI components consistently with IOM theme
- Keep components focused and single-responsibility
- Extract reusable logic into custom hooks
- Use proper TypeScript types (avoid `any`)

### IOM Branding Standards
- Primary Blue: #0072CE
- Secondary Orange: #FF6B35
- Use MUI theme configuration in `theme/` directory
- Maintain consistent spacing and typography

## Data Models

### CosmosDB Documents
All documents inherit from domain-specific base classes which provide:
- `id`: Unique identifier (required by CosmosDB, use GUID)
- `PartitionKey`: For partitioning strategy
- `MessageType`: Discriminator for message types (in Medical system)
- Timestamp fields: `ReceivedAt`, `CreatedAt`, etc.

### Medical Message Types
- `RegisterHealthCaseRequest`: Health case registration
- `NotifyMedicalExaminationStatusRequest`: Examination status updates
- `RegisterMedicalExaminationsResultsRequest`: Examination results
- `DeleteCachedHealthCaseRequest`: Cache deletion requests

### Beneficiary Models
**Required Fields:**
- firstName, lastName, dateOfBirth (YYYY-MM-DD format)
- nationality, documentType, documentNumber
- caseStatus (PENDING, ACTIVE, COMPLETED, SUSPENDED)

**Optional Fields:**
- email, phone, address, city, country
- emergencyContact, emergencyPhone
- medicalConditions, specialNeeds, caseWorker, notes

## Development Patterns

### Backend Patterns

#### Dependency Injection
- Services registered in `Program.cs` of each project
- Use interfaces for testability
- Repository pattern for data access
- Constructor injection preferred

#### Error Handling
- Use structured logging with Microsoft.Extensions.Logging
- Implement proper exception handling in message handlers
- Return appropriate HTTP status codes from API endpoints
- Handle SignalR failures gracefully without affecting business logic

#### NServiceBus Patterns
- **Sagas**: For long-running processes (e.g., BulkBeneficiaryUploadSaga)
- **Handlers**: For event processing (separate SignalR handlers from business logic)
- **Events**: Use for pub/sub communication between services
- **Commands**: Use for direct service-to-service communication

#### Testing
- Unit tests for business logic
- Integration tests for repository operations
- Use test containers for CosmosDB testing when possible
- Mock external dependencies (SignalR, Service Bus)

### Frontend Patterns

#### State Management
- Use React Hooks (useState, useEffect, useContext)
- Keep state close to where it's used
- Lift state up only when necessary
- Consider Context API for shared state

#### Form Handling
- Use React Hook Form for validation
- Define validation schemas
- Provide clear error messages with field-level feedback
- Show inline validation as user types

#### File Processing
- Use React Dropzone for file uploads
- Parse CSV with Papa Parse, Excel with XLSX
- Validate data before submission
- Show progress for large file operations
- Provide downloadable templates

#### API Communication
- Use async/await for API calls
- Handle loading states
- Show user-friendly error messages
- Implement proper error boundaries

### Security Best Practices
- **Never commit secrets**: Use placeholders in templates
- **Validate input**: Both client-side and server-side
- **Sanitize data**: Prevent XSS and injection attacks
- **Use HTTPS**: For all external communications
- **Rotate keys**: Regularly update connection strings
- **Least privilege**: Grant minimal necessary permissions

## NServiceBus Configuration

### Message Headers
Required headers for proper routing:
- `EnclosedMessageTypes`: Full type name for message routing
- `MessageId`: Unique message identifier
- `CorrelationId`: For message correlation
- `ContentType`: Content type (e.g., "application/json")

### Endpoints
- Configure unique queue names for each endpoint
- Use appropriate serialization settings
- Handle poison messages appropriately
- **Endpoint.In**: Process incoming messages and host sagas
- **Endpoint.Out**: Process outbound messages

### Event Processing Architecture
```
API publishes event
        ↓
NServiceBus Event Bus
        ↓
    ┌───┴────┐
    ↓        ↓
Business   SignalR
Logic      Handler
(Saga)     (Independent)
```

### Best Practices
- Separate SignalR handlers from business logic
- Multiple handlers can process same event independently
- Handlers should be idempotent
- Use sagas for stateful workflows
- Publish events at key milestones

## GitHub Workflows

### Validation Rules Sync Workflow
Automates code generation when validation rules change:

1. **Trigger**: Changes to `Beneficiary/docs/beneficiary-validation-rules.md`
2. **Detection**: Workflow detects changes using git diff
3. **Issue Creation**: Creates GitHub issue with change details
4. **Copilot Agent**: Analyzes changes and generates code updates
5. **PR Creation**: Creates pull request for review
6. **Developer Review**: Review and approve changes

**Files:**
- `.github/workflows/validation-rules-sync.yml`
- `.github/README.md` - Workflow documentation

## Building and Testing

### Backend (.NET)

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build Medical/src/Api/Api.csproj

# Run all tests
dotnet test

# Run tests for specific project
dotnet test Medical/src/Test/Test.csproj

# Clean build artifacts
dotnet clean
```

### Frontend (React/TypeScript)

```bash
# Install dependencies
cd Platform/src/UI && npm install

# Start development server
npm start

# Build for production
npm run build

# Run tests
npm test

# Run linter
npm run lint

# Type checking
npm run type-check
```

### Common Build Issues

**DLL Locked by Windows Defender:**
- Run `.\fix-defender-locks.ps1`
- Use Sequential task startup instead of Parallel

**Node.js/npm not found:**
- Install Node.js 18+ from https://nodejs.org/
- Restart terminal after installation

**Port conflicts:**
- Check for other services running on same ports
- Adjust port numbers in launch.json/tasks.json

## Common Issues and Solutions

### CosmosDB
- Ensure `id` property is set (GUID recommended)
- Verify partition key configuration
- Handle upsert operations properly
- Accept SSL certificate for local emulator
- Check emulator status at https://localhost:8081/_explorer/

### Azure Functions
- **Always use `func start`** instead of `dotnet run` for full environment
- Ensure `local.settings.json` is not committed to source control
- Check port conflicts when running multiple functions
- Verify Azurite is running before starting functions
- Use `--cors` flag when calling from UI

### NServiceBus
- Verify message type names in headers match exactly
- Check queue configurations and permissions
- Monitor for message processing failures
- Ensure Service Bus connection string is valid

### React/TypeScript
- Clear npm cache if dependencies fail: `npm cache clean --force`
- Delete `node_modules` and reinstall if build fails
- Check webpack configuration for Module Federation issues
- Verify backend API is running when testing API integration

### Azurite (Storage Emulator)
- Must be running before starting Azure Functions
- Check ports 10000-10002 are available
- Verify connection string in local.settings.json
- Use `UseDevelopmentStorage=true` for simplified configuration

## Debugging Tips

### Multi-Project Debugging
- Use VS Code launch compounds to start multiple services
- Check individual project logs in separate terminal panels
- Verify environment variables are loaded correctly
- Use `local.settings.json` for local configuration

### Backend Debugging
- Add logging at each stage of message processing
- Use correlation IDs to trace messages across services
- Check CosmosDB for persisted messages
- Monitor Service Bus queues for message flow
- Use breakpoints in Azure Functions handlers
- Check SignalR connection status for real-time features

### Frontend Debugging
- Use React DevTools for component inspection
- Check browser console for errors and warnings
- Use Network tab to inspect API calls
- Verify CORS configuration if requests fail
- Check SignalR connection in browser dev tools
- Use TypeScript strict mode to catch type errors early

### Performance Debugging
- Monitor Azure Functions execution time
- Check NServiceBus message processing throughput
- Profile React components with React Profiler
- Optimize large file processing with chunking
- Monitor CosmosDB request units (RUs)

## Repository Structure

```
Migrate/
├── .github/
│   └── copilot-instructions.md
├── Medical/
│   ├── src/
│   │   ├── Api/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   ├── Endpoint.In/
│   │   └── Endpoint.Out/
│   └── test/
├── Beneficiary/
├── Platform/
└── README.md
```

## Quick Start (Medical System)

1. Set up environment variables in `local.settings.json` files
2. Start CosmosDB Emulator or configure connection to Azure CosmosDB
3. Run all projects using VS Code launch configuration or individual `func start` commands
4. Send test messages to API endpoints
5. Verify messages are processed and stored correctly

## Quick Reference

### Essential Commands

**Backend:**
```bash
# Build and test
dotnet build                  # Build entire solution
dotnet test                   # Run all tests
dotnet clean                  # Clean build artifacts

# Azure Functions
func start --port <port>      # Start function app
func start --cors "http://localhost:3000"  # Start with CORS for UI

# Git (use carefully - avoid force operations)
git status                    # Check repository status
git diff                      # See uncommitted changes
git log --oneline -10         # View recent commits
```

**Frontend:**
```bash
# Node.js/npm
npm install                   # Install dependencies
npm start                     # Start dev server
npm run build                 # Production build
npm test                      # Run tests
npm run lint                  # Run linter
npm run type-check            # TypeScript check

# Cleanup (use with caution)
npm cache clean --force         # Clear npm cache
npx rimraf node_modules         # Remove dependencies (cross-platform safe)
# Or delete node_modules folder manually if rimraf unavailable
```

**Services:**
```bash
# Start Azurite
azurite --silent --location c:\temp\azurite

# Check service status
curl http://localhost:7071    # Check API
curl http://localhost:3000    # Check UI
```

### File Locations

**Configuration:**
- Backend: `{Domain}/src/{Project}/local.settings.json`
- Frontend: `{Domain}/src/UI/package.json`
- Workspace: `IOM-Migrate.code-workspace`
- VS Code: `.vscode/launch.json`, `.vscode/tasks.json`

**Documentation:**
- Setup: `development-setup-guide.md`, `SECURITY-SETUP.md`
- Platform: `Platform/docs/`
- Beneficiary: `Beneficiary/docs/`
- UI: `Platform/src/UI/README.md`, `Beneficiary/src/UI/README.md`

**Sample Data:**
- `Platform/src/UI/sample-data/` - CSV files for testing bulk import

### Port Assignments

| Port | Service | Notes |
|------|---------|-------|
| 3000 | Platform UI | Also used for Beneficiary UI when running separately |
| 7071 | Medical API / Platform API | Run one at a time, or change port |
| 7072 | Medical Endpoint.In / Platform Endpoint.In | Run one at a time, or change port |
| 7073 | Medical Endpoint.Out | Medical system only |
| 7074 | Beneficiary Endpoint.In | Beneficiary system only |
| 7075 | Beneficiary API | Beneficiary system only |
| 8081 | CosmosDB Emulator | Local development |
| 10000-10002 | Azurite (Blob, Queue, Table) | Required for all Azure Functions |

### Key Patterns to Follow

1. **Always use interfaces** for services (testability)
2. **Separate concerns**: SignalR handlers vs business logic
3. **Use TypeScript** for all new frontend code
4. **Follow IOM branding** in UI components
5. **Log at appropriate levels** (Information, Warning, Error)
6. **Handle errors gracefully** with user-friendly messages
7. **Validate input** on both client and server
8. **Never commit secrets** - use templates with placeholders
9. **Write tests** for new functionality
10. **Use Git properly** - no force push to shared branches, avoid rebasing public history