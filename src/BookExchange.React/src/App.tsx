import React, { useCallback, useEffect, useState } from "react";
import { ThemeProvider } from "@material-ui/core";
import { SnackbarProvider, VariantType, useSnackbar } from "notistack";

import "./App.css";

import { AuthContext } from "./context";
import { UserService } from "./services";
import { theme } from "./theme";
import { HomePage } from "./modules/home-page/home-page";
import { ProfilePage } from "modules/profile-page";
import { fetchApi } from "services/fetchApi";
import { User } from "types";
import { RouterContainer } from "containers/router-container";
import { AuthContextProvider } from "context";

function App() {
  //todo: on logout setuser(null)

  return (
    <div>
      <ThemeProvider theme={theme}>
        <SnackbarProvider
          maxSnack={3}
          anchorOrigin={{
            vertical: "bottom",
            horizontal: "center",
          }}
        >
          <AuthContextProvider>
            <RouterContainer />
          </AuthContextProvider>
        </SnackbarProvider>
      </ThemeProvider>
    </div>
  );
}

export default App;
