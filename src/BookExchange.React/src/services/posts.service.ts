import { PostsFilter } from "filters";
import { fetchApi } from "./fetchApi";
import { Post, Common } from "types";
import { ServiceUtils } from "utils";

const API_BASE_URL = `https://localhost:5001/api/`;

const GetPostById = async (id: string) => {
  return fetch(`${API_BASE_URL}/post/${id}`)
    .then((data) => data.json())
    .catch((error) => {
      console.log(error);
      return null;
    });
};

const GetPosts = async (filter: Post.PostsFilter) => {
  const query = ServiceUtils.objectToQueryString(filter);

  return await fetchApi<Common.PaginatedResult<Post.Post>>(`/post?${query}`);
};

const CreatePost = async (data: Post.CreatePost) => {
  const requestOptions = {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
    },
  };
  return fetchApi(`/post`, requestOptions);
};

const GetBookConditions = async (bookId: number): Promise<string[]> => {
  return fetchApi<string[]>(`/post/conditions`);
};

const PostService = {
  GetPostById,
  GetPosts,
  GetBookConditions,
  CreatePost,
};

export { PostService };
