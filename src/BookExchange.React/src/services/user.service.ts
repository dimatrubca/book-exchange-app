import { fetchApi } from "./fetchApi";
import { Account } from "types";

const GetCurrentUser = (): Promise<Account.UserInfo> => {
  return fetchApi<Account.UserInfo>(`/user/current-user`);
};

const UserService = {
  GetCurrentUser,
};

export { UserService };
