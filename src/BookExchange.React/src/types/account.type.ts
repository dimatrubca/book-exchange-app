export declare module Account {
  export type SignInData = {
    username: string;
    password: string;
  };

  export type SignUpData = {
    username: string;
    email: string;
    password: string;
    confirmPassword: string;
  };

  export type TokenRequestResult = {
    access_token: string;
    expires_in: number;
    token_type: string;
    scope: string;
  };
}
