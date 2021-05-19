import { Book, Category, Common } from "../types";

import { fetchApi } from "./fetchApi";

const API_BASE_URL = `https://localhost:5001/api`;

const userData = localStorage.getItem("userData");
const accessToken = userData ? JSON.parse(userData).token : "";

const GetBooks = (filters: Book.SearchFilters) => {
  const str = getQueryString(filters);
  console.log(str);
  return fetchApi<Common.PaginatedResult<Book.Book>>("/book?" + str);
};

const getQueryString = (params: any) => {
  var esc = encodeURIComponent;
  return Object.keys(params)
    .filter((k) => {
      if (!params[k]) return false;
      return true;
    })
    .map((k) => {
      if (Array.isArray(params[k])) {
        let result = "";
        for (let item of params[k]) {
          if (result !== "") result = "&" + result;
          result += esc(k) + "=" + esc(item["id"]);
        }
        return result;
      }

      return esc(k) + "=" + esc(params[k]);
    })
    .join("&");
};

const SearchBooks = () => (serachTerm: string) => {
  const userData = localStorage.getItem("userData");
  const accessToken = userData ? JSON.parse(userData).token : "";
};

const GetBooksBySearch = async (searchTerm: string) => {
  console.log(accessToken);
  console.log(`${API_BASE_URL}/book?title=${searchTerm}`);
  console.log("Bearer " + accessToken);
  return fetchApi<Book.Book>("/book?title=${searchTerm}");
};

const GetBookById = async (id: number) => {
  return fetch(`${API_BASE_URL}/book/${id}`).then((data) => data.json());
};

const GetBooksByISBN = async (isbns: string[]): Promise<Book.Book[]> => {
  return fetch(`${API_BASE_URL}/book`).then((data) => data.json());
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
  GetBooksByISBN,
  GetBooksBySearch,
  AddBook,
};

export { BookService };
