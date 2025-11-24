import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { Box, Container } from '@mui/material';
import Header from './components/layout/Header';
import Sidebar from './components/layout/Sidebar';
import Dashboard from './pages/Dashboard';
import PaymentsBulkImport from './pages/PaymentsBulkImport';
import BulkImportDetails from './pages/BulkImportDetails';
import NotFound from './pages/NotFound';

function App() {
  return (
    <Box sx={{ display: 'flex', minHeight: '100vh' }}>
      {/* Header */}
      <Header />
      
      {/* Sidebar */}
      <Sidebar />
      
      {/* Main Content */}
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          width: { sm: `calc(100% - 240px)` },
          ml: { sm: '240px' },
          mt: '64px', // Height of the header
        }}
      >
        <Container maxWidth="xl">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/payments/bulk-import" element={<PaymentsBulkImport />} />
            <Route path="/payments/bulk-import/details/:correlationId" element={<BulkImportDetails />} />
            <Route path="*" element={<NotFound />} />
          </Routes>
        </Container>
      </Box>
    </Box>
  );
}

export default App;