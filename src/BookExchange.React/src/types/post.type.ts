import { Book, User, Condition } from "types";
import { Common } from "./common.type";

export declare module Post {
  export type Post = {
    id: number;
    bookId: number;
    postedById: number;
    condition: string;
    status: string;
    timeAdded: Date;

    book: Book.Book | null;
    postedBy: User.User | null;
  };

  export type CreatePost = {
    bookId: number;
    postedById: number;
    condition: string;
  };

  export type PostsFilter = Common.PaginationFilter & {
    [key: string]: any;

    includePostedBy?: boolean;
    includeCondition?: boolean;
    includeBook?: boolean;
    status?: string;
    bookId?: number;
    condition?: string;
    timeAdded?: Date;
  };
}
