import React from "react";
import { Card, CardContent, CardHeader, Paper } from "@material-ui/core";
import { useStyles } from "./sign-in.styles";
import { SignInForm } from "../../components/sign-in-form";

const SignIn = () => {
  const classes = useStyles();

  return (
    // props received from App.js
    // eslint-disable-next-line react/jsx-no-undef
    <main className={classes.layout}>
      <Paper className={classes.paper}>
        <CardHeader title="Log In" />
        <CardContent>
          <SignInForm />
        </CardContent>
      </Paper>
    </main>
  );
};

export { SignIn };
