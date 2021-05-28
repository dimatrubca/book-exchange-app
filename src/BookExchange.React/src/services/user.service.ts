import { fetchApi } from "./fetchApi";
import { User, Book, Common, Post, Request, Deal } from "types";
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
    `/user/${userId}/books/wished?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetPostRequests = (userId: number, pageSize: number, page: number) => {
  return fetchApi<Common.PaginatedResult<Post.Post>>(
    `/user/${userId}/posts/requests?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetRequestedPosts = (userId: number, pageSize: number, page: number) => {
  return fetchApi<Common.PaginatedResult<Post.Post>>(
    `/user/${userId}/posts/requested?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const CreateProfile = async () => {
  return fetchApi<User.User>("/user", {
    method: "POST",
  });
};

const GetUserStats = async (id: number) => {
  return fetchApi<User.UserStats>(`/user/${id}/stats`);
};

const GetRequestsToUser = async (
  userId: number,
  pageSize: number,
  page: number
) => {
  return fetchApi<Common.PaginatedResult<Request.Request>>(
    `/user/${userId}/requests/to?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetRequestsFromUser = async (
  userId: number,
  pageSize: number,
  page: number
) => {
  return fetchApi<Common.PaginatedResult<Request.Request>>(
    `/user/${userId}/requests/from?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetDealsToUser = async (
  userId: number,
  pageSize: number,
  page: number
) => {
  return fetchApi<Common.PaginatedResult<Deal.Deal>>(
    `/user/${userId}/deals/to?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetDealsFromUser = async (
  userId: number,
  pageSize: number,
  page: number
) => {
  return fetchApi<Common.PaginatedResult<Deal.Deal>>(
    `/user/${userId}/deals/from?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const GetUserBookshelf = async (
  userId: number,
  pageSize: number,
  page: number
) => {
  return fetchApi<Common.PaginatedResult<Post.Post>>(
    `/user/${userId}/posts/owned?pageSize=${pageSize}&pageNumber=${page}`
  );
};

const AddBookToWishlist = async (userId: number, bookId: number) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      bookId: bookId,
    }),
  };

  return fetchApi(`/user/${userId}/books/wished`, requestOptions);
};

const RequestPost = async (userId: number, postId: number) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      postId: postId,
    }),
  };

  return fetchApi(`/user/${userId}/requests`, requestOptions);
};

const GetTopUsers = async (topN: number) => {
  return fetchApi<User.LeaderboardData[]>(`/user/leaderboard?amount=${topN}`);
};

const GetRecommendedBooks = (userId: number) => {
  console.log("get recom books", userId);
  return fetchApi<Book.Book[]>(`/user/${userId}/books/recommended`);
};

const UserService = {
  GetCurrentUser,
  GetWishedBooks,
  CreateProfile,
  GetUserStats,
  GetRequestsToUser,
  GetRequestsFromUser,
  GetUserBookshelf,
  GetDealsToUser,
  GetDealsFromUser,
  AddBookToWishlist,
  RequestPost,
  GetTopUsers,
  GetRecommendedBooks,
};

export { UserService };
