import React from "react";
import { ThemeProvider } from "@material-ui/core";
import { SnackbarProvider } from "notistack";

import "./App.css";

import { theme } from "./theme";
import { RouterContainer } from "containers/router-container";
import { AuthContextProvider } from "context";

function App() {
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
