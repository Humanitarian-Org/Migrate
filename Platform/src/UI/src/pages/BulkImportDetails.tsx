import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import {
  Box,
  Typography,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TablePagination,
  Chip,
  Button,
  Alert,
  AlertTitle,
  CircularProgress,
  TextField,
  InputAdornment,
  Grid,
  Card,
  CardContent,
  IconButton,
  Tooltip,
  Snackbar,
} from '@mui/material';
import {
  ArrowBack as ArrowBackIcon,
  Search as SearchIcon,
  FileDownload as DownloadIcon,
  Refresh as RefreshIcon,
  CheckCircle as SuccessIcon,
  Error as ErrorIcon,
  Schedule as PendingIcon,
  Replay as RetryIcon,
} from '@mui/icons-material';
import RetryBeneficiaryForm from '../components/RetryBeneficiaryForm';

interface BeneficiaryProcessingResult {
  beneficiaryId: string;
  firstName: string;
  lastName: string;
  status: string;
  error?: string;
  processedAt: string;
}

interface BulkBeneficiaryProcessingStatus {
  correlationId: string;
  uploadId: string;
  totalRecords: number;
  processedRecords: number;
  successfulRecords: number;
  failedRecords: number;
  results: BeneficiaryProcessingResult[];
  lastUpdated: string;
}

