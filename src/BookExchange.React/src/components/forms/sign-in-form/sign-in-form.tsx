import React, { useContext } from "react";
import {
  Button,
  FormControlLabel,
  Grid,
  Link,
  Paper,
  TextField,
} from "@material-ui/core";
import LockIcon from "@material-ui/icons/Lock";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { useStyles } from "./sign-in-form.styles";
import { Account } from "../../../types";
import { AccountService, UserService } from "../../../services";
import { AuthContext } from "../../../context";
import { useHistory } from "react-router";
import { useSnackbar } from "notistack";

const schema = yup.object().shape({
  username: yup.string().required("Username is required"),
  password: yup.string().required("No password provided"),
});

const SignInForm = () => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);
  const history = useHistory();
  const { enqueueSnackbar } = useSnackbar();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Account.SignInData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Account.SignInData) => {
    try {
      const { access_token, expires_in } = await AccountService.RequestToken(
        data.username,
        data.password
      );

      const expirationTime = new Date(
        new Date().getTime() + Number(expires_in) * 1000
      );
      console.log(`Expiration time: `, expirationTime);

      authContext.login(access_token, expirationTime);

      await authContext.fetchCurrentUser();
      history.push("/profile");
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
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
      </Grid>
      <Button
        type="submit"
        fullWidth
        variant="contained"
        color="primary"
        className={classes.submit}
      >
        Sign In
      </Button>
      <Grid container justify="flex-end">
        <Grid item>
          <Link href="sign-up" variant="body2">
            Don't have an account? Sign up
          </Link>
        </Grid>
      </Grid>
    </form>
  );
};

export { SignInForm };
