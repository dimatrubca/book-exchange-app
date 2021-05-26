import { fetchApi } from "./fetchApi";
import { User, Book, Common, Post } from "types";
import { ServiceUtils } from "../utils";

const GetCurrentUser = (): Promise<User.User> => {
  return fetchApi<User.User>(`/user/current-user`);
};

export interface Filters {
  userId: number;
  pageNumber: number;
  pageSize: number;
}

const GetWishedBooks = (userId: number, pageSize: number, page: number) => {
  console.log(userId);
  console.log(".......");
  return fetchApi<Common.PaginatedResult<Book.Book>>(
    `/user/${userId}/wishlist`
  );
};

const GetPostRequests = (userId: number) => {
  return fetchApi<Common.PaginatedResult<Post.Post>>(
    `/user/${userId}/posts/requests`
  );
};

const GetRequestedPosts = (userId: number) => {
  return fetchApi<Common.PaginatedResult<Post.Post>>(
    `/user/${userId}/posts/requested`
  );
};

// const GetPostRequests = (userId: number) => {
//   return fetchApi<Common.PaginatedResult<Post.Post>>(
//     `user/${userId}/posts/requests`
//   );
// };

// const GetUserPosts = (userId: number) => {
//   return fetchApi<Common.PaginatedResult<Book.Book>>(
//     `user/${userId}/bookshelf`
//   );
// };

// const GetApprovedRequests = (userId: number) => {
//   return fetchApi<Common.PaginatedResult<Post.Post>>(
//     `user/${userId}/requests/approved`
//   )
// }

const CreateProfile = async () => {
  return fetchApi<User.User>("/user", {
    method: "POST",
  });
};

const GetUserStats = async (id: number) => {
  return fetchApi<User.UserStats>(`/user/${id}/stats`);
};

const UserService = {
  GetCurrentUser,
  GetWishedBooks,
  CreateProfile,
  GetUserStats,
  GetPostRequests,
  GetRequestedPosts,
};

export { UserService };
