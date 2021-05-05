import React from "react";
import { Card, CardContent, CardHeader } from "@material-ui/core";
import { useStyles } from "./sign-in.styles";
import { SignInForm } from "../../components/sign-in-form";

const SignIn = () => {
  const classes = useStyles();

  return (
    // props received from App.js
    // eslint-disable-next-line react/jsx-no-undef
    <Card className={classes.signInCard}>
      <CardHeader title="Log In" />
      <CardContent>
        <SignInForm />
      </CardContent>
    </Card>
  );
};

export { SignIn };
