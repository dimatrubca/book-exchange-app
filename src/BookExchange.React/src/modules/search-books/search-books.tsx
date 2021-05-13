import React, { useState } from "react";
import IconButton from "@material-ui/core/IconButton";
import InputAdornment from "@material-ui/core/InputAdornment";
import SearchIcon from "@material-ui/icons/Search";

import { Container, Typography, Link, Box, TextField } from "@material-ui/core";
import { BookCard, BookCardProps } from "../../components/book-card";
import { useStyles } from "./search-books.styles";
import { AdvancedSearchOptions } from "./components";
import { BookService } from "services";

const books: BookCardProps[] = [
  {
    id: 1,
    title: "Essentialism",
    authors: ["Greg McKeown"],
    categories: ["Self-help"],
    isbn: "9381723333123",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 2,
    title: "War and Peace",
    authors: ["Leo Tolstoy"],
    categories: ["Novel"],
    isbn: "9780786112517",
    thumbnailPath: "https://images.penguinrandomhouse.com/cover/9781400079988",
  },
  {
    id: 3,
    title: "A Confession",
    authors: ["Leo Tolstoy"],
    categories: ["Novel", "Fiction"],
    isbn: "9788807900501",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/51ZyeQWzSPL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 4,
    title: "The Cossacks",
    authors: ["Greg McKeown"],
    categories: ["Novel", "Fiction", "Novella"],
    isbn: "9780786105236",
    thumbnailPath:
      "https://m.media-amazon.com/images/I/51zJRaQ-0ML._SL500_.jpg",
  },
];

const SearchBooks = () => {
  const classes = useStyles();
  const [searchTerm, setSearchTerm] = useState<string>("");

  const handleSearch = async () => {
    try {
      console.log("searching books: " + searchTerm);
      var books = await BookService.GetBooksBySearch(searchTerm);
      console.log(books);
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <Container>
      <TextField
        className={classes.mainSearchbar}
        fullWidth={true}
        variant="outlined"
        label="Search"
        onChange={(e) => setSearchTerm(e.target.value)}
        InputProps={{
          endAdornment: (
            <InputAdornment position="end">
              <IconButton onClick={handleSearch}>
                <SearchIcon />
              </IconButton>
            </InputAdornment>
          ),
        }}
      />

      <AdvancedSearchOptions />

      {books.map((book) => (
        <Box my={3} key={book.id}>
          <BookCard {...book} />
        </Box>
      ))}
    </Container>
  );
};

export { SearchBooks };
