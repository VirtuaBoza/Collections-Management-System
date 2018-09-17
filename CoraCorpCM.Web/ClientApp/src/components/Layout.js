import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import Header from './Header';
import NavMenu from './NavMenu';
import withRoot from '../withRoot';

const styles = theme => ({
  root: {
    display: 'flex',
  },
  appBarSpacer: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    padding: theme.spacing.unit * 3,
    height: '100vh',
    overflow: 'auto',
  },
});

class Layout extends React.Component {
  state = {
    open: false,
  };

  handleDrawerOpen = () => {
    this.setState({ open: true });
  };

  handleDrawerClose = () => {
    this.setState({ open: false });
  };

  render() {
    const { classes } = this.props;

    return (
      <React.Fragment>
        <CssBaseline />
        <div className={classes.root}>
          <Header
            open={this.state.open}
            onClickDrawerOpener={this.handleDrawerOpen}
          />
          <NavMenu
            open={this.state.open}
            onClickDrawerCloser={this.handleDrawerClose}
          />
          <main className={classes.content}>
            <div className={classes.appBarSpacer} />
            {this.props.children}
          </main>
        </div>
      </React.Fragment>
    );
  }
}

Layout.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withRoot(withStyles(styles)(Layout));
