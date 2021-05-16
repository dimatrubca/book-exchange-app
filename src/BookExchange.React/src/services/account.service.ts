import { Account } from "../types";
import { fetchApi } from "./fetchApi";
const API_BASE_URL = `https://localhost:5001/api`;

const SignIn = async (credentials: Account.SignInData) => {
  console.log("logging user");
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  };

  return fetch(`${API_BASE_URL}/identity/login`, requestOptions).then((data) =>
    data.json()
  );
};

const SignOut = async () => {
  localStorage.removeItem("user");
};

const GetUserInfo = async () => {};

const SignUp = async (userData: Account.SignUpData) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  };

  const result = fetchApi(`/identity/register`, requestOptions);
  return result;
};

const RequestToken = async (username: string, password: string) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/x-www-form-urlencoded;charset=UTF-8",
    },
    body: new URLSearchParams({
      grant_type: "password",
      client_id: "client",
      username: username,
      password: password,
      scope: "bookApi profile",

      // could also explicitly ask for scopes here
    }),
  };
  return fetch(`https://localhost:5001/connect/token`, requestOptions)
    .then((res) => {
      if (!res.ok) {
        return res.text().then((text) => {
          throw Error(text);
        });
      } else {
        return res.text();
      }
    })
    .then((data) => (data ? JSON.parse(data) : {}));
};

const CreateProfile = async () => {
  return fetchApi<Account.UserInfo>("/user", {
    method: "POST",
  });
};

const GetCurrentUser = () => {
  const user = localStorage.getItem("user");

  if (!user) return null;
  return JSON.parse(user);
};

const AccountService = {
  SignUp,
  SignIn,
  SignOut,
  GetCurrentUser,
  RequestToken,
  CreateProfile,
};

export { AccountService };
