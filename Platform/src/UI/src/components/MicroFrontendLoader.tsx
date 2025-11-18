import React, { Suspense, lazy, ComponentType } from 'react';
import { Box, CircularProgress, Alert } from '@mui/material';

// Type definitions for remote modules
interface RemoteModule {
  default: ComponentType<any>;
}

interface MicroFrontendLoaderProps {
  scope: string;
  module: string;
  fallback?: React.ReactNode;
  errorFallback?: React.ReactNode;
  props?: Record<string, any>;
}

// Dynamic import function for Module Federation
const loadRemoteModule = (scope: string, module: string): Promise<ComponentType<any>> => {
  return new Promise((resolve, reject) => {
    const remoteUrl = getRemoteUrl(scope);
    
    // Check if the remote is already loaded
    if (typeof window[scope as keyof Window] !== 'undefined') {
      loadModule(scope, module).then(resolve).catch(reject);
      return;
    }

    // Load the remote entry script
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.async = true;
    script.src = remoteUrl;
    
    script.onload = () => {
      loadModule(scope, module).then(resolve).catch(reject);
    };
    
    script.onerror = () => {
      reject(new Error(`Failed to load remote module: ${scope}/${module}`));
    };
    
    document.head.appendChild(script);
  });
};

// Get remote URL based on environment
const getRemoteUrl = (scope: string): string => {
  const remoteUrls: Record<string, string> = {
    beneficiaryUI: process.env.NODE_ENV === 'production' 
      ? 'https://beneficiary-ui.humanitarian.org/remoteEntry.js'
      : 'http://localhost:3001/remoteEntry.js',
    medicalUI: process.env.NODE_ENV === 'production'
      ? 'https://medical-ui.humanitarian.org/remoteEntry.js' 
      : 'http://localhost:3002/remoteEntry.js',
  };
  
  return remoteUrls[scope] || '';
};

// Load module from remote
const loadModule = async (scope: string, module: string): Promise<ComponentType<any>> => {
  try {
    // Initialize the shared scope with known provided modules
    await (window as any)[scope].init(__webpack_share_scopes__.default);
    
    // Get the module factory
    const factory = await (window as any)[scope].get(module);
    
    // Execute the factory to get the module
    const Module: RemoteModule = factory();
    
    return Module.default;
  } catch (error) {
    throw new Error(`Failed to load module ${module} from ${scope}: ${error}`);
  }
};

// Create lazy component with error boundary
const createLazyComponent = (scope: string, module: string) => {
  return lazy(() => 
    loadRemoteModule(scope, module)
      .then((component) => ({ default: component }))
      .catch((error) => {
        console.error(`Error loading ${scope}/${module}:`, error);
        // Return error component
        return { 
          default: () => (
            <Alert severity="error">
              Failed to load component: {scope}/{module}
              <br />
              Error: {error.message}
            </Alert>
          )
        };
      })
  );
};

// Main MicroFrontend Loader Component
const MicroFrontendLoader: React.FC<MicroFrontendLoaderProps> = ({
  scope,
  module,
  fallback,
  errorFallback,
  props = {},
}) => {
  const LazyComponent = React.useMemo(
    () => createLazyComponent(scope, module),
    [scope, module]
  );

  const defaultFallback = (
    <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', p: 4 }}>
      <CircularProgress />
      <Box sx={{ ml: 2 }}>Loading {scope}/{module}...</Box>
    </Box>
  );

  return (
    <Suspense fallback={fallback || defaultFallback}>
      <LazyComponent {...props} />
    </Suspense>
  );
};

// Hook for loading remote components
export const useRemoteComponent = (scope: string, module: string) => {
  const [Component, setComponent] = React.useState<ComponentType<any> | null>(null);
  const [loading, setLoading] = React.useState(true);
  const [error, setError] = React.useState<string | null>(null);

  React.useEffect(() => {
    setLoading(true);
    setError(null);
    
    loadRemoteModule(scope, module)
      .then((component) => {
        setComponent(() => component);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message);
        setLoading(false);
      });
  }, [scope, module]);

  return { Component, loading, error };
};

export default MicroFrontendLoader;