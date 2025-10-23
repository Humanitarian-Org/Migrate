import React from 'react';
import {
  Box,
  Typography,
  Grid,
  Card,
  CardContent,
  CardActions,
  Button,
} from '@mui/material';
import {
  People as PeopleIcon,
  LocalHospital as MedicalIcon,
  Upload as UploadIcon,
  Assessment as AssessmentIcon,
} from '@mui/icons-material';
import { useNavigate } from 'react-router-dom';

interface QuickActionCard {
  title: string;
  description: string;
  icon: React.ReactElement;
  color: 'primary' | 'secondary' | 'success' | 'warning' | 'error' | 'info';
  action: () => void;
}

const Dashboard: React.FC = () => {
  const navigate = useNavigate();

  const quickActions: QuickActionCard[] = [
    {
      title: 'Bulk Import Beneficiaries',
      description: 'Upload a CSV file to import multiple beneficiaries at once',
      icon: <UploadIcon sx={{ fontSize: 40 }} />,
      color: 'primary',
      action: () => navigate('/beneficiary/bulk-import'),
    },
    {
      title: 'View Beneficiaries',
      description: 'Browse and manage existing beneficiary records',
      icon: <PeopleIcon sx={{ fontSize: 40 }} />,
      color: 'secondary',
      action: () => navigate('/beneficiary/list'),
    },
    {
      title: 'Medical Cases',
      description: 'Access medical case management and records',
      icon: <MedicalIcon sx={{ fontSize: 40 }} />,
      color: 'success',
      action: () => navigate('/medical/cases'),
    },
    {
      title: 'Reports',
      description: 'Generate and view system reports',
      icon: <AssessmentIcon sx={{ fontSize: 40 }} />,
      color: 'info',
      action: () => navigate('/reports'),
    },
  ];

  return (
    <Box sx={{ flexGrow: 1, p: 3 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        IOM Migration Platform Dashboard
      </Typography>
      
      <Typography variant="body1" color="text.secondary" paragraph>
        Welcome to the IOM Migration Platform. Use the quick actions below to get started,
        or navigate using the sidebar menu.
      </Typography>

      <Grid container spacing={3} sx={{ mt: 2 }}>
        {quickActions.map((action, index) => (
          <Grid item xs={12} sm={6} md={3} key={index}>
            <Card
              sx={{
                height: '100%',
                display: 'flex',
                flexDirection: 'column',
                transition: 'transform 0.2s ease-in-out',
                '&:hover': {
                  transform: 'translateY(-4px)',
                  boxShadow: 6,
                },
              }}
            >
              <CardContent sx={{ flexGrow: 1, textAlign: 'center', pt: 3 }}>
                <Box
                  sx={{
                    color: `${action.color}.main`,
                    mb: 2,
                  }}
                >
                  {action.icon}
                </Box>
                <Typography variant="h6" component="h2" gutterBottom>
                  {action.title}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  {action.description}
                </Typography>
              </CardContent>
              <CardActions sx={{ justifyContent: 'center', pb: 2 }}>
                <Button
                  variant="contained"
                  color={action.color}
                  onClick={action.action}
                  sx={{ minWidth: 120 }}
                >
                  Get Started
                </Button>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>

      <Box sx={{ mt: 4 }}>
        <Typography variant="h5" component="h2" gutterBottom>
          Recent Activity
        </Typography>
        <Card>
          <CardContent>
            <Typography variant="body1" color="text.secondary">
              No recent activity to display. Activity will appear here as you use the system.
            </Typography>
          </CardContent>
        </Card>
      </Box>
    </Box>
  );
};

export default Dashboard;