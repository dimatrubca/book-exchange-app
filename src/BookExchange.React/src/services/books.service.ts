import { Book } from "../types";

const API_BASE_URL = `https://localhost:44348/api`;

const GetBooks = async () => {
  console.log("getting books");
  return fetch(`${API_BASE_URL}/book`).then((data) => data.json());
};

const GetBookById = async (id: number) => {
  return fetch(`${API_BASE_URL}/book/${id}`).then((data) => data.json());
};

const AddBook = async (car: Book.Book) => {
  let formData = new FormData();
  for (const [key, value] of Object.entries(car)) {
    if (value) {
      formData.append(key, <string | Blob>value);
    }
  }
  const requestOptions = {
    method: "POST",
    body: formData,
  };

  fetch(`${API_BASE_URL}/book`, requestOptions)
    .then((response) => {
      console.log(response.ok);
      console.log(response.status);
      response.text();
    })
    .then((data) => console.log(data))
    .catch((error) => {
      console.log("There was an error", error);
    });
};

const BookService = {
  GetBooks,
  GetBookById,
  AddBook,
};

export { BookService };
