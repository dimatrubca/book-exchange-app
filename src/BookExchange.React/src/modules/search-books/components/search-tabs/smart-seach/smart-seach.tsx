import React from "react";
import { Book } from "types";
import { SearchBar } from "../../../../../components/search-bar";
import { BookService } from "../../../../../services";

interface SmartSearchProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
  isActiveSmartSearch: any;
  setActiveSmartSearch: any;
}

const SmartSearch = (props: SmartSearchProps) => {
  const handleSearch = async (searchTerm: string) => {
    try {
      props.setActiveSmartSearch(true);
      var books = await BookService.GetBooksBySearch(searchTerm);
      console.log(books.data);
      props.setBooks(books.data);
    } catch (e) {
      console.log(e);
    }
  };

  return <SearchBar handleSearch={handleSearch} />;
};

export { SmartSearch };
