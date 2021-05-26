import React, { createContext, useCallback, useEffect, useState } from "react";
import { UserService } from "services";
import { User } from "../types";

export type AuthContextValues = {
  isLoggedIn: boolean;
  token: string | null;
  login: (token: string, expirationDate: Date) => void;
  logout: () => void;
  user: User.User | null;
  setUser: React.Dispatch<React.SetStateAction<User.User | null>>;
  fetchCurrentUser: () => Promise<void>;
};

const AuthContext = createContext<AuthContextValues>({} as AuthContextValues);

let logoutTimer: NodeJS.Timeout;

const AuthContextProvider: React.FC = (props) => {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<User.User | null>(null);
  const [tokenExpirationDate, setTokenExpirationDate] =
    useState<Date | null>(null);

  const login = useCallback((token: string, expirationTime: Date) => {
    console.log("Inside login callback: ", token);
    console.log(expirationTime, expirationTime.toISOString());

    setToken(token);
    setTokenExpirationDate(expirationTime);

    localStorage.setItem("token", token);
    localStorage.setItem("tokenExpirationTime", expirationTime.toISOString());
  }, []);

  const logout = useCallback(() => {
    console.log("Inside logout callback");
    setToken(null);
    setTokenExpirationDate(null);
    setUser(null);
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpirationTime");
    localStorage.removeItem("user");
  }, []);

  const fetchCurrentUser = useCallback(async () => {
    const response = await UserService.GetCurrentUser();
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

  var contextValues = {
    isLoggedIn: !!token,
    login: login,
    logout: logout,
    token: token,
    user: user,
    setUser: setUser,
    fetchCurrentUser: fetchCurrentUser,
  };

  return (
    <div>
      <AuthContext.Provider value={contextValues}>
        {props.children}
      </AuthContext.Provider>
    </div>
  );
};

export { AuthContext, AuthContextProvider };
