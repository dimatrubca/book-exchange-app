import React from "react";
import { SearchBar } from "../../../../../components/search-bar";
import { BookService } from "../../../../../services";

const SmartSearch = () => {
  const handleSearch = async (searchTerm: string) => {
    try {
      console.log("searching books: " + searchTerm);
      var books = await BookService.GetBooksBySearch(searchTerm);
      console.log(books);
    } catch (e) {
      console.log(e);
    }
  };

  return <SearchBar handleSearch={handleSearch} />;
};

export { SmartSearch };
