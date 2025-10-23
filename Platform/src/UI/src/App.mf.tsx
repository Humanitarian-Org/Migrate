import React from 'react';
import { Routes, Route } from 'react-router-dom';
import { Box, Container } from '@mui/material';
import Header from './components/layout/Header';
import Sidebar from './components/layout/Sidebar';
import Dashboard from './pages/Dashboard';
import BeneficiaryBulkImport from './pages/BeneficiaryBulkImport';
import MicroFrontendLoader from './components/MicroFrontendLoader';
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
            <Route path="/beneficiary/bulk-import" element={<BeneficiaryBulkImport />} />
            
            {/* Dynamic route for beneficiary micro-frontend */}
            <Route 
              path="/beneficiary/bulk-import/details/:correlationId" 
              element={
                <MicroFrontendLoader
                  scope="beneficiaryUI"
                  module="./BulkImportDetails"
                  fallback={<div>Loading beneficiary details...</div>}
                />
              } 
            />
            
            {/* More dynamic routes for other beneficiary pages */}
            <Route 
              path="/beneficiary/*" 
              element={
                <MicroFrontendLoader
                  scope="beneficiaryUI"
                  module="./BeneficiaryRoutes"
                  fallback={<div>Loading beneficiary module...</div>}
                />
              } 
            />
            
            {/* Future: Medical domain routes */}
            <Route 
              path="/medical/*" 
              element={
                <MicroFrontendLoader
                  scope="medicalUI"
                  module="./MedicalRoutes"
                  fallback={<div>Loading medical module...</div>}
                />
              } 
            />
            
            <Route path="*" element={<NotFound />} />
          </Routes>
        </Container>
      </Box>
    </Box>
  );
}

export default App;