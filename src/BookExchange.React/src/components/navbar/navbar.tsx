import React, { useState, useEffect } from "react";
import {
  AppBar,
  Button,
  Drawer,
  IconButton,
  MenuItem,
  Toolbar,
  Typography,
  useMediaQuery,
  useTheme,
} from "@material-ui/core";
import { makeStyles, Link } from "@material-ui/core";
import { isClassExpression } from "typescript";
import { Link as RouterLink } from "react-router-dom";
import MenuIcon from "@material-ui/icons/Menu";
import { ModalDialog } from "./components/modal-dialog";

import { useStyles } from "./navbar.styles";

const headersData = [
  {
    label: "Home",
    href: "/",
  },
  {
    label: "Search Books",
    href: "/search",
  },
  {
    label: "Post Book",
    href: "/post-book",
  },
  {
    label: "Add book",
    href: "/add-book",
  },
];

const Navbar = () => {
  const [drawerOpen, setDrawerOpen] = useState(false);
  const [signUpOpen, setSignUpOpen] = useState(false);
  const classes = useStyles();
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("xs"));

  const handleSignUpOpen = () => {
    setSignUpOpen(true);
  };

  const handleSignUpClose = () => {
    setSignUpOpen(false);
  };

  const displayDesktop = () => {
    return (
      <Toolbar className={classes.toolbar}>
        {bookExchangeLogo}
        <div>{getMenuButtons()}</div>
      </Toolbar>
    );
  };

  const displayMobile = () => {
    const handleDrawerOpen = () => {
      setDrawerOpen(true);
    };
    const handleDrawerClose = () => {
      setDrawerOpen(false);
    };

    return (
      <Toolbar>
        <IconButton
          {...{
            edge: "start",
            color: "inherit",
            "aria-label": "menu",
            "aria-haspopup": "true",
            onClick: handleDrawerOpen,
          }}
        >
          <MenuIcon />
        </IconButton>

        <Drawer
          {...{
            anchor: "left",
            open: drawerOpen,
            onClose: handleDrawerClose,
          }}
        >
          <div>{getDrawerChoices()}</div>
        </Drawer>

        <div>{bookExchangeLogo}</div>
      </Toolbar>
    );
  };

  const getDrawerChoices = () => {
    return headersData.map(({ label, href }) => {
      return (
        <Link
          {...{
            component: RouterLink,
            to: href,
            color: "inherit",
            style: { textDecoration: "none" },
            key: label,
          }}
        >
          <MenuItem>{label}</MenuItem>
        </Link>
      );
    });
  };

  const bookExchangeLogo = (
    <Typography variant="h6" component="h1" className={classes.logo}>
      BookExchange
    </Typography>
  );

  const getMenuButtons = () => {
    let buttons = headersData.map(({ label, href }) => {
      return (
        <Button
          {...{
            key: label,
            color: "inherit",
            to: href,
            component: RouterLink,
          }}
        >
          {label}
        </Button>
      );
    });

    let signUpButton = (
      <Button color="inherit" onClick={handleSignUpOpen}>
        {" "}
        Sign Up
      </Button>
    );

    return <>{buttons}</>;
  };

  const getMenuItems = () => {
    return headersData.map(({ label, href }) => {
      return (
        <Button
          {...{
            key: label,
            color: "inherit",
            to: href,
            component: RouterLink,
          }}
        >
          {label}
        </Button>
      );
    });
  };

  return (
    <header>
      <AppBar className={classes.header}>
        {isMobile ? displayMobile() : displayDesktop()}
      </AppBar>
      <ModalDialog open={signUpOpen} handleClose={handleSignUpClose} />
    </header>
  );
};

export { Navbar };
