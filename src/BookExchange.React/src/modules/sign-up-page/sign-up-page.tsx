import React, { useContext } from "react";
import {
  Avatar,
  Box,
  Button,
  Checkbox,
  Container,
  CssBaseline,
  FormControlLabel,
  Grid,
  Link,
  Paper,
  TextField,
  Typography,
} from "@material-ui/core";
import LockIcon from "@material-ui/icons/Lock";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { useStyles } from "./sign-up-page.styles";
import { Account } from "types";
import { AccountService } from "services";
import { AuthContext } from "context";
import { Authentication } from "components/authentication";
import { SignUpForm } from "components/forms";

const schema = yup.object().shape({
  username: yup
    .string()
    .required("Username is required")
    .min(4, "Username should contain at least 4 characters"),
  email: yup.string().required("Email Address is required"),
  password: yup
    .string()
    .required("No password provided")
    .min(8, "Password should contain at least 8 characters"),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password"), null], "Passwords must match"),
});

const SignUpPage = () => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Account.SignUpData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Account.SignUpData) => {
    console.log(data);

    try {
      const result = await AccountService.SignUp(data);
      console.log(result);

      const resultToken = await AccountService.RequestToken(
        data.username,
        data.password
      );
      const token = resultToken.access_token;
      const expirationTime = new Date(
        new Date().getTime() + Number(resultToken.expires_in) * 1000
      );

      console.log(resultToken);
      console.log(token, expirationTime);

      authContext.login(token, expirationTime);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <Authentication isSignIn={false}>
      <SignUpForm />
    </Authentication>
  );
};

export { SignUpPage };
