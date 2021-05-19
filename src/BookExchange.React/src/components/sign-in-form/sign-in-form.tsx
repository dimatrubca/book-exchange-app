import { Button, TextField } from "@material-ui/core";
import React, { useContext, useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { useStyles } from "./sign-in-form.styles";
import { Account } from "../../types";
import { AccountService } from "../../services";
import { AuthContext } from "../../context";

const schema = yup.object().shape({
  username: yup.string().required("Username is required"),
  password: yup.string().required("Password is required"),
});

const SignInForm = ({ handleClose }: any) => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Account.SignInData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Account.SignInData) => {
    console.log(data);

    try {
      console.log("starting");
      const token = await AccountService.SignIn(data);
      console.log(token);
      authContext.login(token.accessToken);
      console.log("Token: ", token, token.accessToken);
      console.log(authContext.login);
      console.log(authContext.isLoggedIn);
      console.log(authContext.token);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextField
          {...register("username")}
          label="Username"
          fullWidth
          helperText={errors.username?.message}
        />
        <br />
        <br />
        <TextField
          {...register("password")}
          label="Password"
          type="password"
          fullWidth
          helperText={errors.password?.message}
        />
        <br />
        <br />
        <div>
          <Button type="submit" variant="contained" color="primary">
            Sign In
          </Button>
        </div>
      </form>
      <Button className={classes.btnGoogleLogin}>Facebook login</Button>
    </>
  );
};

export { SignInForm };
