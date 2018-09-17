import React from 'react';
import { NavLink, withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { compose } from 'recompose';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import DashboardIcon from '@material-ui/icons/Dashboard';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import PeopleIcon from '@material-ui/icons/People';
import BarChartIcon from '@material-ui/icons/BarChart';
import LayersIcon from '@material-ui/icons/Layers';
import AssignmentIcon from '@material-ui/icons/Assignment';
import { withStyles } from '@material-ui/core/styles';

const drawerWidth = 240;

const styles = theme => ({
  toolbarIcon: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'flex-end',
    padding: '0 8px',
    ...theme.mixins.toolbar,
  },
  drawerPaper: {
    position: 'relative',
    whiteSpace: 'nowrap',
    width: drawerWidth,
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerPaperClose: {
    overflowX: 'hidden',
    transition: theme.transitions.create('width', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    width: theme.spacing.unit * 6,
  },
  navIcon: {
    marginLeft: -12,
  },
});

const NavMenu = ({
  classes,
  open,
  onClickDrawerCloser,
  location: { pathname },
}) => {
  return (
    <Drawer
      variant="permanent"
      classes={{
        paper: classNames(
          classes.drawerPaper,
          !open && classes.drawerPaperClose,
        ),
      }}
      open={open}
    >
      <div className={classes.toolbarIcon}>
        <IconButton onClick={onClickDrawerCloser}>
          <ChevronLeftIcon />
        </IconButton>
      </div>
      <Divider />
      <List>
        <ListItem component={NavLink} to="/" selected={'/' === pathname} button>
          <ListItemIcon className={classes.navIcon}>
            <DashboardIcon />
          </ListItemIcon>
          <ListItemText primary="Dashboard" />
        </ListItem>
        <ListItem
          component={NavLink}
          to="/counter"
          selected={'/counter' === pathname}
          button
        >
          <ListItemIcon className={classes.navIcon}>
            <ShoppingCartIcon />
          </ListItemIcon>
          <ListItemText primary="Orders" />
        </ListItem>
        <ListItem
          component={NavLink}
          to="/fetchdata"
          selected={'/fetchdata' === pathname}
          button
        >
          <ListItemIcon className={classes.navIcon}>
            <PeopleIcon />
          </ListItemIcon>
          <ListItemText primary="Customers" />
        </ListItem>
        <ListItem button>
          <ListItemIcon className={classes.navIcon}>
            <BarChartIcon />
          </ListItemIcon>
          <ListItemText primary="Reports" />
        </ListItem>
        <ListItem button>
          <ListItemIcon className={classes.navIcon}>
            <LayersIcon />
          </ListItemIcon>
          <ListItemText primary="Integrations" />
        </ListItem>
      </List>
      <Divider />
      <List>
        {open && <ListSubheader inset>Saved reports</ListSubheader>}
        <ListItem button>
          <ListItemIcon className={classes.navIcon}>
            <AssignmentIcon />
          </ListItemIcon>
          <ListItemText primary="Current month" />
        </ListItem>
        <ListItem button>
          <ListItemIcon className={classes.navIcon}>
            <AssignmentIcon />
          </ListItemIcon>
          <ListItemText primary="Last quarter" />
        </ListItem>
        <ListItem button>
          <ListItemIcon className={classes.navIcon}>
            <AssignmentIcon />
          </ListItemIcon>
          <ListItemText primary="Year-end sale" />
        </ListItem>
      </List>
    </Drawer>
  );
};

NavMenu.propTypes = {
  classes: PropTypes.object.isRequired,
  open: PropTypes.bool.isRequired,
  onClickDrawerCloser: PropTypes.func.isRequired,
};

export default compose(
  withRouter,
  withStyles(styles),
)(NavMenu);
