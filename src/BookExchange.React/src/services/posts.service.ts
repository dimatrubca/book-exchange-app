import { PostsFilter } from "filters";
import { fetchApi } from "./fetchApi";
import { Post } from "types";

const API_BASE_URL = `https://localhost:5001/api/`;

const GetPostById = async (id: string) => {
  return fetch(`${API_BASE_URL}/post/${id}`)
    .then((data) => data.json())
    .catch((error) => {
      console.log(error);
      return null;
    });
};

const GetPosts = async () => {
  const response = await fetch(`${API_BASE_URL}/post`);

  const json = response.ok ? await response.json() : [];
  return json;
};

// posts filter to
const GetPostsForBook = async (filter: PostsFilter) => {
  const searchParams = new URLSearchParams();

  for (let key in filter) {
    if (filter[key] != null) {
      searchParams.append(key, filter[key]);
    }
  }

  const response = await fetch(
    "https://localhost:5001/api/post?" + searchParams.toString()
  ).then((response) => response.json());

  return response;
};

const AddPostForBook = async (bookId: number, authorId: number) => {
  const requestOptions = {
    method: "POST",
    body: JSON.stringify({
      bookId: bookId,
      authorId: authorId,
    }),
  };

  fetch(`${API_BASE_URL}/post`, requestOptions)
    .then((response) => response.json())
    .catch((error) => {
      console.log("Error", error);
    });

  return;
};

const CreatePost = async (data: Post.CreatePost) => {
  const requestOptions = {
    method: "POST",
    body: data,
  };
  return fetchApi(`/post`, requestOptions);
};

const GetBookConditions = async (bookId: number): Promise<string[]> => {
  return fetchApi<string[]>(`/post/conditions`);
};

const PostService = {
  GetPostById,
  GetPosts,
  GetPostsForBook,
  AddPostForBook,
  GetBookConditions,
  CreatePost,
};

export { PostService };
