import { useState } from "react";

const useToken = () => {
  const getToken = () => {
    const tokenString = sessionStorage.getItem("token");

    if (tokenString === null) return null;

    const userToken = JSON.parse(tokenString);
    return userToken?.token;
  };

  const saveToken = (userToken: any) => {
    sessionStorage.setItem("token", JSON.stringify(userToken));
    setToken(userToken.token);
  };

  const [token, setToken] = useState(getToken());

  return {
    setToken: saveToken,
    token,
  };
};

export { useToken };
