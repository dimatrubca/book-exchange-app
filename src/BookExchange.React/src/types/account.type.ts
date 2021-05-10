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
}
