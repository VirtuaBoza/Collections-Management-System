import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import Typography from '@material-ui/core/Typography';
import Badge from '@material-ui/core/Badge';
import NotificationsIcon from '@material-ui/icons/Notifications';
import { withStyles } from '@material-ui/core/styles';
import classNames from 'classnames';

const drawerWidth = 240;

const styles = theme => ({
  toolbar: {
    paddingRight: 24, // keep right padding when drawer closed
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
  },
  appBarShift: {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  menuButton: {
    marginRight: 36,
  },
  menuButtonHidden: {
    display: 'none',
  },
  title: {
    flexGrow: 1,
  },
});

const Header = ({ classes, open, onClickDrawerOpener }) => {
  return (
    <AppBar
      position="absolute"
      className={classNames(classes.appBar, open && classes.appBarShift)}
    >
      <Toolbar disableGutters={!open} className={classes.toolbar}>
        <IconButton
          color="inherit"
          aria-label="Open drawer"
          onClick={onClickDrawerOpener}
          className={classNames(
            classes.menuButton,
            open && classes.menuButtonHidden,
          )}
        >
          <MenuIcon />
        </IconButton>
        <Typography
          variant="title"
          color="inherit"
          noWrap
          className={classes.title}
        >
          Dashboard
        </Typography>
        <IconButton color="inherit">
          <Badge badgeContent={4} color="secondary">
            <NotificationsIcon />
          </Badge>
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};

Header.propTypes = {
  classes: PropTypes.object.isRequired,
  open: PropTypes.bool.isRequired,
  onClickDrawerOpener: PropTypes.func.isRequired,
};

export default withStyles(styles)(Header);
