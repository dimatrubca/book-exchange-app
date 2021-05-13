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

  export type UserInfo = {
    username: string | null;
    fistName: string | null;
    lastName: string | null;
    email: string | null;
    points: number | null;
    address: string | null;
  };
}
