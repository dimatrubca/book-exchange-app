const API_BASE_URL = `https://localhost:44348/api/`;

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

const GetPostsForBook = async (bookId: string) => {
  const response = await fetch(
    "https://localhost:44348/api/post?" +
      new URLSearchParams({
        bookId: bookId,
      })
  );

  const json = response.ok ? response.json() : [];
  return json;
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
