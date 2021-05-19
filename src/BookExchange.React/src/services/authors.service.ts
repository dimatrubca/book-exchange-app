import { fetchApi } from "./fetchApi";
import { Author } from "types";

const GetAll = async () => {
  return fetchApi<Author.Author[]>("/author");
};

const AuthorsService = {
  GetAll,
};
export { AuthorsService };
