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
    imagePath: string;
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
