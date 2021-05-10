import { Button, TextField } from "@material-ui/core";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { useStyles } from "./sign-in-form.styles";
import { Account } from "../../types";
import { AccountService } from "../../services";

const schema = yup.object().shape({
  username: yup.string().required("Username is required"),
  password: yup.string().required("Password is required"),
});

const SignInForm = ({ handleClose }: any) => {
  const classes = useStyles();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Account.SignInData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Account.SignInData) => {
    console.log(data);
    const token = await AccountService.SignIn(data);
    console.log("Token: ", token);
  };

  return (
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
  );
};

export { SignInForm };
