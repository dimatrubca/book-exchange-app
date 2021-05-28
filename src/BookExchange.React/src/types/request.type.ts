import { User, Post } from "./";
import { Common } from "./common.type";

export declare module Request {
  export type Request = {
    id: number;
    postId: number;
    useId: number;
    status: string;

    post: Post.Post;
    user: User.User;
  };
}
