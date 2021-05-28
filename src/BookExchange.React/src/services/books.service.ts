import { Book, Category, Common } from "../types";

import { fetchApi } from "./fetchApi";

const GetBooks = (filters: Book.SearchFilters) => {
  const str = getQueryString(filters);
  console.log(str);
  return fetchApi<Common.PaginatedResult<Book.Book>>("/book?" + str);
};

const GetBooksBySearch = async (searchTerm: string) => {
  return fetchApi<Common.PaginatedResult<Book.Book>>(
    `/book/smart-search?searchTerm=${searchTerm}`
  );
};

const GetBookById = async (id: number) => {
  return fetchApi<Book.Book>(`/book/${id}?includeDetails=true`);
};

// check bellow
const GetBooksByISBN = async (isbns: string[]): Promise<Book.Book[]> => {
  return fetchApi<Book.Book[]>(`/book`);
};

const AddBook = async (book: Book.CreateBook) => {
  let formData = new FormData();
  for (const [key, value] of Object.entries(book)) {
    if (value) {
      formData.append(key, <string | Blob>value);
    }
  }

  // formData.append("file", book.image);

  const requestOptions = {
    method: "POST",
    body: formData,
  };

  console.log(book);
  console.log(requestOptions);
  console.log(book.image);

  return fetchApi<Book.Book>("/book", requestOptions);
};

// todo: check dependencies and remove method (transfered to ServiceUtils)
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

const BookService = {
  GetBooks,
  GetBookById,
  GetBooksByISBN,
  GetBooksBySearch,
  AddBook,
};

export { BookService };
