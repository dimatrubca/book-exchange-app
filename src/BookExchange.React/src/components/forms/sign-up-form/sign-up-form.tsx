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
import clsx from "clsx";

import { useStyles } from "./sign-up-form.styles";
import { Account } from "types";
import { AccountService } from "services";
import { AuthContext } from "context";

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

const SignUpForm = () => {
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

      const resultToken = await AccountService.RequestToken(data);
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
    <form className={classes.form} onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            {...register("username")}
            autoComplete="uname"
            name="username"
            variant="outlined"
            required
            fullWidth
            id="username"
            label="Username"
            autoFocus
            error={!!errors.username}
            helperText={errors.username?.message}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            {...register("email")}
            variant="outlined"
            required
            fullWidth
            type="email"
            id="email"
            label="Email Address"
            name="email"
            autoComplete="email"
            helperText={errors.email?.message}
            error={!!errors.email}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            {...register("password")}
            variant="outlined"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
            error={!!errors.password}
            helperText={errors.password?.message}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            {...register("confirmPassword")}
            variant="outlined"
            required
            fullWidth
            name="confirmPassword"
            label="Confirm Password"
            type="confirmPassword"
            id="confirmPassword"
            autoComplete="confirm-password"
            error={!!errors.confirmPassword}
            helperText={errors.confirmPassword?.message}
          />
        </Grid>
        <Grid item xs={12}>
          <FormControlLabel
            control={<Checkbox value="allowExtraEmails" color="primary" />}
            label="Subscribe to notifications"
          />
        </Grid>
      </Grid>
      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        className={classes.submit}
      >
        Sign Up
      </Button>
      <Grid container justify="flex-end">
        <Grid item>
          <Link href="#" variant="body2">
            Already have an account? Sign in
          </Link>
        </Grid>
      </Grid>
    </form>
  );
};

export { SignUpForm };
