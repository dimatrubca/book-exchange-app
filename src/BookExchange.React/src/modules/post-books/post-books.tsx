import React, { useState } from "react";

// imports
import Button from "@material-ui/core/Button";
import IconButton from "@material-ui/core/IconButton";
import RemoveIcon from "@material-ui/icons/Remove";
import SendIcon from "@material-ui/icons/Send";
import AddIcon from "@material-ui/icons/Add";

import {
  Box,
  Container,
  Divider,
  TextField,
  Typography,
} from "@material-ui/core";

import { v4 as uuidv4 } from "uuid";

import { useStyles } from "./post-books.styles";
import { BookCard, BookCardProps } from "../../components/book-card";
import { BookService } from "../../services";

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

const PostBooks = () => {
  const classes = useStyles();
  const [inputFields, setInputFields] = useState([{ id: uuidv4(), isbn: "" }]);
  const [booksToAdd, setBooksToAdd] = useState([]);
  const [notFoundBooks, setNotFoundBooks] = useState([]);

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault();
    console.log("ISBNs", inputFields);

    try {
      var books = BookService.GetBooksByISBN(
        inputFields.map((field) => field.isbn)
      );

      // setBooksToAdd(books);
    } catch (e) {
      console.log("error while fetching books");
    }
  };

  const handleChangeInput = (
    id: string,
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const newInputFields = inputFields.map((i) => {
      if (id === i.id) {
        i["isbn"] = event.target.value;
      }
      return i;
    });

    setInputFields(newInputFields);
  };

  const handleAddFields = () => {
    setInputFields([...inputFields, { id: uuidv4(), isbn: "" }]);
  };

  const handleRemoveFields = (id: string) => {
    const values = [...inputFields];
    values.splice(
      values.findIndex((value) => value.id === id),
      1
    );
    setInputFields(values);
  };

  return (
    <Container>
      <Typography className={classes.pageTitle} variant="h2">
        Add Books To Your Bookshelf
      </Typography>
      <Typography className={classes.subTitle}>
        Enter below the ISBN of the books you want to add to your bookshelf. You
        can find it on the back of the cover .
      </Typography>
      <form className={classes.root} onSubmit={handleSubmit}>
        {inputFields.map((inputField) => (
          <div key={inputField.id}>
            <TextField
              name="isbn"
              label="ISBN"
              variant="outlined"
              value={inputField.isbn}
              onChange={(event) => handleChangeInput(inputField.id, event)}
            />

            <IconButton
              disabled={inputFields.length === 1}
              onClick={() => handleRemoveFields(inputField.id)}
            >
              <RemoveIcon />
            </IconButton>

            <IconButton onClick={handleAddFields}>
              <AddIcon />
            </IconButton>
          </div>
        ))}

        <Button
          className={classes.button}
          variant="contained"
          color="primary"
          type="submit"
          onClick={handleSubmit}
          endIcon={<SendIcon />}
        >
          Submit
        </Button>
      </form>

      {books.map((book) => (
        <Box my={3} key={book.id}>
          <BookCard {...book} />
        </Box>
      ))}

      {notFoundBooks && (
        <div>
          <Typography variant="h2">Add Manually</Typography>
          <Typography component="p">
            {notFoundBooks.length} of your books weren't found in our Database.
            You can still add them manually
          </Typography>

          <Button variant="contained" color="primary" component="span">
            Add Book Manually
          </Button>
        </div>
      )}
    </Container>
  );
};

export { PostBooks };
