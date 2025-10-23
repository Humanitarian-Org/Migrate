import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  Box,
  Typography,
  Chip,
  Divider,
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Alert,
  AlertTitle,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  IconButton,
} from '@mui/material';
import {
  ExpandMore as ExpandMoreIcon,
  CheckCircle as CheckCircleIcon,
  Cancel as CancelIcon,
  Info as InfoIcon,
  Rule as RuleIcon,
  Close as CloseIcon,
  Email as EmailIcon,
  Phone as PhoneIcon,
  CalendarToday as CalendarIcon,
  Person as PersonIcon,
  Description as DocumentIcon,
  Home as AddressIcon,
  LocalHospital as MedicalIcon,
  Work as CaseIcon,
} from '@mui/icons-material';

interface ValidationRulesDialogProps {
  open: boolean;
  onClose: () => void;
}

const ValidationRulesDialog: React.FC<ValidationRulesDialogProps> = ({ open, onClose }) => {
  const [expandedSection, setExpandedSection] = useState<string | false>('required');

  const handleAccordionChange = (panel: string) => (event: React.SyntheticEvent, isExpanded: boolean) => {
    setExpandedSection(isExpanded ? panel : false);
  };

  const requiredFields = [
    {
      name: 'First Name',
      field: 'firstName',
      maxLength: 40,
      description: 'Beneficiary\'s first name',
      icon: <PersonIcon color="primary" />
    },
    {
      name: 'Last Name',
      field: 'lastName',
      maxLength: 100,
      description: 'Beneficiary\'s last name',
      icon: <PersonIcon color="primary" />
    },
    {
      name: 'Date of Birth',
      field: 'dateOfBirth',
      format: 'YYYY-MM-DD',
      description: 'Must be valid date, not in future, not more than 150 years ago',
      example: '1990-01-15',
      icon: <CalendarIcon color="primary" />
    },
    {
      name: 'Nationality',
      field: 'nationality',
      maxLength: 50,
      description: 'Beneficiary\'s nationality',
      icon: <PersonIcon color="primary" />
    },
    {
      name: 'Document Type',
      field: 'documentType',
      maxLength: 50,
      validValues: ['Passport', 'National ID', 'Driver License', 'Birth Certificate', 'Other'],
      description: 'Type of identification document',
      icon: <DocumentIcon color="primary" />
    },
    {
      name: 'Document Number',
      field: 'documentNumber',
      minLength: 3,
      maxLength: 50,
      description: 'Must be unique per document type',
      icon: <DocumentIcon color="primary" />
    },
    {
      name: 'Case Status',
      field: 'caseStatus',
      validValues: ['PENDING', 'ACTIVE', 'COMPLETED', 'SUSPENDED'],
      defaultValue: 'PENDING',
      description: 'Current status of the case',
      icon: <CaseIcon color="primary" />
    }
  ];

  const optionalFields = [
    {
      category: 'Contact Information',
      icon: <EmailIcon color="secondary" />,
      fields: [
        {
          name: 'Email',
          field: 'email',
          maxLength: 200,
          format: 'Valid email format',
          example: 'user@example.com',
          validation: 'Must match email regex pattern'
        },
        {
          name: 'Phone',
          field: 'phone',
          maxLength: 20,
          format: 'Valid phone format',
          example: '+1234567890',
          validation: 'Include country code when possible'
        }
      ]
    },
    {
      category: 'Address Information',
      icon: <AddressIcon color="secondary" />,
      fields: [
        {
          name: 'Address',
          field: 'address',
          maxLength: 500,
          description: 'Full street address'
        },
        {
          name: 'City',
          field: 'city',
          maxLength: 100,
          description: 'City of residence'
        },
        {
          name: 'Country',
          field: 'country',
          maxLength: 100,
          description: 'Country of residence'
        }
      ]
    },
    {
      category: 'Emergency Contact',
      icon: <PhoneIcon color="secondary" />,
      fields: [
        {
          name: 'Emergency Contact',
          field: 'emergencyContact',
          maxLength: 200,
          description: 'Name of emergency contact person'
        },
        {
          name: 'Emergency Phone',
          field: 'emergencyPhone',
          maxLength: 20,
          format: 'Valid phone format',
          example: '+1234567891',
          validation: 'Include country code when possible'
        }
      ]
    },
    {
      category: 'Medical Information',
      icon: <MedicalIcon color="secondary" />,
      fields: [
        {
          name: 'Medical Conditions',
          field: 'medicalConditions',
          maxLength: 1000,
          description: 'Any existing medical conditions'
        },
        {
          name: 'Special Needs',
          field: 'specialNeeds',
          maxLength: 1000,
          description: 'Any special accommodation needs'
        }
      ]
    },
    {
      category: 'Case Management',
      icon: <CaseIcon color="secondary" />,
      fields: [
        {
          name: 'Case Worker',
          field: 'caseWorker',
          maxLength: 200,
          description: 'Assigned case worker (must be active)',
          validation: 'Must exist in system when provided'
        },
        {
          name: 'Notes',
          field: 'notes',
          maxLength: 2000,
          description: 'Additional notes about the beneficiary'
        }
      ]
    }
  ];

  const formatRules = [
    {
      type: 'Date Format',
      rule: 'YYYY-MM-DD',
      example: '1990-01-15',
      description: 'ISO 8601 date format'
    },
    {
      type: 'Email Format',
      rule: 'user@domain.com',
      example: 'john.doe@email.com',
      description: 'Standard email format with @ and domain'
    },
    {
      type: 'Phone Format',
      rule: '+[country code][number]',
      example: '+1234567890',
      description: 'Include country code for international compatibility'
    }
  ];

  const businessRules = [
    {
      rule: 'Document Uniqueness',
      description: 'Each document number must be unique per document type',
      impact: 'Prevents duplicate registrations'
    },
    {
      rule: 'Date Validation',
      description: 'Date of birth cannot be in the future or more than 150 years ago',
      impact: 'Ensures realistic birth dates'
    },
    {
      rule: 'Nationality Validation',
      description: 'Nationality must exist in supported countries list',
      impact: 'Ensures data consistency with system capabilities'
    },
    {
      rule: 'Case Worker Validation',
      description: 'Case worker must be active in the system when specified',
      impact: 'Ensures assigned case workers are available'
    }
  ];

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
          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <RuleIcon color="primary" />
            <Typography variant="h6" component="div">
              Beneficiary Validation Rules
            </Typography>
          </Box>
          <IconButton onClick={onClose} size="small">
            <CloseIcon />
          </IconButton>
        </Box>
      </DialogTitle>

      <DialogContent dividers sx={{ p: 0 }}>
        <Box sx={{ p: 3 }}>
          <Alert severity="info" sx={{ mb: 3 }}>
            <AlertTitle>How to Use These Rules</AlertTitle>
            These validation rules ensure data quality and consistency. Required fields must be provided,
            while optional fields are validated only when data is present. Follow the format guidelines
            to avoid validation errors during upload.
          </Alert>

          {/* Required Fields Section */}
          <Accordion 
            expanded={expandedSection === 'required'} 
            onChange={handleAccordionChange('required')}
            sx={{ mb: 2 }}
          >
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              sx={{ backgroundColor: 'error.light', color: 'error.contrastText' }}
            >
              <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                <CheckCircleIcon color="error" />
                <Typography variant="h6">Required Fields (7)</Typography>
                <Chip label="Must be provided" color="error" variant="filled" size="small" />
              </Box>
            </AccordionSummary>
            <AccordionDetails>
              <TableContainer component={Paper} variant="outlined">
                <Table size="small">
                  <TableHead>
                    <TableRow>
                      <TableCell><strong>Field</strong></TableCell>
                      <TableCell><strong>Requirements</strong></TableCell>
                      <TableCell><strong>Format/Values</strong></TableCell>
                      <TableCell><strong>Description</strong></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {requiredFields.map((field) => (
                      <TableRow key={field.field}>
                        <TableCell>
                          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                            {field.icon}
                            <Box>
                              <Typography variant="body2" fontWeight="bold">
                                {field.name}
                              </Typography>
                              <Typography variant="caption" color="text.secondary">
                                ({field.field})
                              </Typography>
                            </Box>
                          </Box>
                        </TableCell>
                        <TableCell>
                          <Box>
                            <Chip label="Required" color="error" size="small" sx={{ mb: 0.5 }} />
                            {field.maxLength && (
                              <Typography variant="caption" display="block">
                                Max: {field.maxLength} chars
                              </Typography>
                            )}
                            {field.minLength && (
                              <Typography variant="caption" display="block">
                                Min: {field.minLength} chars
                              </Typography>
                            )}
                          </Box>
                        </TableCell>
                        <TableCell>
                          {field.validValues ? (
                            <Box>
                              {field.validValues.map((value) => (
                                <Chip key={value} label={value} size="small" sx={{ mr: 0.5, mb: 0.5 }} />
                              ))}
                            </Box>
                          ) : field.format ? (
                            <Box>
                              <Typography variant="body2" fontWeight="bold">
                                {field.format}
                              </Typography>
                              {field.example && (
                                <Typography variant="caption" color="text.secondary">
                                  e.g., {field.example}
                                </Typography>
                              )}
                            </Box>
                          ) : (
                            <Typography variant="body2">Text</Typography>
                          )}
                          {field.defaultValue && (
                            <Typography variant="caption" display="block" color="primary.main">
                              Default: {field.defaultValue}
                            </Typography>
                          )}
                        </TableCell>
                        <TableCell>
                          <Typography variant="body2">
                            {field.description}
                          </Typography>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </AccordionDetails>
          </Accordion>

          {/* Optional Fields Section */}
          <Accordion 
            expanded={expandedSection === 'optional'} 
            onChange={handleAccordionChange('optional')}
            sx={{ mb: 2 }}
          >
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              sx={{ backgroundColor: 'success.light', color: 'success.contrastText' }}
            >
              <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                <InfoIcon color="success" />
                <Typography variant="h6">Optional Fields (11)</Typography>
                <Chip label="Validated when provided" color="success" variant="filled" size="small" />
              </Box>
            </AccordionSummary>
            <AccordionDetails>
              {optionalFields.map((category) => (
                <Box key={category.category} sx={{ mb: 3 }}>
                  <Typography variant="subtitle1" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                    {category.icon}
                    {category.category}
                  </Typography>
                  <TableContainer component={Paper} variant="outlined" sx={{ mb: 2 }}>
                    <Table size="small">
                      <TableHead>
                        <TableRow>
                          <TableCell><strong>Field</strong></TableCell>
                          <TableCell><strong>Constraints</strong></TableCell>
                          <TableCell><strong>Format/Example</strong></TableCell>
                          <TableCell><strong>Notes</strong></TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        {category.fields.map((field) => (
                          <TableRow key={field.field}>
                            <TableCell>
                              <Typography variant="body2" fontWeight="bold">
                                {field.name}
                              </Typography>
                              <Typography variant="caption" color="text.secondary">
                                ({field.field})
                              </Typography>
                            </TableCell>
                            <TableCell>
                              <Box>
                                <Chip label="Optional" color="success" size="small" sx={{ mb: 0.5 }} />
                                {field.maxLength && (
                                  <Typography variant="caption" display="block">
                                    Max: {field.maxLength} chars
                                  </Typography>
                                )}
                              </Box>
                            </TableCell>
                            <TableCell>
                              {field.format && (
                                <Typography variant="body2" fontWeight="bold">
                                  {field.format}
                                </Typography>
                              )}
                              {field.example && (
                                <Typography variant="caption" display="block" color="text.secondary">
                                  e.g., {field.example}
                                </Typography>
                              )}
                            </TableCell>
                            <TableCell>
                              <Typography variant="body2">
                                {field.description || field.validation}
                              </Typography>
                            </TableCell>
                          </TableRow>
                        ))}
                      </TableBody>
                    </Table>
                  </TableContainer>
                </Box>
              ))}
            </AccordionDetails>
          </Accordion>

          {/* Format Rules Section */}
          <Accordion 
            expanded={expandedSection === 'formats'} 
            onChange={handleAccordionChange('formats')}
            sx={{ mb: 2 }}
          >
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              sx={{ backgroundColor: 'warning.light', color: 'warning.contrastText' }}
            >
              <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                <CalendarIcon color="warning" />
                <Typography variant="h6">Format Requirements</Typography>
                <Chip label="Data format rules" color="warning" variant="filled" size="small" />
              </Box>
            </AccordionSummary>
            <AccordionDetails>
              <TableContainer component={Paper} variant="outlined">
                <Table size="small">
                  <TableHead>
                    <TableRow>
                      <TableCell><strong>Data Type</strong></TableCell>
                      <TableCell><strong>Required Format</strong></TableCell>
                      <TableCell><strong>Example</strong></TableCell>
                      <TableCell><strong>Description</strong></TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {formatRules.map((format, index) => (
                      <TableRow key={index}>
                        <TableCell>
                          <Typography variant="body2" fontWeight="bold">
                            {format.type}
                          </Typography>
                        </TableCell>
                        <TableCell>
                          <Typography variant="body2" fontFamily="monospace" sx={{ backgroundColor: 'grey.100', p: 0.5, borderRadius: 1 }}>
                            {format.rule}
                          </Typography>
                        </TableCell>
                        <TableCell>
                          <Typography variant="body2" color="success.main">
                            {format.example}
                          </Typography>
                        </TableCell>
                        <TableCell>
                          <Typography variant="body2">
                            {format.description}
                          </Typography>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </AccordionDetails>
          </Accordion>

          {/* Business Rules Section */}
          <Accordion 
            expanded={expandedSection === 'business'} 
            onChange={handleAccordionChange('business')}
            sx={{ mb: 2 }}
          >
            <AccordionSummary
              expandIcon={<ExpandMoreIcon />}
              sx={{ backgroundColor: 'info.light', color: 'info.contrastText' }}
            >
              <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
                <RuleIcon color="info" />
                <Typography variant="h6">Business Rules</Typography>
                <Chip label="Data integrity rules" color="info" variant="filled" size="small" />
              </Box>
            </AccordionSummary>
            <AccordionDetails>
              <List>
                {businessRules.map((rule, index) => (
                  <React.Fragment key={index}>
                    <ListItem>
                      <ListItemIcon>
                        <CheckCircleIcon color="primary" />
                      </ListItemIcon>
                      <ListItemText
                        primary={
                          <Typography variant="subtitle2" fontWeight="bold">
                            {rule.rule}
                          </Typography>
                        }
                        secondary={
                          <Box>
                            <Typography variant="body2" sx={{ mb: 0.5 }}>
                              {rule.description}
                            </Typography>
                            <Typography variant="caption" color="text.secondary">
                              <strong>Impact:</strong> {rule.impact}
                            </Typography>
                          </Box>
                        }
                      />
                    </ListItem>
                    {index < businessRules.length - 1 && <Divider />}
                  </React.Fragment>
                ))}
              </List>
            </AccordionDetails>
          </Accordion>

          {/* Quick Reference */}
          <Paper sx={{ p: 2, backgroundColor: 'grey.50' }}>
            <Typography variant="h6" gutterBottom sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
              <InfoIcon color="primary" />
              Quick Reference
            </Typography>
            <Box sx={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))', gap: 2 }}>
              <Box>
                <Typography variant="subtitle2" color="error.main" gutterBottom>
                  ❌ Common Mistakes
                </Typography>
                <Typography variant="body2" component="ul" sx={{ m: 0, pl: 2 }}>
                  <li>Wrong date format (use YYYY-MM-DD)</li>
                  <li>Document numbers less than 3 characters</li>
                  <li>Invalid email format</li>
                  <li>Missing required fields</li>
                </Typography>
              </Box>
              <Box>
                <Typography variant="subtitle2" color="success.main" gutterBottom>
                  ✅ Best Practices
                </Typography>
                <Typography variant="body2" component="ul" sx={{ m: 0, pl: 2 }}>
                  <li>Include country codes in phone numbers</li>
                  <li>Use standard date format consistently</li>
                  <li>Verify case worker names exist</li>
                  <li>Keep document numbers unique</li>
                </Typography>
              </Box>
            </Box>
          </Paper>
        </Box>
      </DialogContent>

      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} variant="contained" color="primary">
          Got It
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ValidationRulesDialog;