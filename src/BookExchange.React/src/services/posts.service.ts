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

export interface PostFilter {
  pageNumber: number;
  pageSize: number;
  sortDirection: string;
  sortBy: string;
  bookId: number;
}

const GetPostsForBook = async (filter: PostFilter) => {
  const response = await fetch(
    "https://localhost:5001/api/post?" +
      new URLSearchParams({
        pageNumber: filter.pageNumber.toString(),
        pageSize: filter.pageSize.toString(),
        sortDirection: filter.sortDirection,
        sortBy: filter.sortBy,
        bookId: filter.bookId.toString(),
      }).toString()
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

const PostService = { GetPostById, GetPosts, GetPostsForBook, AddPostForBook };

export { PostService };
