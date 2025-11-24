import React from 'react';
import {
  Drawer,
  Box,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Divider,
  Collapse,
  Typography,
} from '@mui/material';
import {
  Dashboard as DashboardIcon,
  People as PeopleIcon,
  LocalHospital as MedicalIcon,
  Settings as SettingsIcon,
  ExpandLess,
  ExpandMore,
  Upload as UploadIcon,
  ViewList as ViewListIcon,
} from '@mui/icons-material';
import { useNavigate, useLocation } from 'react-router-dom';

const drawerWidth = 240;

interface MenuItem {
  text: string;
  icon: React.ReactElement;
  path?: string;
  children?: MenuItem[];
}

const menuItems: MenuItem[] = [
  {
    text: 'Dashboard',
    icon: <DashboardIcon />,
    path: '/',
  },
  {
    text: 'Bank Transactions',
    icon: <PeopleIcon />,
    children: [
      {
        text: 'Bulk Import',
        icon: <UploadIcon />,
        path: '/payments/bulk-import',
      },
      {
        text: 'View All',
        icon: <ViewListIcon />,
        path: '/beneficiary/list',
      },
    ],
  },
  {
    text: 'Medical',
    icon: <MedicalIcon />,
    children: [
      {
        text: 'Cases',
        icon: <ViewListIcon />,
        path: '/medical/cases',
      },
    ],
  },
  {
    text: 'Settings',
    icon: <SettingsIcon />,
    path: '/settings',
  },
];

const Sidebar: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const [expandedItems, setExpandedItems] = React.useState<{ [key: string]: boolean }>({
    Transactions: true, // Expand by default
  });

  const handleItemClick = (item: MenuItem) => {
    if (item.children) {
      setExpandedItems(prev => ({
        ...prev,
        [item.text]: !prev[item.text],
      }));
    } else if (item.path) {
      navigate(item.path);
    }
  };

  const isActiveItem = (path: string) => {
    return location.pathname === path;
  };

  const renderMenuItem = (item: MenuItem, depth = 0) => {
    const hasChildren = item.children && item.children.length > 0;
    const isExpanded = expandedItems[item.text];
    const isActive = item.path ? isActiveItem(item.path) : false;

    return (
      <React.Fragment key={item.text}>
        <ListItem disablePadding>
          <ListItemButton
            onClick={() => handleItemClick(item)}
            selected={isActive}
            sx={{
              pl: 2 + depth * 2,
              '&.Mui-selected': {
                backgroundColor: '#003366',
                color: 'white',
                '&:hover': {
                  backgroundColor: '#004080',
                },
                '& .MuiListItemIcon-root': {
                  color: 'white',
                },
              },
              '&:hover': {
                backgroundColor: 'rgba(102, 178, 255, 0.1)',
              },
            }}
          >
            <ListItemIcon
              sx={{
                color: isActive ? 'white' : '#003366',
              }}
            >
              {item.icon}
            </ListItemIcon>
            <ListItemText primary={item.text} />
            {hasChildren && (isExpanded ? <ExpandLess /> : <ExpandMore />)}
          </ListItemButton>
        </ListItem>
        
        {hasChildren && (
          <Collapse in={isExpanded} timeout="auto" unmountOnExit>
            <List component="div" disablePadding>
              {item.children?.map(child => renderMenuItem(child, depth + 1))}
            </List>
          </Collapse>
        )}
      </React.Fragment>
    );
  };

  return (
    <Drawer
      variant="permanent"
      sx={{
        width: drawerWidth,
        flexShrink: 0,
        '& .MuiDrawer-paper': {
          width: drawerWidth,
          boxSizing: 'border-box',
          top: '64px', // Height of the header
          height: 'calc(100% - 64px)',
          backgroundColor: '#f8f9fa',
          borderRight: '2px solid #66B2FF',
        },
      }}
    >
      <Box sx={{ overflow: 'auto' }}>
        <List>
          {menuItems.map(item => renderMenuItem(item))}
        </List>
      </Box>
    </Drawer>
  );
};

export default Sidebar;