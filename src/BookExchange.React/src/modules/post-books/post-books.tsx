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
import { BookCard } from "../../components/book-card";
import { BookService } from "../../services";
import { Book } from "types";

const PostBooks = () => {
  const classes = useStyles();
  const [inputFields, setInputFields] = useState([{ id: uuidv4(), isbn: "" }]);
  const [booksToAdd, setBooksToAdd] = useState<Book.Book[]>([]);
  const [notFoundISBNs, setNotFoundISBNs] = useState<string[]>([]);

  const handleSubmit = async (e: React.SyntheticEvent) => {
    e.preventDefault();
    console.log("ISBNs", inputFields);

    try {
      let isbns = inputFields.map((field) => field.isbn);
      const books = await BookService.GetBooksByISBN(isbns);

      const found = books.map((b) => b.isbn);
      const notFound = isbns.filter((b) => {
        return found.indexOf(b) < 0;
      });

      setBooksToAdd(books);
      setNotFoundISBNs(notFound);
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
              type="number"
              label="ISBN"
              variant="outlined"
              value={inputField.isbn}
              onChange={(event) => {
                event.target.value = Math.max(0, parseInt(event.target.value))
                  .toString()
                  .slice(0, 12);
                handleChangeInput(inputField.id, event);
              }}
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
      {/* 
      {books.map((book) => (
        <Box my={3} key={book.id}>
          <BookCard {...book} />
        </Box>
      ))}
      */}
      {booksToAdd ? (
        booksToAdd.map((book) => <Box>{book.isbn}</Box>)
      ) : (
        <>Empty</>
      )}
      {notFoundISBNs && (
        <div>
          <Typography variant="h2">Add Manually</Typography>
          <Typography component="p">
            {notFoundISBNs.length} of your books weren't found in our Database.
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
