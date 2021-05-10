import { Container, useMediaQuery, useTheme } from "@material-ui/core";
import { Link as RouterLink } from "@material-ui/core";
import React from "react";
import { userContext } from "../../context";
import { useStyles } from "./userbar.styles";

const headersData = [
  {
    label: "Sign In",
    href: "/sign-in",
  },
  {
    label: "Sign Up",
    href: "/sign-up",
  },
];

const headersDataLoggedIn = [
  {
    label: "Wishlist",
    href: "/wishlist",
  },
  {
    label: "Post",
    href: "/add-book",
  },
  {
    label: "Sign Out",
    href: "/sign-out",
  },
];

//     key = 'label'
//     color = "inherit"
//     href = {href}
//     component = {RouterLink}

const Userbar = () => {
  const classes = useStyles();
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("xs"));

  const getMenuItems = () => {
    return headersData.map(({ label, href }) => {
      return (
        <RouterLink key={label} href={href} className={classes.linkItem}>
          {label}
        </RouterLink>
      );
    });
  };

  return (
    <>
      <userContext.Consumer>
        {({ user }) => JSON.stringify(user)}
      </userContext.Consumer>
      <Container className={classes.root}>
        {!isMobile && getMenuItems()}
      </Container>
    </>
  );
};

export { Userbar };
