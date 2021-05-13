import React, { createContext } from "react";
import { Account } from "../types";

const AuthContext = createContext({
  isLoggedIn: false,
  token: null as string | null,
  login: (token: string, expirationDate: Date | null = null) => {},
  logout: () => {},
  user: null as Account.UserInfo | null,
});

export { AuthContext };
