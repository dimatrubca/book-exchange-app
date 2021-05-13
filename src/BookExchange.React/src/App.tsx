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
import { SignIn } from "./modules/sign-in";

import { AuthContext } from "./context";
import { AccountService } from "./services";
import { theme } from "./theme";
import { HomePage } from "./modules/home-page/home-page";

let logoutTimer: NodeJS.Timeout;

function App() {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState();
  const [tokenExpirationDate, setTokenExpirationDate] =
    useState<Date | null>(null);

  const login = useCallback(
    (token: string, expirationTime: Date | null = null) => {
      console.log("Insode login: ", token);
      setToken(token);
      const expiration =
        expirationTime || new Date(new Date().getTime() + 1000 * 60 * 60);

      setTokenExpirationDate(expiration);

      localStorage.setItem("token", token);
      localStorage.setItem("tokenExpirationTime", expiration.toISOString());
    },
    []
  );

  const logout = useCallback(() => {
    console.log("Inside logout callback");
    setToken(null);
    setTokenExpirationDate(null);
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpirationTime");
  }, []);

  useEffect(() => {
    const token = localStorage.getItem(`userData`);
    const expirationTime = localStorage.getItem(`tokenExpirationTime`);

    if (token == null || expirationTime == null) return;

    if (token && expirationTime && new Date(expirationTime) > new Date()) {
      login(token, new Date(expirationTime));
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
            user: null,
          }}
        >
          <Navbar />
          <h1>...</h1>

          <Userbar />
          <Switch>
            <Route exact path="/home" component={HomePage} />
            <Route exact path="/sign-in" component={SignIn} />
            {/* <Route exact path="/" component={Home} /> */}
            <Route exact path="/search" render={(props) => <SearchBooks />} />
            <Route exact path="/book/:id" component={BookDetails} />
            <Route exact path="/post-book" component={PostBooks} />

            <Route exact path="/contact" component={Contact} />
            <Route exact path="/add-book" component={AddBook} />
          </Switch>
        </AuthContext.Provider>
      </ThemeProvider>
    </div>
  );
}

export default App;
