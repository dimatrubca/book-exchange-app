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
    points: number | null;
    userContact: UserContact | null;
  };

  export type UserContact = {
    phoneNumber: string | null;
    email: string | null;
    zipCode: string | null;
    city: string | null;
    region: string | null;
    streetAddress: string | null;
  };
}
