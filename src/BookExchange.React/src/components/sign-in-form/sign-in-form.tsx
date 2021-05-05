import { Button, TextField } from "@material-ui/core";
import React, { useState } from "react";
import { Controller, useForm } from "react-hook-form";

import { useStyles } from "./sign-in-form.styles";

const SignInForm = ({ handleClose }: any) => {
  const { control, handleSubmit } = useForm<any>();

  const classes = useStyles();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = (data: any) => {
    // e.preventDefault();
    console.log(username, password);
  };

  return (
    <form className={classes.root}>
      <Controller
        name="username"
        control={control}
        defaultValue=""
        render={({ field: { onChange, value }, fieldState: { error } }) => (
          <TextField
            label="Username"
            variant="filled"
            value={value}
            onChange={onChange}
            error={!!error}
            helperText={error ? error.message : null}
          />
        )}
      />
      <TextField
        label="First Name"
        variant="filled"
        type="password"
        required
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <div>
        <Button type="submit" variant="contained" color="primary">
          Sign In
        </Button>
      </div>
    </form>
  );
};

export { SignInForm };
