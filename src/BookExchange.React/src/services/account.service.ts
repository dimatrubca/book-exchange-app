import { Account, User } from "../types";
import { fetchApi } from "./fetchApi";
import { fetchIdentity } from "./fetchIdentity";
const API_BASE_URL = `https://localhost:5001/api`;

const SignUp = async (userData: Account.SignUpData) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  };

  const result = fetchIdentity(`/api/identity/register`, requestOptions);
  return result;
};

const RequestToken = async (
  username: string,
  password: string
): Promise<Account.TokenRequestResult> => {
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
    }),
  };

  return fetchIdentity(`/connect/token`, requestOptions);
};

const AccountService = {
  SignUp,
  RequestToken,
};

export { AccountService };
