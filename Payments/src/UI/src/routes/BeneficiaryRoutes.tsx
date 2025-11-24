import React from 'react';
import { Routes, Route } from 'react-router-dom';
import BulkImportDetails from './pages/BulkImportDetails';
import BeneficiaryProfile from './pages/BeneficiaryProfile';
import BeneficiaryList from './pages/BeneficiaryList';

// This component handles all beneficiary routes
const BeneficiaryRoutes: React.FC = () => {
  return (
    <Routes>
      <Route path="/bulk-import/details/:correlationId" element={<BulkImportDetails />} />
      <Route path="/profile/:beneficiaryId" element={<BeneficiaryProfile />} />
      <Route path="/list" element={<BeneficiaryList />} />
      <Route path="/" element={<BeneficiaryList />} />
    </Routes>
  );
};

export default BeneficiaryRoutes;