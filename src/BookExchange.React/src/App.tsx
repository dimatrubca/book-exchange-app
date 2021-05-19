import React, { useCallback, useEffect, useState } from "react";
import { ThemeProvider } from "@material-ui/core";

import "./App.css";

import { Route, Switch } from "react-router-dom";

import Home from "./Home";
import { Contact } from "./Contact";
import { SearchBooks } from "./modules/search-books";
import { BookDetails } from "./modules/book-page";
import { PostBooks } from "./modules/post-books";
import { AddBook } from "./modules/add-book";

import { Navbar } from "./components/navbar";
import { Userbar } from "./components/userbar";
import { useToken } from "./hooks";
import { SignInPage } from "./modules/sign-in-page";
import { SignUpPage } from "modules/sign-up-page";

import { AuthContext } from "./context";
import { AccountService, UserService } from "./services";
import { theme } from "./theme";
import { HomePage } from "./modules/home-page/home-page";
import { ProfilePage } from "modules/profile-page";
import { fetchApi } from "services/fetchApi";
import { Account } from "types";
import { RouterContainer } from "containers/router-container";

let logoutTimer: NodeJS.Timeout;

function App() {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<Account.UserInfo | null>(null);
  const [tokenExpirationDate, setTokenExpirationDate] =
    useState<Date | null>(null);

  const login = useCallback(
    (token: string, expirationTime: Date | null = null) => {
      console.log("Inside login: ", token);
      setToken(token);
      const expiration =
        expirationTime || new Date(new Date().getTime() + 1000 * 60 * 60);

      setTokenExpirationDate(expiration);

      localStorage.setItem("token", token);
      localStorage.setItem("tokenExpirationTime", expiration.toISOString());
    },
    []
  );
  //todo: on logout setuser(null)

  const logout = useCallback(() => {
    console.log("Inside logout callback");
    setToken(null);
    setTokenExpirationDate(null);
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpirationTime");
    localStorage.removeItem("user"); //
  }, []);

  const fetchCurrentUser = useCallback(async () => {
    const response = await fetchApi<Account.UserInfo>("/user/current-user");
    console.log("fetched user: ", response);
    setUser(response);
    localStorage.setItem("user", JSON.stringify(response));
  }, []);

  useEffect(() => {
    const token = localStorage.getItem(`token`);
    const expirationTime = localStorage.getItem(`tokenExpirationTime`);
    const user = localStorage.getItem("user"); //

    if (token == null || expirationTime == null || user == null) return;

    if (token && expirationTime && new Date(expirationTime) > new Date()) {
      login(token, new Date(expirationTime));

      setUser(JSON.parse(user));
    }
  }, [login]);

  useEffect(() => {
    if (token && tokenExpirationDate) {
      const remainingTime =
        tokenExpirationDate.getTime() - new Date().getTime();
      logoutTimer = setTimeout(logout, remainingTime);
    } else {
      clearTimeout(logoutTimer);
    }
  }, [token, logout, tokenExpirationDate]);

  return (
    <div>
      <ThemeProvider theme={theme}>
        <AuthContext.Provider
          value={{
            isLoggedIn: !!token,
            login: login,
            logout: logout,
            token: token,
            user: user,
            fetchCurrentUser: fetchCurrentUser,
          }}
        >
          <RouterContainer></RouterContainer>
        </AuthContext.Provider>
      </ThemeProvider>
    </div>
  );
}

export default App;
