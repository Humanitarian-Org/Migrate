# IOM Platform UI

A React-based micro-frontend application for the IOM Migration Platform with a focus on beneficiary bulk import functionality.

## Architecture

This UI application is built using a micro-frontend architecture with Module Federation, allowing different domains (Medical, Beneficiary, Platform) to contribute independent UI components while sharing a common shell application.

### Technology Stack

- **React 18** - Frontend framework
- **TypeScript** - Type safety and better development experience
- **Material-UI (MUI)** - Component library with IOM branding
- **Module Federation** - Micro-frontend architecture
- **React Router** - Client-side routing
- **React Hook Form** - Form validation and management
- **Papa Parse** - CSV file parsing
- **XLSX** - Excel file parsing
- **React Dropzone** - File upload with drag-and-drop

## Prerequisites

Before running this application, ensure you have the following installed:

- **Node.js** (version 18 or higher) - [Download here](https://nodejs.org/)
- **npm** (comes with Node.js) or **yarn**

## Setup Instructions

1. **Install Node.js** (if not already installed):
   - Download and install Node.js from https://nodejs.org/
   - Verify installation: `node --version` and `npm --version`

2. **Navigate to the UI directory**:
   ```bash
   cd Platform/UI
   ```

3. **Install dependencies**:
   ```bash
   npm install
   ```

4. **Start the development server**:
   ```bash
   npm start
   ```

5. **Open your browser**:
   - The application will be available at http://localhost:3000

## Available Scripts

- `npm start` - Starts the development server
- `npm run build` - Builds the app for production
- `npm test` - Runs the test suite
- `npm run lint` - Runs ESLint for code quality
- `npm run type-check` - Runs TypeScript compiler for type checking

## Features

### Beneficiary Bulk Import

The main feature of this application is the bulk import functionality for beneficiary data:

#### Supported File Formats
- CSV (.csv)
- Excel (.xlsx, .xls)

#### Required Fields
- **firstName** - Beneficiary's first name
- **lastName** - Beneficiary's last name
- **dateOfBirth** - Date in YYYY-MM-DD format
- **nationality** - Beneficiary's nationality
- **documentType** - Type of identification document
- **documentNumber** - Document identification number
- **caseStatus** - One of: PENDING, ACTIVE, COMPLETED, SUSPENDED

#### Optional Fields
- **email** - Contact email address
- **phone** - Contact phone number
- **address** - Physical address
- **city** - City of residence
- **country** - Country of residence
- **emergencyContact** - Emergency contact name
- **emergencyPhone** - Emergency contact phone
- **medicalConditions** - Any medical conditions
- **specialNeeds** - Special accommodation needs
- **caseWorker** - Assigned case worker
- **notes** - Additional notes

#### Validation Features
- **Real-time validation** - Validates data as files are uploaded
- **Error reporting** - Detailed error messages with row and field information
- **Data preview** - Shows validation results before import
- **Template download** - Provides correctly formatted CSV template

## Sample Data

The `sample-data` directory contains example CSV files for testing:

- **beneficiaries_valid.csv** - All records pass validation
- **beneficiaries_invalid.csv** - Contains various validation errors
- **beneficiaries_mixed.csv** - Mix of valid and invalid records

### Testing the Import Feature

1. Download one of the sample CSV files
2. Navigate to the Bulk Import page
3. Upload the file using drag-and-drop or file picker
4. Review the validation results
5. Import valid records or fix errors and re-upload

## Development

### Project Structure

```
Platform/UI/
├── public/                 # Static assets
├── src/
│   ├── components/         # Reusable components
│   │   ├── layout/        # Layout components (Header, Sidebar)
│   │   └── common/        # Common UI components
│   ├── pages/             # Page components
│   │   ├── Dashboard.tsx              # Main dashboard
│   │   ├── BeneficiaryBulkImport.tsx  # Bulk import page
│   │   └── NotFound.tsx               # 404 page
│   ├── theme/             # MUI theme configuration
│   ├── types/             # TypeScript type definitions
│   ├── utils/             # Utility functions
│   └── App.tsx            # Main application component
├── sample-data/           # Sample CSV files for testing
├── package.json           # Dependencies and scripts
├── tsconfig.json          # TypeScript configuration
├── webpack.config.js      # Webpack and Module Federation config
└── README.md             # This file
```

### Adding New Features

1. **Create new pages** in the `src/pages/` directory
2. **Add routes** in `src/App.tsx`
3. **Update navigation** in `src/components/layout/Sidebar.tsx`
4. **Add menu items** for new features

### Micro-Frontend Architecture

This application is designed to work with other micro-frontends:

- **Shell Application** (this app) - Provides routing, navigation, and shared components
- **Medical Module** - Medical case management features
- **Beneficiary Module** - Extended beneficiary management (future)

The configuration in `webpack.config.js` defines how modules are shared and loaded.

## IOM Branding

The application uses IOM's official color scheme:

- **Primary Blue**: #0072CE (IOM Blue)
- **Secondary Orange**: #FF6B35 (IOM Orange)
- **Supporting colors** for status indicators and UI elements

## Troubleshooting

### Common Issues

1. **Node.js not found**:
   - Install Node.js from https://nodejs.org/
   - Restart your terminal/command prompt

2. **Dependencies not installing**:
   - Clear npm cache: `npm cache clean --force`
   - Delete `node_modules` and `package-lock.json`
   - Run `npm install` again

3. **TypeScript errors**:
   - Ensure all dependencies are installed
   - Run `npm run type-check` to see detailed errors

4. **Module Federation issues**:
   - Check webpack configuration
   - Ensure other micro-frontends are running on correct ports

### Getting Help

If you encounter issues:

1. Check the browser console for error messages
2. Verify all dependencies are installed (`npm list`)
3. Check that the backend API is running (if applicable)
4. Review the sample CSV files for correct data format

## Contributing

When contributing to this project:

1. Follow the existing code style and structure
2. Add proper TypeScript types for new features
3. Update this README for new functionality
4. Test with the provided sample data files
5. Ensure the build process works: `npm run build`

## API Integration

The bulk import feature is designed to integrate with the Platform API:

- **Endpoint**: `POST /api/beneficiaries/bulk-import`
- **Format**: JSON array of validated beneficiary records
- **Response**: Import results with success/error counts

Currently, the application logs data to the console for development purposes. Update the `submitValidData` function in `BeneficiaryBulkImport.tsx` to integrate with your actual API.

## Future Enhancements

Planned features for future releases:

- **Real-time validation** during file upload
- **Duplicate detection** across existing records
- **Import history** and audit trail
- **Additional file formats** (JSON, XML)
- **Data mapping** for different CSV structures
- **Beneficiary search and management** interface
- **Advanced filtering** and reporting
- **Integration with external systems**