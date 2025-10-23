import React, { useState, useEffect } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  Box,
  Typography,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Alert,
  AlertTitle,
  Chip,
  Grid,
  Paper,
  Divider,
  FormHelperText,
  Accordion,
  AccordionSummary,
  AccordionDetails,
  LinearProgress,
  IconButton,
  Tooltip,
} from '@mui/material';
import {
  ExpandMore as ExpandMoreIcon,
  Save as SaveIcon,
  Refresh as RefreshIcon,
  Warning as WarningIcon,
  Error as ErrorIcon,
  CheckCircle as CheckCircleIcon,
  Info as InfoIcon,
  Close as CloseIcon,
} from '@mui/icons-material';

interface ValidationError {
  row: number;
  field: string;
  message: string;
  value: any;
}

interface BeneficiaryRecord {
  recordId?: string;
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
  originalRowNumber?: number; // Add this for tracking
}

interface FieldError {
  field: string;
  message: string;
  value: any;
}

interface RecordWithErrors {
  record: BeneficiaryRecord;
  errors: FieldError[];
  isFixed: boolean;
  originalRowNumber: number;
}

interface ValidationErrorFixFormProps {
  open: boolean;
  onClose: () => void;
  errors: ValidationError[];
  originalData: any[];
  onFixedRecordsUpdate: (fixedRecords: BeneficiaryRecord[]) => void;
}

