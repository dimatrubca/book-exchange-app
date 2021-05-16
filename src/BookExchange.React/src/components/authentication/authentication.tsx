import React, { ReactNode } from "react";
import { Avatar, Container, Paper, Typography } from "@material-ui/core";
import LockIcon from "@material-ui/icons/Lock";

import { useStyles } from "./authentication.styles";

interface AuthenticationProps {
  isSignIn: boolean;
  children: ReactNode;
}

const Authentication = (props: AuthenticationProps) => {
  const classes = useStyles();

  return (
    <Container component="main" maxWidth="xs">
      <Paper className={classes.mainSection}>
        <Avatar className={classes.avatar}>
          <LockIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          {props.isSignIn ? "Sign In" : "Sign Up"}
        </Typography>
        {props.children}
      </Paper>
    </Container>
  );
};

export { Authentication };