const BulkImportDetails: React.FC = () => {
  const { correlationId } = useParams<{ correlationId: string }>();
  const navigate = useNavigate();
  
  const [loading, setLoading] = useState(true);
  const [refreshing, setRefreshing] = useState(false);
  const [data, setData] = useState<BulkBeneficiaryProcessingStatus | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(25);
  const [searchTerm, setSearchTerm] = useState('');
  const [statusFilter, setStatusFilter] = useState<string>('all');
  const [retryDialogOpen, setRetryDialogOpen] = useState(false);
  const [selectedBeneficiary, setSelectedBeneficiary] = useState<BeneficiaryProcessingResult | null>(null);
  const [originalBeneficiaryData, setOriginalBeneficiaryData] = useState<any>(null);
  const [successMessage, setSuccessMessage] = useState<string>('');
  const [showSuccess, setShowSuccess] = useState(false);

  const fetchProcessingStatus = async (showRefreshLoader = false) => {
    if (showRefreshLoader) setRefreshing(true);
    else setLoading(true);
    
    try {
      const response = await fetch(`/api/payments/bulk-upload/status/${correlationId}`);
      
      if (!response.ok) {
        throw new Error(`Failed to fetch processing status: ${response.status}`);
      }
      
      const result = await response.json();
      setData(result);
      setError(null);
    } catch (err) {
      console.error('Error fetching processing status:', err);
      setError(err instanceof Error ? err.message : 'Unknown error occurred');
    } finally {
      setLoading(false);
      setRefreshing(false);
    }
  };

  useEffect(() => {
    if (correlationId) {
      fetchProcessingStatus();
      
      // Auto-refresh every 10 seconds if processing is not complete
      const interval = setInterval(() => {
        if (data && data.processedRecords < data.totalRecords) {
          fetchProcessingStatus(true);
        }
      }, 10000);
      
      return () => clearInterval(interval);
    }
  }, [correlationId, data?.processedRecords, data?.totalRecords]);

  const getStatusIcon = (status: string) => {
    switch (status.toLowerCase()) {
      case 'success':
        return <SuccessIcon color="success" />;
      case 'failed':
        return <ErrorIcon color="error" />;
      case 'pending':
      default:
        return <PendingIcon color="warning" />;
    }
  };

  const getStatusChip = (status: string) => {
    const statusLower = status.toLowerCase();
    const color = statusLower === 'success' ? 'success' : 
                  statusLower === 'failed' ? 'error' : 'warning';
    
    return (
      <Chip
        icon={getStatusIcon(status)}
        label={status}
        color={color}
        size="small"
      />
    );
  };

  const filteredResults = data?.results?.filter(result => {
    const matchesSearch = !searchTerm || 
      `${result.firstName} ${result.lastName}`.toLowerCase().includes(searchTerm.toLowerCase()) ||
      result.beneficiaryId.toLowerCase().includes(searchTerm.toLowerCase());
    
    const matchesStatus = statusFilter === 'all' || result.status.toLowerCase() === statusFilter;
    
    return matchesSearch && matchesStatus;
  }) || [];

  const paginatedResults = filteredResults.slice(
    page * rowsPerPage,
    page * rowsPerPage + rowsPerPage
  );

  const exportResults = () => {
    if (!data?.results) return;
    
    const csvContent = [
      ['Transaction ID', 'First Name', 'Last Name', 'Status', 'Error', 'Processed At'].join(','),
      ...data.results.map(result => [
        result.beneficiaryId,
        result.firstName,
        result.lastName,
        result.status,
        result.error || '',
        result.processedAt || ''
      ].map(field => `"${field}"`).join(','))
    ].join('\n');
    
    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    const url = URL.createObjectURL(blob);
    link.setAttribute('href', url);
    link.setAttribute('download', `bulk-import-results-${correlationId}.csv`);
    link.style.visibility = 'hidden';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  const handleRetryBeneficiary = async (result: BeneficiaryProcessingResult) => {
    try {
      // In a real implementation, we'd fetch the original record data from the bulk upload
      // For now, we'll create a reasonable default based on what we have
      // TODO: Enhance this to fetch actual original data from the bulk upload record
      const originalData = {
        firstName: result.firstName,
        lastName: result.lastName,
        dateOfBirth: '1990-01-01', // Default placeholder
        nationality: 'Syrian', // Default placeholder  
        documentType: 'Passport', // Default placeholder
        documentNumber: `DOC-${result.beneficiaryId.substring(0, 8)}`, // Generated placeholder
        email: `${result.firstName.toLowerCase()}.${result.lastName.toLowerCase()}@example.com`,
        phone: '+1234567890',
        address: '123 Main Street',
        city: 'Damascus',
        country: 'Syria',
        emergencyContact: 'Emergency Contact',
        emergencyPhone: '+1234567891',
        medicalConditions: 'None',
        specialNeeds: 'None',
        caseStatus: 'PENDING',
        caseWorker: 'Case Worker',
        notes: `Retry of failed record: ${result.beneficiaryId}. Original error: ${result.error}`,
      };

      setSelectedBeneficiary(result);
      setOriginalBeneficiaryData(originalData);
      setRetryDialogOpen(true);
    } catch (error) {
      console.error('Error preparing retry data:', error);
      // Could show an error notification here
    }
  };

  const handleRetrySuccess = (beneficiaryId: string) => {
    // Update the local state to mark this record as successful
    setData(prevData => {
      if (!prevData) return prevData;
      
      const updatedResults = prevData.results.map(result => 
        result.beneficiaryId === beneficiaryId 
          ? { ...result, status: 'Success', error: undefined, processedAt: new Date().toISOString() }
          : result
      );
      
      // Update counts
      const successfulRecords = prevData.successfulRecords + 1;
      const failedRecords = prevData.failedRecords - 1;
      
      return {
        ...prevData,
        results: updatedResults,
        successfulRecords,
        failedRecords
      };
    });
    
    // Show success message
    const beneficiary = data?.results.find(r => r.beneficiaryId === beneficiaryId);
    const name = beneficiary ? `${beneficiary.firstName} ${beneficiary.lastName}` : 'Transaction';
    setSuccessMessage(`${name} has been successfully registered!`);
    setShowSuccess(true);
  };

  if (loading) {
    return (
      <Box sx={{ p: 3, display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: 400 }}>
        <CircularProgress />
        <Typography sx={{ ml: 2 }}>Loading processing details...</Typography>
      </Box>
    );
  }

  if (error || !data) {
    return (
      <Box sx={{ p: 3 }}>
        <Button
          startIcon={<ArrowBackIcon />}
          onClick={() => navigate('/payments/bulk-import')}
          sx={{ mb: 2 }}
        >
          Back to Bulk Import
        </Button>
        
        <Alert severity="error">
          <AlertTitle>Error Loading Processing Details</AlertTitle>
          {error || 'No data found for the specified correlation ID.'}
        </Alert>
      </Box>
    );
  }

  return (
    <Box sx={{ p: 3 }}>
      {/* Header */}
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', mb: 3 }}>
        <Box sx={{ display: 'flex', alignItems: 'center' }}>
          <Button
            startIcon={<ArrowBackIcon />}
            onClick={() => navigate('/payments/bulk-import')}
            sx={{ mr: 2 }}
          >
            Back to Bulk Import
          </Button>
          <Box>
            <Typography variant="h4" component="h1">
              Bulk Import Processing Details
            </Typography>
            <Typography variant="body2" color="text.secondary">
              Correlation ID: {correlationId}
            </Typography>
          </Box>
        </Box>
        
        <Box sx={{ display: 'flex', gap: 1 }}>
          <Tooltip title="Refresh Data">
            <IconButton onClick={() => fetchProcessingStatus(true)} disabled={refreshing}>
              <RefreshIcon />
            </IconButton>
          </Tooltip>
          <Button
            startIcon={<DownloadIcon />}
            onClick={exportResults}
            variant="outlined"
            size="small"
          >
            Export Results
          </Button>
        </Box>
      </Box>

      {/* Summary Cards */}
      <Grid container spacing={3} sx={{ mb: 3 }}>
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent sx={{ textAlign: 'center' }}>
              <Typography variant="h4" color="primary">
                {data.totalRecords}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Total Records
              </Typography>
            </CardContent>
          </Card>
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent sx={{ textAlign: 'center' }}>
              <Typography variant="h4" color="info.main">
                {data.processedRecords}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Processed
              </Typography>
            </CardContent>
          </Card>
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent sx={{ textAlign: 'center' }}>
              <Typography variant="h4" color="success.main">
                {data.successfulRecords}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Successful
              </Typography>
            </CardContent>
          </Card>
        </Grid>
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent sx={{ textAlign: 'center' }}>
              <Typography variant="h4" color="error.main">
                {data.failedRecords}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Failed
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </Grid>

      {/* Processing Status Alert */}
      {data.processedRecords < data.totalRecords && (
        <Alert severity="info" sx={{ mb: 3 }}>
          <AlertTitle>Processing In Progress</AlertTitle>
          {refreshing && <CircularProgress size={16} sx={{ mr: 1 }} />}
          Processing {data.processedRecords} of {data.totalRecords} records. 
          This page will auto-refresh every 10 seconds.
        </Alert>
      )}

      {/* Filters */}
      <Paper sx={{ p: 2, mb: 3 }}>
        <Grid container spacing={2} alignItems="center">
          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              placeholder="Search by name or ID..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              InputProps={{
                startAdornment: (
                  <InputAdornment position="start">
                    <SearchIcon />
                  </InputAdornment>
                ),
              }}
            />
          </Grid>
          <Grid item xs={12} md={3}>
            <TextField
              select
              fullWidth
              label="Status Filter"
              value={statusFilter}
              onChange={(e) => setStatusFilter(e.target.value)}
              SelectProps={{ native: true }}
            >
              <option value="all">All Statuses</option>
              <option value="pending">Pending</option>
              <option value="success">Success</option>
              <option value="failed">Failed</option>
            </TextField>
          </Grid>
          <Grid item xs={12} md={3}>
            <Typography variant="body2" color="text.secondary">
              Showing {filteredResults.length} of {data.results.length} records
            </Typography>
          </Grid>
        </Grid>
      </Paper>

      {/* Results Table */}
      <Paper>
        <TableContainer>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Status</TableCell>
                <TableCell>Name</TableCell>
                <TableCell>Transaction ID</TableCell>
                <TableCell>Error Details</TableCell>
                <TableCell>Processed At</TableCell>
                <TableCell>Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {paginatedResults.map((result, index) => (
                <TableRow key={index}>
                  <TableCell>
                    {getStatusChip(result.status)}
                  </TableCell>
                  <TableCell>
                    {result.firstName} {result.lastName}
                  </TableCell>
                  <TableCell>
                    <Typography variant="body2" sx={{ fontFamily: 'monospace' }}>
                      {result.beneficiaryId}
                    </Typography>
                  </TableCell>
                  <TableCell>
                    {result.error && (
                      <Typography variant="body2" color="error">
                        {result.error}
                      </Typography>
                    )}
                  </TableCell>
                  <TableCell>
                    <Typography variant="body2">
                      {result.processedAt && result.processedAt !== '0001-01-01T00:00:00+00:00' 
                        ? new Date(result.processedAt).toLocaleString()
                        : '-'
                      }
                    </Typography>
                  </TableCell>
                  <TableCell>
                    {result.status.toLowerCase() === 'failed' && (
                      <Button
                        size="small"
                        variant="outlined"
                        color="primary"
                        startIcon={<RetryIcon />}
                        onClick={() => handleRetryBeneficiary(result)}
                      >
                        Retry
                      </Button>
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        
        <TablePagination
          component="div"
          count={filteredResults.length}
          page={page}
          onPageChange={(_, newPage) => setPage(newPage)}
          rowsPerPage={rowsPerPage}
          onRowsPerPageChange={(e) => {
            setRowsPerPage(parseInt(e.target.value, 10));
            setPage(0);
          }}
          rowsPerPageOptions={[10, 25, 50, 100]}
        />
      </Paper>

      {/* Retry Transaction Form Dialog */}
      <RetryBeneficiaryForm
        open={retryDialogOpen}
        onClose={() => setRetryDialogOpen(false)}
        beneficiary={selectedBeneficiary}
        originalData={originalBeneficiaryData}
        correlationId={correlationId || ''}
        onSuccess={handleRetrySuccess}
      />

      {/* Success Notification */}
      <Snackbar
        open={showSuccess}
        autoHideDuration={6000}
        onClose={() => setShowSuccess(false)}
        anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
      >
        <Alert 
          onClose={() => setShowSuccess(false)} 
          severity="success" 
          sx={{ width: '100%' }}
        >
          {successMessage}
        </Alert>
      </Snackbar>
    </Box>
  );
};

export default BulkImportDetails;