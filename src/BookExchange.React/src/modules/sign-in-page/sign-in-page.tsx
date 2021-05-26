import React from "react";

import { Authentication } from "components/authentication";
import { SignInForm } from "components/forms";

const SignInPage = () => {
  return (
    <Authentication isSignIn={true}>
      <SignInForm />
    </Authentication>
  );
};

export { SignInPage };