const ValidationErrorFixForm: React.FC<ValidationErrorFixFormProps> = ({
  open,
  onClose,
  errors,
  originalData,
  onFixedRecordsUpdate,
}) => {
  const [recordsWithErrors, setRecordsWithErrors] = useState<RecordWithErrors[]>([]);
  const [fixedRecords, setFixedRecords] = useState<BeneficiaryRecord[]>([]);
  const [currentRecordIndex, setCurrentRecordIndex] = useState(0);
  const [isValidating, setIsValidating] = useState(false);

  // Valid options based on validation rules
  const documentTypes = ['Passport', 'National ID', 'Driver License', 'Birth Certificate', 'Other'];
  const caseStatuses = ['PENDING', 'ACTIVE', 'COMPLETED', 'SUSPENDED'];

  useEffect(() => {
    if (errors.length > 0 && originalData.length > 0) {
      groupErrorsByRecord();
    }
  }, [errors, originalData]);

  const groupErrorsByRecord = () => {
    // Group errors by row number
    const errorsByRow = errors.reduce((acc, error) => {
      if (!acc[error.row]) {
        acc[error.row] = [];
      }
      acc[error.row].push({
        field: error.field,
        message: error.message,
        value: error.value,
      });
      return acc;
    }, {} as Record<number, FieldError[]>);

    // Create records with their errors
    const recordsWithErrorsData = Object.entries(errorsByRow).map(([rowStr, rowErrors]) => {
      const rowNumber = parseInt(rowStr);
      const originalRecord = originalData[rowNumber - 2]; // -2 because row numbers are 1-indexed and have header
      
      return {
        record: { ...originalRecord },
        errors: rowErrors,
        isFixed: false,
        originalRowNumber: rowNumber,
      };
    });

    setRecordsWithErrors(recordsWithErrorsData);
  };

  const validateRecord = (record: BeneficiaryRecord): FieldError[] => {
    const errors: FieldError[] = [];

    // Required fields validation
    const requiredFields: { [key: string]: string } = {
      firstName: 'First name',
      lastName: 'Last name', 
      dateOfBirth: 'Date of birth',
      nationality: 'Nationality',
      documentType: 'Document type',
      documentNumber: 'Document number',
      caseStatus: 'Case status',
    };

    for (const [field, displayName] of Object.entries(requiredFields)) {
      const value = (record as any)[field];
      if (!value || value.toString().trim() === '') {
        errors.push({
          field,
          message: `${displayName} is required`,
          value,
        });
      }
    }

    // String length validations
    const stringLengthValidations = [
      { field: 'firstName', maxLength: 100, displayName: 'First name' },
      { field: 'lastName', maxLength: 100, displayName: 'Last name' },
      { field: 'nationality', maxLength: 50, displayName: 'Nationality' },
      { field: 'documentType', maxLength: 50, displayName: 'Document type' },
      { field: 'documentNumber', maxLength: 50, minLength: 3, displayName: 'Document number' },
      { field: 'email', maxLength: 200, displayName: 'Email' },
      { field: 'phone', maxLength: 20, displayName: 'Phone' },
      { field: 'address', maxLength: 500, displayName: 'Address' },
      { field: 'city', maxLength: 100, displayName: 'City' },
      { field: 'country', maxLength: 100, displayName: 'Country' },
      { field: 'emergencyContact', maxLength: 200, displayName: 'Emergency contact' },
      { field: 'emergencyPhone', maxLength: 20, displayName: 'Emergency phone' },
      { field: 'medicalConditions', maxLength: 1000, displayName: 'Medical conditions' },
      { field: 'specialNeeds', maxLength: 1000, displayName: 'Special needs' },
      { field: 'caseWorker', maxLength: 200, displayName: 'Case worker' },
      { field: 'notes', maxLength: 2000, displayName: 'Notes' },
    ];

    for (const validation of stringLengthValidations) {
      const value = (record as any)[validation.field];
      if (value && typeof value === 'string') {
        if (validation.maxLength && value.length > validation.maxLength) {
          errors.push({
            field: validation.field,
            message: `${validation.displayName} cannot exceed ${validation.maxLength} characters`,
            value,
          });
        }
        if (validation.minLength && value.length < validation.minLength) {
          errors.push({
            field: validation.field,
            message: `${validation.displayName} must be at least ${validation.minLength} characters`,
            value,
          });
        }
      }
    }

    // Date of birth validation
    if (record.dateOfBirth) {
      const dateRegex = /^\d{4}-\d{2}-\d{2}$/;
      if (!dateRegex.test(record.dateOfBirth)) {
        errors.push({
          field: 'dateOfBirth',
          message: 'Date of birth must be in YYYY-MM-DD format',
          value: record.dateOfBirth,
        });
      } else {
        const date = new Date(record.dateOfBirth);
        if (isNaN(date.getTime())) {
          errors.push({
            field: 'dateOfBirth',
            message: 'Invalid date format',
            value: record.dateOfBirth,
          });
        } else if (date > new Date()) {
          errors.push({
            field: 'dateOfBirth',
            message: 'Date of birth cannot be in the future',
            value: record.dateOfBirth,
          });
        } else if (date < new Date(new Date().setFullYear(new Date().getFullYear() - 150))) {
          errors.push({
            field: 'dateOfBirth',
            message: 'Date of birth cannot be more than 150 years ago',
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
          field: 'email',
          message: 'Invalid email format',
          value: record.email,
        });
      }
    }

    // Phone validation (basic format check)
    if (record.phone && record.phone.trim() !== '') {
      const phoneRegex = /^[\+]?[1-9][\d]{0,15}$/;
      if (!phoneRegex.test(record.phone.replace(/[\s\-\(\)]/g, ''))) {
        errors.push({
          field: 'phone',
          message: 'Invalid phone number format',
          value: record.phone,
        });
      }
    }

    // Emergency phone validation
    if (record.emergencyPhone && record.emergencyPhone.trim() !== '') {
      const phoneRegex = /^[\+]?[1-9][\d]{0,15}$/;
      if (!phoneRegex.test(record.emergencyPhone.replace(/[\s\-\(\)]/g, ''))) {
        errors.push({
          field: 'emergencyPhone',
          message: 'Invalid phone number format',
          value: record.emergencyPhone,
        });
      }
    }

    // Document type validation
    if (record.documentType && !documentTypes.includes(record.documentType)) {
      errors.push({
        field: 'documentType',
        message: `Document type must be one of: ${documentTypes.join(', ')}`,
        value: record.documentType,
      });
    }

    // Case status validation
    if (record.caseStatus && !caseStatuses.includes(record.caseStatus.toUpperCase())) {
      errors.push({
        field: 'caseStatus',
        message: `Case status must be one of: ${caseStatuses.join(', ')}`,
        value: record.caseStatus,
      });
    }

    return errors;
  };

  const handleFieldChange = (recordIndex: number, field: string, value: string) => {
    const updatedRecords = [...recordsWithErrors];
    (updatedRecords[recordIndex].record as any)[field] = value;

    // Re-validate the record after change
    const newErrors = validateRecord(updatedRecords[recordIndex].record);
    updatedRecords[recordIndex].errors = newErrors;
    updatedRecords[recordIndex].isFixed = newErrors.length === 0;

    setRecordsWithErrors(updatedRecords);

    // Update fixed records list
    updateFixedRecords(updatedRecords);
  };

  const updateFixedRecords = (records: RecordWithErrors[]) => {
    const fixed = records
      .filter(r => r.isFixed)
      .map(r => ({ ...r.record, recordId: r.record.recordId || crypto.randomUUID() }));
    
    setFixedRecords(fixed);
  };

  const validateAllRecords = () => {
    setIsValidating(true);
    
    const updatedRecords = recordsWithErrors.map(recordWithError => {
      const errors = validateRecord(recordWithError.record);
      return {
        ...recordWithError,
        errors,
        isFixed: errors.length === 0,
      };
    });

    setRecordsWithErrors(updatedRecords);
    updateFixedRecords(updatedRecords);
    setIsValidating(false);
  };

  const applyFixedRecords = () => {
    // Only return records that are actually fixed and include their original row number for tracking
    const validFixedRecords = recordsWithErrors
      .filter(r => r.isFixed)
      .map(r => ({ 
        ...r.record, 
        recordId: r.record.recordId || crypto.randomUUID(),
        originalRowNumber: r.originalRowNumber // Include this for proper tracking
      }));
    
    onFixedRecordsUpdate(validFixedRecords);
    onClose();
  };

  const getFieldErrorMessage = (recordIndex: number, field: string): string | undefined => {
    const record = recordsWithErrors[recordIndex];
    const error = record?.errors.find(e => e.field === field);
    return error?.message;
  };

  const hasFieldError = (recordIndex: number, field: string): boolean => {
    const record = recordsWithErrors[recordIndex];
    return record?.errors.some(e => e.field === field) || false;
  };

  const renderTextField = (
    recordIndex: number,
    field: string,
    label: string,
    required: boolean = false,
    multiline: boolean = false,
    type: string = 'text',
    placeholder?: string,
    helperTextWhenValid?: string
  ) => {
    const record = recordsWithErrors[recordIndex]?.record;
    if (!record) return null;

    const value = (record as any)[field] || '';
    const hasError = hasFieldError(recordIndex, field);
    const errorMessage = getFieldErrorMessage(recordIndex, field);

    let helperText = '';
    if (hasError) {
      helperText = errorMessage || '';
    } else if (helperTextWhenValid) {
      helperText = helperTextWhenValid;
    }

    return (
      <TextField
        fullWidth
        label={label}
        value={value}
        onChange={(e) => handleFieldChange(recordIndex, field, e.target.value)}
        error={hasError}
        helperText={helperText}
        required={required}
        multiline={multiline}
        rows={multiline ? 3 : 1}
        type={type}
        size="small"
        variant="outlined"
        placeholder={placeholder}
      />
    );
  };

  const renderSelectField = (
    recordIndex: number,
    field: string,
    label: string,
    options: string[],
    required: boolean = false
  ) => {
    const record = recordsWithErrors[recordIndex]?.record;
    if (!record) return null;

    const value = (record as any)[field] || '';
    const hasError = hasFieldError(recordIndex, field);
    const errorMessage = getFieldErrorMessage(recordIndex, field);

    return (
      <FormControl fullWidth error={hasError} required={required} size="small">
        <InputLabel>{label}</InputLabel>
        <Select
          value={value}
          label={label}
          onChange={(e) => handleFieldChange(recordIndex, field, e.target.value)}
        >
          <MenuItem value="">
            <em>Select {label}</em>
          </MenuItem>
          {options.map((option) => (
            <MenuItem key={option} value={option}>
              {option}
            </MenuItem>
          ))}
        </Select>
        {hasError && <FormHelperText>{errorMessage}</FormHelperText>}
      </FormControl>
    );
  };

  const fixedCount = recordsWithErrors.filter(r => r.isFixed).length;
  const totalCount = recordsWithErrors.length;

  return (
    <Dialog
      open={open}
      onClose={onClose}
      maxWidth="lg"
      fullWidth
      PaperProps={{
        sx: { height: '90vh', maxHeight: '90vh' }
      }}
    >
      <DialogTitle>
        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <Box>
            <Typography variant="h6" component="div">
              Fix Validation Errors
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {totalCount} records with errors • {fixedCount} fixed • {totalCount - fixedCount} remaining
            </Typography>
          </Box>
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <LinearProgress
              variant="determinate"
              value={totalCount > 0 ? (fixedCount / totalCount) * 100 : 0}
              sx={{ width: 120, mr: 2 }}
            />
            <Typography variant="body2" color="text.secondary">
              {Math.round(totalCount > 0 ? (fixedCount / totalCount) * 100 : 0)}%
            </Typography>
            <IconButton onClick={onClose} size="small">
              <CloseIcon />
            </IconButton>
          </Box>
        </Box>
      </DialogTitle>

      <DialogContent dividers sx={{ p: 0 }}>
        <Box sx={{ p: 2 }}>
          <Alert severity="info" sx={{ mb: 2 }}>
            <AlertTitle>How to Fix Validation Errors</AlertTitle>
            Edit the fields below to fix validation errors. Fields with errors are highlighted in red.
            Once all errors are fixed for a record, it will be marked as ready for import.
            <Box sx={{ mt: 1 }}>
              <Typography variant="body2" component="div">
                <strong>Quick Tips:</strong>
                <ul style={{ marginTop: 4, marginBottom: 0 }}>
                  <li>Date of Birth must be in YYYY-MM-DD format (e.g., 1990-01-15)</li>
                  <li>Document Number must be at least 3 characters long</li>
                  <li>Email must be a valid format (e.g., user@domain.com)</li>
                  <li>Phone numbers should include country code (e.g., +1234567890)</li>
                  <li>All required fields marked with * must be filled</li>
                </ul>
              </Typography>
            </Box>
          </Alert>

          {recordsWithErrors.map((recordWithError, recordIndex) => {
            const { record, errors, isFixed, originalRowNumber } = recordWithError;
            
            return (
              <Accordion 
                key={recordIndex} 
                defaultExpanded={recordIndex === 0}
                sx={{
                  mb: 2,
                  border: 1,
                  borderColor: isFixed ? 'success.main' : 'error.main',
                  '&:before': { display: 'none' },
                }}
              >
                <AccordionSummary
                  expandIcon={<ExpandMoreIcon />}
                  sx={{
                    backgroundColor: isFixed ? 'success.light' : 'error.light',
                    color: isFixed ? 'success.contrastText' : 'error.contrastText',
                    '& .MuiAccordionSummary-content': {
                      alignItems: 'center',
                    },
                  }}
                >
                  <Box sx={{ display: 'flex', alignItems: 'center', gap: 2, width: '100%' }}>
                    {isFixed ? (
                      <CheckCircleIcon color="success" />
                    ) : (
                      <ErrorIcon color="error" />
                    )}
                    <Box sx={{ flex: 1 }}>
                      <Typography variant="subtitle1" fontWeight="bold">
                        Row {originalRowNumber}: {record.firstName} {record.lastName}
                      </Typography>
                      <Typography variant="body2">
                        {isFixed 
                          ? 'All errors fixed - Ready for import'
                          : `${errors.length} error${errors.length > 1 ? 's' : ''} to fix`
                        }
                      </Typography>
                    </Box>
                    <Chip
                      label={isFixed ? 'Fixed' : `${errors.length} Errors`}
                      color={isFixed ? 'success' : 'error'}
                      variant="filled"
                      size="small"
                    />
                  </Box>
                </AccordionSummary>

                <AccordionDetails sx={{ p: 3 }}>
                  {!isFixed && (
                    <Alert severity="warning" sx={{ mb: 3 }}>
                      <AlertTitle>Errors to Fix:</AlertTitle>
                      <Box component="ul" sx={{ mt: 1, mb: 0, pl: 2 }}>
                        {errors.map((error, errorIndex) => (
                          <li key={errorIndex}>
                            <strong>{error.field}:</strong> {error.message}
                          </li>
                        ))}
                      </Box>
                    </Alert>
                  )}

                  <Grid container spacing={3}>
                    {/* Core Personal Information */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        <InfoIcon color="primary" />
                        Core Personal Information
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'firstName', 'First Name', true, false, 'text', 'John')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'lastName', 'Last Name', true, false, 'text', 'Doe')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <TextField
                        fullWidth
                        label="Date of Birth"
                        value={record.dateOfBirth || ''}
                        onChange={(e) => handleFieldChange(recordIndex, 'dateOfBirth', e.target.value)}
                        error={hasFieldError(recordIndex, 'dateOfBirth')}
                        helperText={
                          hasFieldError(recordIndex, 'dateOfBirth') 
                            ? getFieldErrorMessage(recordIndex, 'dateOfBirth')
                            : 'Format: YYYY-MM-DD (e.g., 1990-01-15)'
                        }
                        required
                        size="small"
                        variant="outlined"
                        placeholder="1990-01-15"
                        inputProps={{
                          pattern: '\\d{4}-\\d{2}-\\d{2}',
                          maxLength: 10,
                        }}
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'nationality', 'Nationality', true, false, 'text', 'Syrian')}
                    </Grid>

                    {/* Document Information */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 2 }}>
                        <InfoIcon color="primary" />
                        Document Information
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderSelectField(recordIndex, 'documentType', 'Document Type', documentTypes, true)}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'documentNumber', 'Document Number', true, false, 'text', 'ABC123456', 'Must be at least 3 characters')}
                    </Grid>

                    {/* Contact Information */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 2 }}>
                        <InfoIcon color="primary" />
                        Contact Information
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'email', 'Email', false, false, 'email', 'user@example.com', 'Valid email format required')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'phone', 'Phone', false, false, 'tel', '+1234567890', 'Include country code')}
                    </Grid>
                    <Grid item xs={12}>
                      {renderTextField(recordIndex, 'address', 'Address', false, false, 'text', '123 Main Street')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'city', 'City', false, false, 'text', 'Damascus')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'country', 'Country', false, false, 'text', 'Syria')}
                    </Grid>

                    {/* Emergency Contact */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 2 }}>
                        <InfoIcon color="primary" />
                        Emergency Contact
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'emergencyContact', 'Emergency Contact', false, false, 'text', 'Jane Doe')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'emergencyPhone', 'Emergency Phone', false, false, 'tel', '+1234567891', 'Include country code')}
                    </Grid>

                    {/* Medical Information */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 2 }}>
                        <InfoIcon color="primary" />
                        Medical Information
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'medicalConditions', 'Medical Conditions', false, true, 'text', 'None or specify conditions')}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'specialNeeds', 'Special Needs', false, true, 'text', 'None or specify needs')}
                    </Grid>

                    {/* Case Management */}
                    <Grid item xs={12}>
                      <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1, mt: 2 }}>
                        <InfoIcon color="primary" />
                        Case Management
                      </Typography>
                      <Divider sx={{ mb: 2 }} />
                    </Grid>

                    <Grid item xs={12} md={6}>
                      {renderSelectField(recordIndex, 'caseStatus', 'Case Status', caseStatuses, true)}
                    </Grid>
                    <Grid item xs={12} md={6}>
                      {renderTextField(recordIndex, 'caseWorker', 'Case Worker', false, false, 'text', 'Sarah Smith')}
                    </Grid>
                    <Grid item xs={12}>
                      {renderTextField(recordIndex, 'notes', 'Notes', false, true, 'text', 'Additional notes about the beneficiary')}
                    </Grid>
                  </Grid>
                </AccordionDetails>
              </Accordion>
            );
          })}
        </Box>
      </DialogContent>

      <DialogActions sx={{ px: 3, py: 2, gap: 1 }}>
        <Box sx={{ flex: 1, display: 'flex', alignItems: 'center', gap: 2 }}>
          <Typography variant="body2" color="text.secondary">
            {fixedCount} of {totalCount} records fixed
          </Typography>
          {fixedCount > 0 && (
            <Chip
              label={`${fixedCount} Ready for Import`}
              color="success"
              variant="outlined"
              size="small"
              icon={<CheckCircleIcon />}
            />
          )}
        </Box>
        
        <Button
          onClick={validateAllRecords}
          startIcon={<RefreshIcon />}
          disabled={isValidating}
          variant="outlined"
        >
          {isValidating ? 'Validating...' : 'Re-validate All'}
        </Button>
        
        <Button onClick={onClose} variant="outlined">
          Cancel
        </Button>
        
        <Button
          onClick={applyFixedRecords}
          variant="contained"
          startIcon={<SaveIcon />}
          disabled={fixedCount === 0}
          color="primary"
        >
          Apply {fixedCount} Fixed Record{fixedCount !== 1 ? 's' : ''}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ValidationErrorFixForm;