import { Account } from "../types";

const API_BASE_URL = `https://localhost:44348/api`;

const SignIn = async (credentials: Account.SignInData) => {
  console.log("logging user");
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  };

  return fetch(`${API_BASE_URL}/user/login`, requestOptions)
    .then((data) => data.json())
    .then((data) => {
      if (data.accessToken) {
        localStorage.setItem("user", JSON.stringify(data));
      }
      return data;
    })
    .catch((err) => {
      console.log(err);
    });
};

const SignOut = async () => {
  localStorage.removeItem("user");
};

const SignUp = async (userData: Account.SignUpData) => {
  const requestOptions = {
    method: "POST",
    body: JSON.stringify(userData),
  };

  const register = fetch(`${API_BASE_URL}/user/register`, requestOptions)
    .then((data) => data.json())
    .then((data) => {
      console.log(data);
    })
    .catch((err) => {
      console.log(err);
    });
};

const GetCurrentUser = () => {
  const user = localStorage.getItem("user");

  if (!user) return null;
  return JSON.parse(user);
};

const AccountService = {
  SignIn,
  SignOut,
  GetCurrentUser,
};

export { AccountService };
