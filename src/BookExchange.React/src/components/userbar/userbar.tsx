import { Container, Typography } from "@material-ui/core";
import { Link as RouterLink } from "@material-ui/core";
import React, { useContext } from "react";
import { AuthContext } from "../../context";
import { useStyles } from "./userbar.styles";

interface NavData {
  label: string;
  href: string;
}

const navData: NavData[] = [
  {
    label: "Sign In",
    href: "/sign-in",
  },
  {
    label: "Sign Up",
    href: "/sign-up",
  },
];

const navDataLoggedIn: NavData[] = [
  {
    label: "Post",
    href: "/add-book",
  },
];

const Userbar = () => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);

  const getNavItems = (data: NavData[]) => {
    return data.map(({ label, href }) => {
      return (
        <RouterLink key={label} href={href} className={classes.linkItem}>
          {label}
        </RouterLink>
      );
    });
  };

  return (
    <>
      <Container className={classes.root}>
        {!authContext.isLoggedIn ? (
          <>{getNavItems(navData)}</>
        ) : (
          <>
            <RouterLink href="/profile">
              {" "}
              Welcome {authContext.user?.username}!
            </RouterLink>

            {getNavItems(navDataLoggedIn)}
            <RouterLink
              href="/"
              className={classes.linkItem}
              onClick={authContext.logout}
            >
              Sign Out
            </RouterLink>
          </>
        )}
      </Container>
    </>
  );
};

export { Userbar };
