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

import { useStyles } from "./sign-in-page.styles";
import { Account } from "types";
import { AccountService } from "services";
import { AuthContext } from "context";
import { Authentication } from "components/authentication";
import { SignInForm } from "components/forms";

const SignInPage = () => {
  const classes = useStyles();

  return (
    <Authentication isSignIn={true}>
      <SignInForm />
    </Authentication>
  );
};

export { SignInPage };
