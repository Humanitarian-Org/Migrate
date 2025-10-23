import React from 'react';
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Box,
  Avatar,
  Menu,
  MenuItem,
} from '@mui/material';
import {
  Menu as MenuIcon,
  AccountCircle,
  Notifications,
  Language,
} from '@mui/icons-material';

interface HeaderProps {
  onMenuClick?: () => void;
}

const Header: React.FC<HeaderProps> = ({ onMenuClick }) => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <AppBar
      position="fixed"
      sx={{
        width: { sm: `calc(100% - 240px)` },
        ml: { sm: '240px' },
        zIndex: (theme) => theme.zIndex.drawer + 1,
        backgroundColor: '#003366',
        borderBottom: '3px solid #66B2FF',
      }}
    >
      <Toolbar>
        <IconButton
          color="inherit"
          aria-label="open drawer"
          edge="start"
          onClick={onMenuClick}
          sx={{ 
            mr: 2, 
            display: { sm: 'none' },
            color: 'white',
            '&:hover': {
              backgroundColor: 'rgba(102, 178, 255, 0.1)',
            },
          }}
        >
          <MenuIcon />
        </IconButton>
        
        <Box sx={{ display: 'flex', alignItems: 'center', flexGrow: 1 }}>
          <Box
            component="img"
            src="/iom-logo.svg"
            alt="IOM Logo"
            sx={{
              height: 40,
              width: 80,
              marginRight: 2,
            }}
          />
          <Box>
            <Typography
              variant="h6"
              component="div"
              sx={{
                fontWeight: 600,
                fontSize: '1.25rem',
                color: 'white',
                lineHeight: 1.2,
              }}
            >
              IOM Migration Platform
            </Typography>
            <Typography
              variant="caption"
              sx={{
                color: '#66B2FF',
                fontSize: '0.75rem',
                display: 'block',
                lineHeight: 1,
              }}
            >
              International Organization for Migration
            </Typography>
          </Box>
        </Box>

        <Box sx={{ display: 'flex', alignItems: 'center' }}>
          <IconButton
            size="large"
            aria-label="language"
            color="inherit"
            sx={{
              color: 'white',
              '&:hover': {
                backgroundColor: 'rgba(102, 178, 255, 0.1)',
              },
            }}
          >
            <Language />
          </IconButton>

          <IconButton
            size="large"
            aria-label="notifications"
            color="inherit"
            sx={{
              color: 'white',
              '&:hover': {
                backgroundColor: 'rgba(102, 178, 255, 0.1)',
              },
            }}
          >
            <Notifications />
          </IconButton>
          
          <IconButton
            size="large"
            aria-label="account of current user"
            aria-controls="menu-appbar"
            aria-haspopup="true"
            onClick={handleClick}
            color="inherit"
            sx={{
              color: 'white',
              '&:hover': {
                backgroundColor: 'rgba(102, 178, 255, 0.1)',
              },
            }}
          >
            <AccountCircle />
          </IconButton>
          
          <Menu
            id="menu-appbar"
            anchorEl={anchorEl}
            open={open}
            onClose={handleClose}
            MenuListProps={{
              'aria-labelledby': 'basic-button',
            }}
          >
            <MenuItem onClick={handleClose}>Profile</MenuItem>
            <MenuItem onClick={handleClose}>Settings</MenuItem>
            <MenuItem onClick={handleClose}>Logout</MenuItem>
          </Menu>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;