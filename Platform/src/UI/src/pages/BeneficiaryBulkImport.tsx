import React, { useState, useCallback } from 'react';
import {
  Box,
  Typography,
  Paper,
  Button,
  Grid,
  Alert,
  AlertTitle,
  LinearProgress,
  Chip,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  List,
  ListItem,
  ListItemText,
  Divider,
  Card,
  CardContent,
  Snackbar,
} from '@mui/material';
import {
  CloudUpload as UploadIcon,
  CheckCircle as SuccessIcon,
  Error as ErrorIcon,
  Warning as WarningIcon,
  Download as DownloadIcon,
  Refresh as RefreshIcon,
  SignalCellularAlt as SignalIcon,
  Visibility as ViewIcon,
  OpenInNew as OpenInNewIcon,
  Edit as EditIcon,
  Help as HelpIcon,
} from '@mui/icons-material';
import { useDropzone } from 'react-dropzone';
import { useNavigate } from 'react-router-dom';
import Papa from 'papaparse';
import * as XLSX from 'xlsx';
import { useSignalR, UploadStartedMessage, UploadProgressMessage, UploadCompletedMessage } from '../hooks/useSignalR';
import ValidationErrorFixForm from '../components/ValidationErrorFixForm';
import ValidationRulesDialog from '../components/ValidationRulesDialog';

interface BeneficiaryRecord {
  recordId?: string; // GUID generated for tracking individual record processing
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  nationality: string;
  documentType: string;
  documentNumber: string;
  email?: string;
  phone?: string;
  address?: string;
  city?: string;
  country?: string;
  emergencyContact?: string;
  emergencyPhone?: string;
  medicalConditions?: string;
  specialNeeds?: string;
  caseStatus: 'PENDING' | 'ACTIVE' | 'COMPLETED' | 'SUSPENDED';
  caseWorker?: string;
  notes?: string;
  originalRowNumber?: number; // Add this for tracking fixed records
  result?: {
    status: 'Pending' | 'Success' | 'Failed';
    beneficiaryId?: string | null;
    errorMessage?: string | null;
    processedAt?: string | null;
  };
}

interface ValidationError {
  row: number;
  field: string;
  message: string;
  value: any;
}

interface ProcessingResult {
  totalRows: number;
  validRows: number;
  invalidRows: number;
  errors: ValidationError[];
  data: BeneficiaryRecord[];
}

interface UploadStatus {
  isUploading: boolean;
  correlationId?: string;
  uploadId?: string;
  progress?: number;
  status?: string;
  isCompleted: boolean;
  errors?: string[];
  totalRecords?: number;
  processedRecords?: number;
  successfulRecords?: number;
  failedRecords?: number;
  fileName?: string;
}

