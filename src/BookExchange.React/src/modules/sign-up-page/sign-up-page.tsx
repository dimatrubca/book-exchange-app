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

const SignUpPage = () => {
  return (
    <Authentication isSignIn={false}>
      <SignUpForm />
    </Authentication>
  );
};

export { SignUpPage };
