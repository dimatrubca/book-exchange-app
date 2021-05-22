import { AuthorsService } from "services";
import { Author, Category } from "types";

export declare module Book {
  export type Book = {
    id: string;
    title: string;
    isbn: string;
    shortDescription: string;
    thumbnailPath: string;
    authors: Author.Author[];
    categories: Category.Category[];
    details: BookDetails;
  };

  export type BookDetails = {
    description: string;
    publisher: string;
    publishedYear?: number;
    pageCount?: number;
    imagePath: string;
  };

  export type CreateBook = {
    title: string;
    isbn: string;
    shortDescription: string;
    description: string;
    publisher: string;
    pageCount: number;
    publishedYear: number;
    authorsId: number[];
    categoriesId: number[];
    image: any;
  };

  export type SearchFilters = {
    title?: string;
    isbn?: string;
    description?: string;
    publisher?: string;
    minPageCount?: number;
    maxPageCount?: number;
    authors?: Author.Author[];
    categories?: Category.Category[];
    filterOperator?: string;
    pageSize?: number;
    pageNumber?: number;
  };
}
