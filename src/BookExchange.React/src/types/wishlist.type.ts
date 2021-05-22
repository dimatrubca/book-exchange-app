import { Common } from "../types";

export declare module Wishlist {
  export type Wishlist = {
    UserId?: number;
    BookId?: number;
  };

  export type WishlistFilter = Common.PaginationFilter & {
    UserId?: number;
    BookId?: number;
  };
}
