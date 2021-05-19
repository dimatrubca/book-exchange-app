import { fetchApi } from "./fetchApi";
import { Category } from "types";

const GetAll = async () => {
  return fetchApi<Category.Category[]>("/category");
};

const CategoryService = {
  GetAll,
};

export { CategoryService };
