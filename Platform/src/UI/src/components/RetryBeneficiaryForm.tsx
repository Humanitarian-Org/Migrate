import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
  Grid,
  Alert,
  CircularProgress,
  MenuItem,
  Typography,
  Box,
  Divider,
} from '@mui/material';
import {
  Save as SaveIcon,
  Cancel as CancelIcon,
  Refresh as RetryIcon,
} from '@mui/icons-material';

interface BeneficiaryProcessingResult {
  beneficiaryId: string;
  firstName: string;
  lastName: string;
  status: string;
  error?: string;
  processedAt: string;
}

interface RetryBeneficiaryFormProps {
  open: boolean;
  onClose: () => void;
  beneficiary: BeneficiaryProcessingResult | null;
  originalData: any; // Original beneficiary data from the upload
  correlationId: string;
  onSuccess: (beneficiaryId: string) => void;
}

interface BeneficiaryFormData {
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
  caseStatus: string;
  caseWorker?: string;
  notes?: string;
}

const RetryBeneficiaryForm: React.FC<RetryBeneficiaryFormProps> = ({
  open,
  onClose,
  beneficiary,
  originalData,
  correlationId,
  onSuccess,
}) => {
  const [formData, setFormData] = useState<BeneficiaryFormData>({
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    nationality: '',
    documentType: '',
    documentNumber: '',
    email: '',
    phone: '',
    address: '',
    city: '',
    country: '',
    emergencyContact: '',
    emergencyPhone: '',
    medicalConditions: '',
    specialNeeds: '',
    caseStatus: 'PENDING',
    caseWorker: '',
    notes: '',
  });

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [validationErrors, setValidationErrors] = useState<string[]>([]);
  const [fieldErrors, setFieldErrors] = useState<Record<string, string>>({});

  // Initialize form data when dialog opens
  React.useEffect(() => {
    if (open && originalData) {
      setFormData({
        firstName: originalData.firstName || '',
        lastName: originalData.lastName || '',
        dateOfBirth: originalData.dateOfBirth || '',
        nationality: originalData.nationality || '',
        documentType: originalData.documentType || '',
        documentNumber: originalData.documentNumber || '',
        email: originalData.email || '',
        phone: originalData.phone || '',
        address: originalData.address || '',
        city: originalData.city || '',
        country: originalData.country || '',
        emergencyContact: originalData.emergencyContact || '',
        emergencyPhone: originalData.emergencyPhone || '',
        medicalConditions: originalData.medicalConditions || '',
        specialNeeds: originalData.specialNeeds || '',
        caseStatus: originalData.caseStatus || 'PENDING',
        caseWorker: originalData.caseWorker || '',
        notes: originalData.notes || '',
      });
      setError(null);
      setValidationErrors([]);
      setFieldErrors({});
    }
  }, [open, originalData]);

  const validateField = (field: keyof BeneficiaryFormData, value: string): string => {
    switch (field) {
      case 'firstName':
        if (!value.trim()) return 'First name is required';
        if (value.length > 37) return 'First name cannot exceed 37 characters';
        break;
      
      case 'lastName':
        if (!value.trim()) return 'Last name is required';
        if (value.length > 100) return 'Last name cannot exceed 100 characters';
        break;
      
      case 'dateOfBirth':
        if (!value.trim()) return 'Date of birth is required';
        if (!/^\d{4}-\d{2}-\d{2}$/.test(value)) return 'Date of birth must be in YYYY-MM-DD format';
        
        const birthDate = new Date(value);
        const today = new Date();
        const maxAge = new Date();
        maxAge.setFullYear(today.getFullYear() - 150);
        
        if (isNaN(birthDate.getTime())) return 'Date of birth must be a valid date';
        if (birthDate > today) return 'Date of birth cannot be in the future';
        if (birthDate < maxAge) return 'Date of birth cannot be more than 150 years ago';
        break;
      
      case 'nationality':
        if (!value.trim()) return 'Nationality is required';
        if (value.length > 50) return 'Nationality cannot exceed 50 characters';
        break;
      
      case 'documentType':
        if (!value.trim()) return 'Document type is required';
        const validDocumentTypes = ['Passport', 'National ID', 'Driver License', 'Birth Certificate', 'Other'];
        if (!validDocumentTypes.includes(value)) return 'Document type must be one of: Passport, National ID, Driver License, Birth Certificate, Other';
        break;
      
      case 'documentNumber':
        if (!value.trim()) return 'Document number is required';
        if (value.length < 3) return 'Document number must be at least 3 characters';
        if (value.length > 50) return 'Document number cannot exceed 50 characters';
        break;
      
      case 'caseStatus':
        const validCaseStatuses = ['PENDING', 'ACTIVE', 'COMPLETED', 'SUSPENDED'];
        if (!validCaseStatuses.includes(value.toUpperCase())) return 'Case status must be one of: PENDING, ACTIVE, COMPLETED, SUSPENDED';
        break;
      
      case 'email':
        if (value && value.trim() !== '') {
          if (value.length > 200) return 'Email cannot exceed 200 characters';
          const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
          if (!emailRegex.test(value)) return 'Invalid email format';
        }
        break;
      
      case 'phone':
        if (value && value.trim() !== '') {
          if (value.length > 20) return 'Phone cannot exceed 20 characters';
          const phoneRegex = /^[\+]?[1-9][\d]{0,15}$/;
          if (!phoneRegex.test(value.replace(/[\s\-\(\)]/g, ''))) return 'Invalid phone number format';
        }
        break;
      
      case 'address':
        if (value && value.length > 500) return 'Address cannot exceed 500 characters';
        break;
      
      case 'city':
        if (value && value.length > 100) return 'City cannot exceed 100 characters';
        break;
      
      case 'country':
        if (value && value.length > 100) return 'Country cannot exceed 100 characters';
        break;
      
      case 'emergencyContact':
        if (value && value.length > 200) return 'Emergency contact cannot exceed 200 characters';
        break;
      
      case 'emergencyPhone':
        if (value && value.trim() !== '') {
          if (value.length > 20) return 'Emergency phone cannot exceed 20 characters';
          const phoneRegex = /^[\+]?[1-9][\d]{0,15}$/;
          if (!phoneRegex.test(value.replace(/[\s\-\(\)]/g, ''))) return 'Invalid emergency phone number format';
        }
        break;
      
      case 'medicalConditions':
        if (value && value.length > 1000) return 'Medical conditions cannot exceed 1000 characters';
        break;
      
      case 'specialNeeds':
        if (value && value.length > 1000) return 'Special needs cannot exceed 1000 characters';
        break;
      
      case 'caseWorker':
        if (value && value.length > 200) return 'Case worker cannot exceed 200 characters';
        break;
      
      case 'notes':
        if (value && value.length > 2000) return 'Notes cannot exceed 2000 characters';
        break;
    }
    
    return '';
  };

  const handleInputChange = (field: keyof BeneficiaryFormData, value: string) => {
    setFormData(prev => ({
      ...prev,
      [field]: value,
    }));
    
    // Real-time field validation
    const fieldError = validateField(field, value);
    setFieldErrors(prev => ({
      ...prev,
      [field]: fieldError,
    }));
    
    // Clear global errors when user starts typing
    if (error) setError(null);
    if (validationErrors.length > 0) setValidationErrors([]);
  };

  const validateForm = (): boolean => {
    const errors: string[] = [];
    const newFieldErrors: Record<string, string> = {};

    // Validate all fields
    Object.keys(formData).forEach(key => {
      const field = key as keyof BeneficiaryFormData;
      const value = formData[field] || '';
      const fieldError = validateField(field, value);
      
      if (fieldError) {
        errors.push(fieldError);
        newFieldErrors[field] = fieldError;
      }
    });

    setFieldErrors(newFieldErrors);
    setValidationErrors(errors);
    return errors.length === 0;
  };

  const handleSubmit = async () => {
    if (!validateForm()) {
      return;
    }

    setLoading(true);
    setError(null);

    try {
      // Call the Beneficiary domain API directly
      const response = await fetch('/api/beneficiary/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          recordId: beneficiary?.beneficiaryId,
          correlationId: correlationId,
          ...formData,
        }),
      });

      if (response.ok) {
        const result = await response.json();
        
        // Show success and close dialog
        onSuccess(beneficiary?.beneficiaryId || '');
        onClose();
      } else {
        const errorData = await response.json();
        
        if (errorData.validationErrors && errorData.validationErrors.length > 0) {
          setValidationErrors(errorData.validationErrors);
        } else {
          setError(errorData.errorMessage || errorData.message || 'Registration failed');
        }
      }
    } catch (err) {
      console.error('Error retrying beneficiary registration:', err);
      setError('Failed to register beneficiary. Please check your connection and try again.');
    } finally {
      setLoading(false);
    }
  };

  if (!open || !beneficiary || !originalData) {
    return null;
  }

  return (
    <Dialog open={open} onClose={onClose} maxWidth="md" fullWidth>
      <DialogTitle>
        <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
          <RetryIcon color="primary" />
          <Typography variant="h6">
            Retry Payment: {beneficiary.firstName} {beneficiary.lastName}
          </Typography>
        </Box>
      </DialogTitle>
      
      <DialogContent>
        {/* Show original error */}
        {beneficiary.error && (
          <Alert severity="error" sx={{ mb: 3 }}>
            <Typography variant="subtitle2" gutterBottom>
              Original Error:
            </Typography>
            {beneficiary.error}
          </Alert>
        )}

        {/* Show current form errors */}
        {error && (
          <Alert severity="error" sx={{ mb: 2 }}>
            {error}
          </Alert>
        )}

        {/* Show validation errors */}
        {validationErrors.length > 0 && (
          <Alert severity="warning" sx={{ mb: 2 }}>
            <Typography variant="subtitle2" gutterBottom>
              Please fix the following errors:
            </Typography>
            <ul style={{ margin: 0, paddingLeft: '20px' }}>
              {validationErrors.map((error, index) => (
                <li key={index}>{error}</li>
              ))}
            </ul>
          </Alert>
        )}

        <Typography variant="body2" color="text.secondary" sx={{ mb: 2 }}>
          Review and correct the information below, then click "Retry Payment" to submit directly to the payments system.
        </Typography>

        <Grid container spacing={2}>
          {/* Personal Information */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom>
              Personal Information
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="First Name"
              value={formData.firstName}
              onChange={(e) => handleInputChange('firstName', e.target.value)}
              required
              error={!!fieldErrors.firstName}
              helperText={fieldErrors.firstName}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Last Name"
              value={formData.lastName}
              onChange={(e) => handleInputChange('lastName', e.target.value)}
              required
              error={!!fieldErrors.lastName}
              helperText={fieldErrors.lastName}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Date of Birth"
              value={formData.dateOfBirth}
              onChange={(e) => handleInputChange('dateOfBirth', e.target.value)}
              placeholder="YYYY-MM-DD"
              required
              error={!!fieldErrors.dateOfBirth}
              helperText={fieldErrors.dateOfBirth || "Format: YYYY-MM-DD"}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Nationality"
              value={formData.nationality}
              onChange={(e) => handleInputChange('nationality', e.target.value)}
              required
              error={!!fieldErrors.nationality}
              helperText={fieldErrors.nationality}
            />
          </Grid>

          {/* Document Information */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
              Document Information
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              select
              label="Document Type"
              value={formData.documentType}
              onChange={(e) => handleInputChange('documentType', e.target.value)}
              required
              error={!!fieldErrors.documentType}
              helperText={fieldErrors.documentType}
            >
              <MenuItem value="Passport">Passport</MenuItem>
              <MenuItem value="National ID">National ID</MenuItem>
              <MenuItem value="Driver License">Driver License</MenuItem>
              <MenuItem value="Birth Certificate">Birth Certificate</MenuItem>
              <MenuItem value="Other">Other</MenuItem>
            </TextField>
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Document Number"
              value={formData.documentNumber}
              onChange={(e) => handleInputChange('documentNumber', e.target.value)}
              required
              error={!!fieldErrors.documentNumber}
              helperText={fieldErrors.documentNumber}
            />
          </Grid>

          {/* Contact Information */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
              Contact Information
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Email"
              type="email"
              value={formData.email}
              onChange={(e) => handleInputChange('email', e.target.value)}
              error={!!fieldErrors.email}
              helperText={fieldErrors.email}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Phone"
              value={formData.phone}
              onChange={(e) => handleInputChange('phone', e.target.value)}
              error={!!fieldErrors.phone}
              helperText={fieldErrors.phone}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Address"
              value={formData.address}
              onChange={(e) => handleInputChange('address', e.target.value)}
              error={!!fieldErrors.address}
              helperText={fieldErrors.address}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="City"
              value={formData.city}
              onChange={(e) => handleInputChange('city', e.target.value)}
              error={!!fieldErrors.city}
              helperText={fieldErrors.city}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Country"
              value={formData.country}
              onChange={(e) => handleInputChange('country', e.target.value)}
              error={!!fieldErrors.country}
              helperText={fieldErrors.country}
            />
          </Grid>

          {/* Emergency Contact */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
              Emergency Contact
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Emergency Contact"
              value={formData.emergencyContact}
              onChange={(e) => handleInputChange('emergencyContact', e.target.value)}
              error={!!fieldErrors.emergencyContact}
              helperText={fieldErrors.emergencyContact}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Emergency Phone"
              value={formData.emergencyPhone}
              onChange={(e) => handleInputChange('emergencyPhone', e.target.value)}
              error={!!fieldErrors.emergencyPhone}
              helperText={fieldErrors.emergencyPhone}
            />
          </Grid>

          {/* Medical Information */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
              Medical Information
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Medical Conditions"
              multiline
              rows={2}
              value={formData.medicalConditions}
              onChange={(e) => handleInputChange('medicalConditions', e.target.value)}
              error={!!fieldErrors.medicalConditions}
              helperText={fieldErrors.medicalConditions}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Special Needs"
              multiline
              rows={2}
              value={formData.specialNeeds}
              onChange={(e) => handleInputChange('specialNeeds', e.target.value)}
              error={!!fieldErrors.specialNeeds}
              helperText={fieldErrors.specialNeeds}
            />
          </Grid>

          {/* Case Information */}
          <Grid item xs={12}>
            <Typography variant="h6" gutterBottom sx={{ mt: 2 }}>
              Case Information
            </Typography>
            <Divider sx={{ mb: 2 }} />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              select
              label="Case Status"
              value={formData.caseStatus}
              onChange={(e) => handleInputChange('caseStatus', e.target.value)}
              error={!!fieldErrors.caseStatus}
              helperText={fieldErrors.caseStatus}
            >
              <MenuItem value="PENDING">Pending</MenuItem>
              <MenuItem value="ACTIVE">Active</MenuItem>
              <MenuItem value="COMPLETED">Completed</MenuItem>
              <MenuItem value="SUSPENDED">Suspended</MenuItem>
            </TextField>
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              label="Case Worker"
              value={formData.caseWorker}
              onChange={(e) => handleInputChange('caseWorker', e.target.value)}
              error={!!fieldErrors.caseWorker}
              helperText={fieldErrors.caseWorker}
            />
          </Grid>

          <Grid item xs={12}>
            <TextField
              fullWidth
              label="Notes"
              multiline
              rows={3}
              value={formData.notes}
              onChange={(e) => handleInputChange('notes', e.target.value)}
              error={!!fieldErrors.notes}
              helperText={fieldErrors.notes}
            />
          </Grid>
        </Grid>
      </DialogContent>

      <DialogActions sx={{ p: 3 }}>
        <Button
          onClick={onClose}
          startIcon={<CancelIcon />}
          disabled={loading}
        >
          Cancel
        </Button>
        <Button
          onClick={handleSubmit}
          variant="contained"
          startIcon={loading ? <CircularProgress size={20} /> : <SaveIcon />}
          disabled={loading}
        >
          {loading ? 'Registering...' : 'Retry Payment'}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default RetryBeneficiaryForm;