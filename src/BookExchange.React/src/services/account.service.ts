const LoginUser = (credentials: any) => {
  console.log("loggin user");
  return fetch("https://localhost:5001/api/user/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  }).then((data) => data.json());
};

const AccountService = {};

export { AccountService };
