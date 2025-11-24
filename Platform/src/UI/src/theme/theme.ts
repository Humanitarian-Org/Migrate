import { createTheme } from '@mui/material/styles';

// AcmeCorp Official Brand Colors
const theme = createTheme({
  palette: {
    primary: {
      main: '#0072CE', // AcmeCorp Blue
      light: '#4A9FDB',
      dark: '#005BA3',
      contrastText: '#ffffff',
    },
    secondary: {
      main: '#FF6B35', // AcmeCorp Orange
      light: '#FF8A60',
      dark: '#E55A2B',
      contrastText: '#ffffff',
    },
    background: {
      default: '#f8f9fa', // Very light gray
      paper: '#ffffff',
    },
    text: {
      primary: '#0072CE', // Dark blue for primary text
      secondary: '#666666',
    },
    info: {
      main: '#17a2b8',
      light: '#5bc0de',
      dark: '#117a8b',
    },
    success: {
      main: '#28a745',
      light: '#5cb85c',
      dark: '#1e7e34',
    },
    warning: {
      main: '#ffc107',
      light: '#ffce3a',
      dark: '#e0a800',
    },
    error: {
      main: '#dc3545',
      light: '#f5c6cb',
      dark: '#bd2130',
    },
  },
  typography: {
    fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif',
    h1: {
      fontSize: '2.5rem',
      fontWeight: 600,
      color: '#0072CE',
      letterSpacing: '-0.01562em',
    },
    h2: {
      fontSize: '2rem',
      fontWeight: 600,
      color: '#0072CE',
      letterSpacing: '-0.00833em',
    },
    h3: {
      fontSize: '1.75rem',
      fontWeight: 500,
      color: '#0072CE',
      letterSpacing: '0em',
    },
    h4: {
      fontSize: '1.5rem',
      fontWeight: 500,
      color: '#0072CE',
      letterSpacing: '0.00735em',
    },
    h5: {
      fontSize: '1.25rem',
      fontWeight: 500,
      color: '#0072CE',
      letterSpacing: '0em',
    },
    h6: {
      fontSize: '1rem',
      fontWeight: 600,
      color: '#0072CE',
      letterSpacing: '0.0075em',
    },
    body1: {
      fontSize: '1rem',
      fontWeight: 400,
      lineHeight: 1.6,
      color: '#333333',
    },
    body2: {
      fontSize: '0.875rem',
      fontWeight: 400,
      lineHeight: 1.5,
      color: '#666666',
    },
    button: {
      fontSize: '0.875rem',
      fontWeight: 500,
      textTransform: 'none', // Remove uppercase transformation
      letterSpacing: '0.02857em',
    },
  },
  shape: {
    borderRadius: 8,
  },
  spacing: 8,
  components: {
    MuiButton: {
      styleOverrides: {
        root: {
          borderRadius: 8,
          textTransform: 'none',
          fontWeight: 500,
          paddingTop: 12,
          paddingBottom: 12,
          paddingLeft: 24,
          paddingRight: 24,
        },
        contained: {
          boxShadow: '0 2px 8px rgba(0, 114, 206, 0.15)',
          '&:hover': {
            boxShadow: '0 4px 12px rgba(0, 114, 206, 0.25)',
          },
        },
      },
    },
    MuiCard: {
      styleOverrides: {
        root: {
          borderRadius: 12,
          boxShadow: '0 2px 12px rgba(0, 114, 206, 0.08)',
          '&:hover': {
            boxShadow: '0 4px 20px rgba(0, 114, 206, 0.12)',
          },
        },
      },
    },
    MuiAppBar: {
      styleOverrides: {
        root: {
          backgroundColor: '#0072CE',
          color: '#ffffff',
          boxShadow: '0 2px 8px rgba(0, 114, 206, 0.15)',
        },
      },
    },
    MuiDrawer: {
      styleOverrides: {
        paper: {
          backgroundColor: '#f8f9fa',
          borderRight: '1px solid rgba(0, 114, 206, 0.12)',
        },
      },
    },
    MuiListItemButton: {
      styleOverrides: {
        root: {
          borderRadius: 8,
          margin: '4px 8px',
          '&.Mui-selected': {
            backgroundColor: '#0072CE',
            color: '#ffffff',
            '&:hover': {
              backgroundColor: '#4A9FDB',
            },
            '& .MuiListItemIcon-root': {
              color: '#ffffff',
            },
          },
          '&:hover': {
            backgroundColor: 'rgba(0, 114, 206, 0.04)',
          },
        },
      },
    },
    MuiChip: {
      styleOverrides: {
        root: {
          borderRadius: 6,
        },
      },
    },
  },
});

export default theme;