const BeneficiaryBulkImport: React.FC = () => {
  const navigate = useNavigate();
  const [isProcessing, setIsProcessing] = useState(false);
  const [result, setResult] = useState<ProcessingResult | null>(null);
  const [showErrorDialog, setShowErrorDialog] = useState(false);
  const [showFixForm, setShowFixForm] = useState(false);
  const [showValidationRules, setShowValidationRules] = useState(false);
  const [uploadedFile, setUploadedFile] = useState<File | null>(null);
  const [originalFileData, setOriginalFileData] = useState<any[]>([]);
  const [uploadStatus, setUploadStatus] = useState<UploadStatus>({
    isUploading: false,
    isCompleted: false,
  });
  const [notification, setNotification] = useState<{
    message: string;
    severity: 'success' | 'info' | 'warning' | 'error';
    open: boolean;
  }>({ message: '', severity: 'info', open: false });

  // SignalR integration
  const { connectionState, joinUploadGroup } = useSignalR({
    onUploadStarted: (message: any) => {
      console.log('Upload started notification:', message);
      
      setUploadStatus(prev => ({
        ...prev,
        isUploading: true,
        correlationId: message.CorrelationId,
        uploadId: message.UploadId,
        status: 'Processing started',
        progress: 0,
        totalRecords: message.TotalRecordsCount,
        processedRecords: 0,
        successfulRecords: 0,
        failedRecords: 0,
        fileName: message.FileName,
      }));
      setNotification({
        message: `Upload processing started for ${message.FileName} (${message.TotalRecordsCount} records)`,
        severity: 'info',
        open: true,
      });
    },
    onUploadProgress: (message: any) => {
      console.log('Upload progress notification:', message);
      
      // Use PascalCase property names (as they appear on the wire from SignalR)
      const processedRecords = message.ProcessedRecords || 0;
      const totalRecords = message.TotalRecords;
      const successfulRecords = message.SuccessfulRecords || 0;
      const failedRecords = message.FailedRecords || 0;
      const percentage = message.PercentageComplete || 0;
      const status = message.CurrentStatus;
      
      setUploadStatus(prev => ({
        ...prev,
        progress: percentage,
        status: status,
        processedRecords: processedRecords,
        totalRecords: totalRecords || prev.totalRecords,
        successfulRecords: successfulRecords,
        failedRecords: failedRecords,
      }));
      
      setNotification({
        message: `Processing: ${processedRecords}/${totalRecords || 'N/A'} | Success: ${successfulRecords} | Failed: ${failedRecords} (${Math.round(percentage)}%)`,
        severity: 'info',
        open: true,
      });
    },
    onUploadCompleted: (message: any) => {
      console.log('Upload completed notification:', message);
      
      // Extract final counts from the completion message (PascalCase)
      const totalRecords = message.TotalRecords;
      const successfulRecords = message.SuccessfulRecords || 0;
      const failedRecords = message.FailedRecords || 0;
      const processedRecords = successfulRecords + failedRecords;
      
      setUploadStatus(prev => ({
        ...prev,
        isUploading: false,
        isCompleted: true,
        status: message.Status || 'Completed',
        progress: 100,
        errors: message.Errors,
        processedRecords: processedRecords,
        successfulRecords: successfulRecords,
        failedRecords: failedRecords,
        totalRecords: totalRecords || prev.totalRecords,
      }));
      
      const hasErrors = failedRecords > 0;
      setNotification({
        message: hasErrors 
          ? `Upload completed: ${successfulRecords} successful, ${failedRecords} failed out of ${totalRecords} total`
          : `Upload completed successfully! All ${successfulRecords} records processed.`,
        severity: hasErrors ? 'warning' : 'success',
        open: true,
      });
    },
    onConnectionStateChanged: (state) => {
      console.log('SignalR connection state:', state);
    },
  });

  // Helper function to format field names for user-friendly error messages
  const formatFieldName = (field: string): string => {
    const fieldNames: { [key: string]: string } = {
      firstName: 'First name',
      lastName: 'Last name',
      dateOfBirth: 'Date of birth',
      nationality: 'Nationality',
      documentType: 'Document type',
      documentNumber: 'Document number',
      email: 'Email',
      phone: 'Phone number',
      address: 'Address',
      city: 'City',
      country: 'Country',
      emergencyContact: 'Emergency contact name',
      emergencyPhone: 'Emergency phone number',
      medicalConditions: 'Medical conditions',
      specialNeeds: 'Special needs',
      caseStatus: 'Case status',
      caseWorker: 'Case worker name',
      notes: 'Notes',
    };
    return fieldNames[field] || field;
  };

  const validateBeneficiaryRecord = (record: any, rowIndex: number): ValidationError[] => {
    const errors: ValidationError[] = [];

    // Required fields validation
    const requiredFields = ['firstName', 'lastName', 'dateOfBirth', 'nationality', 'documentType', 'documentNumber', 'caseStatus'];
    
    for (const field of requiredFields) {
      if (!record[field] || record[field].toString().trim() === '') {
        errors.push({
          row: rowIndex,
          field,
          message: `${formatFieldName(field)} is required`,
          value: record[field],
        });
      }
    }

    // Field length validation
    const fieldLengthLimits: { [key: string]: number } = {
      firstName: 43,
      lastName: 100,
      nationality: 50,
      documentType: 50,
      documentNumber: 50,
      email: 200,
      phone: 20,
      address: 500,
      city: 100,
      country: 100,
      emergencyContact: 200,
      emergencyPhone: 20,
      medicalConditions: 1000,
      specialNeeds: 1000,
      caseWorker: 200,
      notes: 2000,
    };

    for (const [field, maxLength] of Object.entries(fieldLengthLimits)) {
      if (record[field] && record[field].toString().length > maxLength) {
        errors.push({
          row: rowIndex,
          field,
          message: `${formatFieldName(field)} cannot exceed ${maxLength} characters`,
          value: record[field],
        });
      }
    }

    // Date validation
    if (record.dateOfBirth) {
      const dateRegex = /^\d{4}-\d{2}-\d{2}$/;
      if (!dateRegex.test(record.dateOfBirth)) {
        errors.push({
          row: rowIndex,
          field: 'dateOfBirth',
          message: 'Date of birth must be in YYYY-MM-DD format',
          value: record.dateOfBirth,
        });
      } else {
        const date = new Date(record.dateOfBirth);
        if (isNaN(date.getTime()) || date > new Date()) {
          errors.push({
            row: rowIndex,
            field: 'dateOfBirth',
            message: 'Invalid date or future date not allowed',
            value: record.dateOfBirth,
          });
        }
      }
    }

    // Email validation
    if (record.email && record.email.trim() !== '') {
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!emailRegex.test(record.email)) {
        errors.push({
          row: rowIndex,
          field: 'email',
          message: 'Invalid email format',
          value: record.email,
        });
      }
    }

    // Case status validation
    const validStatuses = ['PENDING', 'ACTIVE', 'COMPLETED', 'SUSPENDED'];
    if (record.caseStatus && !validStatuses.includes(record.caseStatus.toUpperCase())) {
      errors.push({
        row: rowIndex,
        field: 'caseStatus',
        message: `Case status must be one of: ${validStatuses.join(', ')}`,
        value: record.caseStatus,
      });
    }

    // Document number validation (should not be empty and unique)
    if (record.documentNumber && record.documentNumber.toString().length < 3) {
      errors.push({
        row: rowIndex,
        field: 'documentNumber',
        message: 'Document number must be at least 3 characters',
        value: record.documentNumber,
      });
    }

    return errors;
  };

  const processFile = useCallback((file: File) => {
    setIsProcessing(true);
    setResult(null);

    const fileExtension = file.name.split('.').pop()?.toLowerCase();

    if (fileExtension === 'csv') {
      Papa.parse(file, {
        header: true,
        skipEmptyLines: true,
        complete: (results) => {
          processData(results.data as any[]);
        },
        error: (error) => {
          console.error('CSV parsing error:', error);
          setIsProcessing(false);
        },
      });
    } else if (fileExtension === 'xlsx' || fileExtension === 'xls') {
      const reader = new FileReader();
      reader.onload = (e) => {
        try {
          const data = new Uint8Array(e.target?.result as ArrayBuffer);
          const workbook = XLSX.read(data, { type: 'array' });
          const firstSheetName = workbook.SheetNames[0];
          const worksheet = workbook.Sheets[firstSheetName];
          const jsonData = XLSX.utils.sheet_to_json(worksheet);
          processData(jsonData as any[]);
        } catch (error) {
          console.error('Excel parsing error:', error);
          setIsProcessing(false);
        }
      };
      reader.readAsArrayBuffer(file);
    } else {
      alert('Please upload a CSV or Excel file');
      setIsProcessing(false);
    }
  }, []);

  const processData = (data: any[]) => {
    setOriginalFileData(data); // Store original data for error fixing
    const allErrors: ValidationError[] = [];
    const validRecords: BeneficiaryRecord[] = [];

    data.forEach((record, index) => {
      const rowErrors = validateBeneficiaryRecord(record, index + 2); // +2 because header is row 1
      allErrors.push(...rowErrors);

      if (rowErrors.length === 0) {
        validRecords.push({
          ...record,
          caseStatus: record.caseStatus?.toUpperCase() || 'PENDING',
        });
      }
    });

    setResult({
      totalRows: data.length,
      validRows: validRecords.length,
      invalidRows: data.length - validRecords.length,
      errors: allErrors,
      data: validRecords,
    });

    setIsProcessing(false);
  };

  const onDrop = useCallback((acceptedFiles: File[]) => {
    const file = acceptedFiles[0];
    if (file) {
      setUploadedFile(file);
      processFile(file);
    }
  }, [processFile]);

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop,
    accept: {
      'text/csv': ['.csv'],
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet': ['.xlsx'],
      'application/vnd.ms-excel': ['.xls'],
    },
    multiple: false,
  });

  const downloadTemplate = () => {
    const template = [
      {
        firstName: 'John',
        lastName: 'Doe',
        dateOfBirth: '1990-01-15',
        nationality: 'Syrian',
        documentType: 'Passport',
        documentNumber: 'SY123456789',
        email: 'john.doe@email.com',
        phone: '+1234567890',
        address: '123 Main Street',
        city: 'Damascus',
        country: 'Syria',
        emergencyContact: 'Jane Doe',
        emergencyPhone: '+1234567891',
        medicalConditions: 'None',
        specialNeeds: 'None',
        caseStatus: 'PENDING',
        caseWorker: 'Sarah Smith',
        notes: 'Initial registration',
      },
    ];

    const csv = Papa.unparse(template);
    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    const url = URL.createObjectURL(blob);
    link.setAttribute('href', url);
    link.setAttribute('download', 'beneficiary_template.csv');
    link.style.visibility = 'hidden';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  const resetUpload = () => {
    setUploadedFile(null);
    setResult(null);
    setOriginalFileData([]);
    setIsProcessing(false);
    setShowFixForm(false);
    setUploadStatus({
      isUploading: false,
      isCompleted: false,
    });
  };

  const handleFixedRecordsUpdate = (fixedRecords: BeneficiaryRecord[]) => {
    if (!result) return;

    // Add fixed records to the valid records list
    const updatedValidRecords = [...result.data, ...fixedRecords];
    
    // Get the row numbers that were fixed
    const fixedRowNumbers = new Set(
      fixedRecords
        .map(r => r.originalRowNumber)
        .filter(rowNum => rowNum !== undefined) as number[]
    );

    // Remove all errors for the fixed rows
    const remainingErrors = result.errors.filter(error => !fixedRowNumbers.has(error.row));

    // Update the result
    setResult({
      ...result,
      validRows: updatedValidRecords.length,
      invalidRows: result.totalRows - updatedValidRecords.length,
      errors: remainingErrors,
      data: updatedValidRecords,
    });

    setShowFixForm(false);
  };

  const submitValidData = async () => {
    if (!result || result.validRows === 0) return;

    try {
      setIsProcessing(true);
      
      // Generate correlation ID for SignalR tracking
      const correlationId = crypto.randomUUID();
      
      // Generate unique RecordId for each beneficiary record
      const recordsWithIds = result.data.map(record => ({
        ...record,
        recordId: crypto.randomUUID(), // Generate GUID for each record in browser
        result: {
          status: 'Pending',
          beneficiaryId: null,
          errorMessage: null,
          processedAt: null
        }
      }));
      
      // Prepare the request payload
      const uploadRequest = {
        uploadId: crypto.randomUUID(),
        correlationId: correlationId,
        fileName: uploadedFile?.name || 'unknown.csv',
        userId: 'current-user', // TODO: Get from authentication context
        records: recordsWithIds
      };

      // Join SignalR group for this upload
      await joinUploadGroup(correlationId);

      // Send to Platform API
      const response = await fetch('/api/beneficiary/bulk-upload', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(uploadRequest),
      });

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`API Error: ${response.status} - ${errorText}`);
      }

      const responseData = await response.json();
      
      // Update upload status
      setUploadStatus({
        isUploading: true,
        correlationId: correlationId,
        uploadId: responseData.uploadId,
        progress: 0,
        status: 'Upload submitted',
        isCompleted: false,
      });
      
      setNotification({
        message: `Upload submitted successfully! Processing ${result.validRows} records...`,
        severity: 'success',
        open: true,
      });
      
    } catch (error) {
      console.error('Error submitting data:', error);
      setNotification({
        message: `Error importing beneficiaries: ${error instanceof Error ? error.message : 'Unknown error'}`,
        severity: 'error',
        open: true,
      });
      setUploadStatus(prev => ({
        ...prev,
        isUploading: false,
      }));
    } finally {
      setIsProcessing(false);
    }
  };

  return (
    <Box sx={{ p: 3 }}>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 2 }}>
        <Typography variant="h4" component="h1">
          Bulk Import Beneficiaries
        </Typography>
        
        {/* SignalR Connection Status */}
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <SignalIcon 
            color={connectionState === 'Connected' ? 'success' : connectionState === 'Connecting' ? 'warning' : 'error'}
          />
          <Typography variant="body2" color="text.secondary">
            {connectionState}
          </Typography>
        </Box>
      </Box>

      <Typography variant="body1" color="text.secondary" paragraph>
        Upload a CSV or Excel file to import multiple beneficiaries at once.
        The file should contain all required beneficiary information.
      </Typography>

      {/* Help Section */}
      <Box sx={{ mb: 3, display: 'flex', gap: 2, alignItems: 'center', flexWrap: 'wrap' }}>
        <Button
          variant="outlined"
          size="small"
          startIcon={<HelpIcon />}
          onClick={() => setShowValidationRules(true)}
          sx={{ textTransform: 'none' }}
        >
          View Validation Rules
        </Button>
        <Button
          variant="outlined"
          size="small"
          startIcon={<DownloadIcon />}
          onClick={downloadTemplate}
          sx={{ textTransform: 'none' }}
        >
          Download Template
        </Button>
        <Typography variant="caption" color="text.secondary" sx={{ ml: 1 }}>
          Need help? Check the validation rules or download our template to get started.
        </Typography>
      </Box>

      {/* Upload Status Progress */}
      {uploadStatus.isUploading && (
        <Alert severity="info" sx={{ mb: 2 }}>
          <AlertTitle>Processing Upload: {uploadStatus.fileName}</AlertTitle>
          <Box sx={{ mt: 1 }}>
            <Typography variant="body2" gutterBottom>
              {uploadStatus.status}
            </Typography>
            
            {/* Progress counts */}
            <Grid container spacing={2} sx={{ mt: 1, mb: 2 }}>
              <Grid item xs={3}>
                <Box textAlign="center">
                  <Typography variant="h6" color="primary" sx={{ minWidth: 50 }}>
                    {uploadStatus.processedRecords || 0}
                  </Typography>
                  <Typography variant="caption" color="text.secondary">
                    Processed
                  </Typography>
                </Box>
              </Grid>
              <Grid item xs={3}>
                <Box textAlign="center">
                  <Typography variant="h6" color="success.main" sx={{ minWidth: 50 }}>
                    {uploadStatus.successfulRecords || 0}
                  </Typography>
                  <Typography variant="caption" color="text.secondary">
                    Success
                  </Typography>
                </Box>
              </Grid>
              <Grid item xs={3}>
                <Box textAlign="center">
                  <Typography variant="h6" color="error.main" sx={{ minWidth: 50 }}>
                    {uploadStatus.failedRecords || 0}
                  </Typography>
                  <Typography variant="caption" color="text.secondary">
                    Failed
                  </Typography>
                </Box>
              </Grid>
              <Grid item xs={3}>
                <Box textAlign="center">
                  <Typography variant="h6" color="text.primary" sx={{ minWidth: 50 }}>
                    {uploadStatus.totalRecords || 0}
                  </Typography>
                  <Typography variant="caption" color="text.secondary">
                    Total
                  </Typography>
                </Box>
              </Grid>
            </Grid>

            <LinearProgress 
              variant="determinate" 
              value={uploadStatus.progress || 0} 
              sx={{ mt: 1 }}
            />
            <Typography variant="body2" sx={{ mt: 1 }}>
              {Math.round(uploadStatus.progress || 0)}% complete
            </Typography>
          </Box>
        </Alert>
      )}

      {/* Upload Completed Status */}
      {uploadStatus.isCompleted && (
        <Alert 
          severity={(uploadStatus.failedRecords || 0) > 0 ? 'warning' : 'success'} 
          sx={{ mb: 2 }}
        >
          <AlertTitle>Upload Completed: {uploadStatus.fileName}</AlertTitle>
          
          {/* Final Results Summary */}
          <Grid container spacing={2} sx={{ mt: 1, mb: 2 }}>
            <Grid item xs={3}>
              <Box textAlign="center">
                <Typography variant="h5" color="primary">
                  {uploadStatus.processedRecords || 0}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Total Processed
                </Typography>
              </Box>
            </Grid>
            <Grid item xs={3}>
              <Box textAlign="center">
                <Typography variant="h5" color="success.main">
                  {uploadStatus.successfulRecords || 0}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Successful
                </Typography>
              </Box>
            </Grid>
            <Grid item xs={3}>
              <Box textAlign="center">
                <Typography variant="h5" color="error.main">
                  {uploadStatus.failedRecords || 0}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Failed
                </Typography>
              </Box>
            </Grid>
            <Grid item xs={3}>
              <Box textAlign="center">
                <Typography variant="h5" color="text.primary">
                  {uploadStatus.totalRecords || 0}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Total Records
                </Typography>
              </Box>
            </Grid>
          </Grid>

          <Typography variant="body2" gutterBottom>
            Status: {uploadStatus.status}
          </Typography>
          
          {uploadStatus.errors && uploadStatus.errors.length > 0 && (
            <Typography variant="body2" color="error" gutterBottom>
              Errors: {uploadStatus.errors.join(', ')}
            </Typography>
          )}

          {/* Link to Processing Details */}
          {uploadStatus.correlationId && (
            <Box sx={{ mt: 2, display: 'flex', gap: 1, alignItems: 'center' }}>
              <Button
                variant="outlined"
                size="small"
                startIcon={<ViewIcon />}
                endIcon={<OpenInNewIcon />}
                onClick={() => {
                  // Navigate to the details page with the correlation ID
                  navigate(`/beneficiary/bulk-import/details/${uploadStatus.correlationId}`);
                }}
                sx={{ textTransform: 'none' }}
              >
                View Processing Details
              </Button>
              <Typography variant="caption" color="text.secondary" sx={{ ml: 1 }}>
                Review individual record results and error details
              </Typography>
            </Box>
          )}
        </Alert>
      )}

      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper
            {...getRootProps()}
            sx={{
              p: 4,
              textAlign: 'center',
              border: '2px dashed',
              borderColor: isDragActive ? 'primary.main' : 'grey.300',
              backgroundColor: isDragActive ? 'primary.light' : 'grey.50',
              cursor: 'pointer',
              transition: 'all 0.2s ease-in-out',
              '&:hover': {
                borderColor: 'primary.main',
                backgroundColor: 'primary.light',
              },
            }}
          >
            <input {...getInputProps()} />
            <UploadIcon sx={{ fontSize: 48, color: 'primary.main', mb: 2 }} />
            
            {uploadedFile ? (
              <Box>
                <Typography variant="h6" gutterBottom>
                  File Uploaded: {uploadedFile.name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Click to upload a different file or drag and drop here
                </Typography>
              </Box>
            ) : (
              <Box>
                <Typography variant="h6" gutterBottom>
                  {isDragActive ? 'Drop the file here' : 'Drag and drop a file here, or click to select'}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  Supports CSV, XLS, and XLSX files
                </Typography>
              </Box>
            )}

            {isProcessing && (
              <Box sx={{ mt: 2 }}>
                <LinearProgress />
                <Typography variant="body2" sx={{ mt: 1 }}>
                  Processing file...
                </Typography>
              </Box>
            )}
          </Paper>

          {result && (
            <Box sx={{ mt: 3 }}>
              <Typography variant="h6" gutterBottom>
                Processing Results
              </Typography>

              <Grid container spacing={2} sx={{ mb: 3 }}>
                <Grid item xs={6} sm={3}>
                  <Card>
                    <CardContent sx={{ textAlign: 'center' }}>
                      <Typography variant="h4" color="primary">
                        {result.totalRows}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        Total Records
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
                <Grid item xs={6} sm={3}>
                  <Card>
                    <CardContent sx={{ textAlign: 'center' }}>
                      <Typography variant="h4" color="success.main">
                        {result.validRows}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        Valid Records
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
                <Grid item xs={6} sm={3}>
                  <Card>
                    <CardContent sx={{ textAlign: 'center' }}>
                      <Typography variant="h4" color="error.main">
                        {result.invalidRows}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        Invalid Records
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
                <Grid item xs={6} sm={3}>
                  <Card>
                    <CardContent sx={{ textAlign: 'center' }}>
                      <Typography variant="h4" color="warning.main">
                        {result.errors.length}
                      </Typography>
                      <Typography variant="body2" color="text.secondary">
                        Total Errors
                      </Typography>
                    </CardContent>
                  </Card>
                </Grid>
              </Grid>

              {result.errors.length > 0 && (
                <Alert severity="warning" sx={{ mb: 2 }}>
                  <AlertTitle>Validation Errors Found</AlertTitle>
                  {result.errors.length} validation errors found in the uploaded file.
                  <Box sx={{ mt: 1, display: 'flex', gap: 1 }}>
                    <Button
                      size="small"
                      onClick={() => setShowErrorDialog(true)}
                      variant="outlined"
                    >
                      View Details
                    </Button>
                    <Button
                      size="small"
                      onClick={() => setShowFixForm(true)}
                      variant="contained"
                      startIcon={<EditIcon />}
                      color="primary"
                    >
                      Fix Errors
                    </Button>
                  </Box>
                </Alert>
              )}

              {result.validRows > 0 && (
                <Alert severity="success" sx={{ mb: 2 }}>
                  <AlertTitle>Ready to Import</AlertTitle>
                  {result.validRows} valid records are ready for import.
                </Alert>
              )}

              <Box sx={{ display: 'flex', gap: 2, flexWrap: 'wrap' }}>
                <Button
                  variant="contained"
                  color="primary"
                  startIcon={<SuccessIcon />}
                  onClick={submitValidData}
                  disabled={result.validRows === 0 || isProcessing || uploadStatus.isUploading}
                >
                  {isProcessing ? 'Submitting...' : 
                   uploadStatus.isUploading ? 'Processing...' : 
                   `Import ${result.validRows} Valid Records`}
                </Button>
                
                <Button
                  variant="outlined"
                  startIcon={<RefreshIcon />}
                  onClick={resetUpload}
                  disabled={uploadStatus.isUploading}
                >
                  Upload New File
                </Button>

                {result.errors.length > 0 && (
                  <>
                    <Button
                      variant="outlined"
                      color="warning"
                      startIcon={<ErrorIcon />}
                      onClick={() => setShowErrorDialog(true)}
                    >
                      View Errors ({result.errors.length})
                    </Button>
                    
                    <Button
                      variant="contained"
                      color="secondary"
                      startIcon={<EditIcon />}
                      onClick={() => setShowFixForm(true)}
                    >
                      Fix Errors ({result.errors.length})
                    </Button>
                  </>
                )}
              </Box>
            </Box>
          )}
        </Grid>
      </Grid>

      {/* Validation Rules Dialog */}
      <ValidationRulesDialog
        open={showValidationRules}
        onClose={() => setShowValidationRules(false)}
      />

      {/* Validation Error Fix Form */}
      <ValidationErrorFixForm
        open={showFixForm}
        onClose={() => setShowFixForm(false)}
        errors={result?.errors || []}
        originalData={originalFileData}
        onFixedRecordsUpdate={handleFixedRecordsUpdate}
      />

      {/* Error Details Dialog (Read-only) */}
      <Dialog
        open={showErrorDialog}
        onClose={() => setShowErrorDialog(false)}
        maxWidth="md"
        fullWidth
      >
        <DialogTitle>Validation Errors</DialogTitle>
        <DialogContent>
          {result && result.errors.length > 0 && (
            <TableContainer>
              <Table size="small">
                <TableHead>
                  <TableRow>
                    <TableCell>Row</TableCell>
                    <TableCell>Field</TableCell>
                    <TableCell>Error</TableCell>
                    <TableCell>Value</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {result.errors.map((error, index) => (
                    <TableRow key={index}>
                      <TableCell>{error.row}</TableCell>
                      <TableCell>
                        <Chip label={error.field} size="small" color="primary" />
                      </TableCell>
                      <TableCell>{error.message}</TableCell>
                      <TableCell>
                        <code>{String(error.value)}</code>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setShowErrorDialog(false)}>Close</Button>
        </DialogActions>
      </Dialog>

      {/* Notification Snackbar */}
      <Snackbar
        open={notification.open}
        autoHideDuration={6000}
        onClose={() => setNotification(prev => ({ ...prev, open: false }))}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      >
        <Alert 
          onClose={() => setNotification(prev => ({ ...prev, open: false }))}
          severity={notification.severity}
          sx={{ width: '100%' }}
        >
          {notification.message}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default BeneficiaryBulkImport;