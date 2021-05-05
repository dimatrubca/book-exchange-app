import React from "react";
import {
  createStyles,
  makeStyles,
  Theme,
  useTheme,
} from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import Button from "@material-ui/core/Button";
import Menu from "@material-ui/core/Menu";
import useMediaQuery from "@material-ui/core/useMediaQuery";
import { RouteComponentProps, withRouter } from "react-router-dom";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
      marginBottom: 30,
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
    },

    header: {
      paddingLeft: 80,
      paddingRight: 80,
    },

    headerOptions: {
      display: "flex",
    },
  })
);

const Header = (props: RouteComponentProps) => {
  const { history } = props;
  const theme = useTheme();
  const matches = useMediaQuery("(min-width:600px)");
  const classes = useStyles();
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const isMobile = useMediaQuery(theme.breakpoints.down("xs"));

  //console.log(props);
  console.log(matches + " !");
  console.log(isMobile);

  const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleMenuClick = (pageURL: string) => {
    setAnchorEl(null);
    history.push(pageURL);
  };

  const handleButtonClick = (pageUrl: string) => {
    history.push(pageUrl);
  };

  const menuItems = [
    {
      menuTitle: "Home",
      pageURL: "/",
    },
    {
      menuTitle: "Contact",
      pageURL: "/contact",
    },
    {
      menuTitle: "About",
      pageURL: "/about",
    },
  ];

  return (
    <div className={classes.root}>
      <AppBar position="static" className={classes.header}>
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            Photos
          </Typography>
          {isMobile && (
            <div>
              <IconButton
                edge="start"
                className={classes.menuButton}
                color="inherit"
                aria-label="menu"
                onClick={handleMenu}
              >
                <MenuIcon />
              </IconButton>
              <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={open}
                onClose={() => setAnchorEl(null)}
              >
                {menuItems.map((menuItem) => (
                  <MenuItem onClick={() => handleMenuClick(menuItem.pageURL)}>
                    menuItem.menuTitle
                  </MenuItem>
                ))}
                {/* <MenuItem onClick={() => handleMenuClick('/')}>Home</MenuItem>
                        <MenuItem onClick={() => handleMenuClick('/contact')}>Contact Option</MenuItem>
                        <MenuItem onClick={() => handleMenuClick('/about')}>About</MenuItem> */}
              </Menu>
            </div>
          )}
          {!isMobile && (
            <div className={classes.headerOptions}>
              <Button
                variant="contained"
                color="primary"
                onClick={() => handleButtonClick("/")}
              >
                Home
              </Button>
              <Button
                variant="contained"
                color="primary"
                onClick={() => handleButtonClick("/contact")}
              >
                Contact
              </Button>
              <Button
                variant="contained"
                color="primary"
                onClick={() => handleButtonClick("/about")}
              >
                About
              </Button>
            </div>
          )}
        </Toolbar>
      </AppBar>
    </div>
  );
};

export default withRouter(Header);
