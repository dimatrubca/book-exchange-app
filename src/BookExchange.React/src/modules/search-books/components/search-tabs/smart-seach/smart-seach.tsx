import React from "react";
import { Book } from "types";
import { SearchBar } from "../../../../../components/search-bar";
import { BookService } from "../../../../../services";

interface SmartSearchProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
}

const SmartSearch = (props: SmartSearchProps) => {
  const handleSearch = async (searchTerm: string) => {
    try {
      console.log("searching books: " + searchTerm);
      var books = await BookService.GetBooksBySearch(searchTerm);
      console.log(books.data);
      console.log("smart serach result");
      props.setBooks(books.data);
    } catch (e) {
      console.log(e);
    }
  };

  return <SearchBar handleSearch={handleSearch} />;
};

export { SmartSearch };
