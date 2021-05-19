import React, { useState } from "react";

import {
  Container,
  Typography,
  Link,
  Box,
  TextField,
  Grid,
  IconButton,
} from "@material-ui/core";
import { BookCard } from "../../components/book-card";
import { BookMediaCard } from "../../components/book-media-card";
import { useStyles } from "./search-books.styles";
import { SearchTabs } from "./components";
import { BookService } from "services";
import ListIcon from "@material-ui/icons/List";
import ViewComfyIcon from "@material-ui/icons/ViewComfy";
import ViewListIcon from "@material-ui/icons/ViewList";
import SettingsIcon from "@material-ui/icons/Settings";
import ReorderIcon from "@material-ui/icons/Reorder";
import { Pagination } from "@material-ui/lab";
import TablePagination from "@material-ui/core/TablePagination";
import { Book } from "types";
/*
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
  {
    id: 5,
    title: "Essentialism",
    authors: ["Greg McKeown"],
    categories: ["Self-help"],
    isbn: "9381723333123",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 6,
    title: "War and Peace",
    authors: ["Leo Tolstoy"],
    categories: ["Novel"],
    isbn: "9780786112517",
    thumbnailPath: "https://images.penguinrandomhouse.com/cover/9781400079988",
  },
  {
    id: 8,
    title: "A Confession",
    authors: ["Leo Tolstoy"],
    categories: ["Novel", "Fiction"],
    isbn: "9788807900501",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/51ZyeQWzSPL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 9,
    title: "The Cossacks",
    authors: ["Greg McKeown"],
    categories: ["Novel", "Fiction", "Novella"],
    isbn: "9780786105236",
    thumbnailPath:
      "https://m.media-amazon.com/images/I/51zJRaQ-0ML._SL500_.jpg",
  },
  {
    id: 10,
    title: "Essentialism",
    authors: ["Greg McKeown"],
    categories: ["Self-help"],
    isbn: "9381723333123",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 11,
    title: "War and Peace",
    authors: ["Leo Tolstoy"],
    categories: ["Novel"],
    isbn: "9780786112517",
    thumbnailPath: "https://images.penguinrandomhouse.com/cover/9781400079988",
  },
  {
    id: 12,
    title: "A Confession",
    authors: ["Leo Tolstoy"],
    categories: ["Novel", "Fiction"],
    isbn: "9788807900501",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/51ZyeQWzSPL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 13,
    title: "The Cossacks",
    authors: ["Greg McKeown"],
    categories: ["Novel", "Fiction", "Novella"],
    isbn: "9780786105236",
    thumbnailPath:
      "https://m.media-amazon.com/images/I/51zJRaQ-0ML._SL500_.jpg",
  },
];*/

const SearchBooks = () => {
  const classes = useStyles();
  const [isListView, setListView] = useState<boolean>(false);
  console.log("listview: ", isListView);

  const [page, setPage] = React.useState(2);
  const [books, setBooks] = React.useState<Book.Book[]>();
  const [rowsPerPage, setRowsPerPage] = React.useState(10);
  const [totalRecords, setTotalRecords] = React.useState(0);

  const handleChangePage = (
    event: React.MouseEvent<HTMLButtonElement> | null,
    newPage: number
  ) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <Container>
      <SearchTabs
        setTotalRecords={setTotalRecords}
        page={page}
        rowsPerPage={rowsPerPage}
        setBooks={setBooks}
      />
      <Grid
        container
        justify="flex-end"
        className={classes.filterIconsContainer}
      >
        <IconButton
          aria-label="delete"
          onClick={() => {
            setListView(true);
          }}
        >
          <ReorderIcon className={classes.filterIcon} />
        </IconButton>
        <IconButton
          aria-label="delete"
          onClick={() => {
            setListView(false);
          }}
          className={classes.filterIcon}
        >
          <ViewComfyIcon />
        </IconButton>
        {/* <IconButton aria-label="delete" className={classes.filterIcon}>
          <SettingsIcon />
        </IconButton> */}
      </Grid>
      {isListView ? (
        books?.map((book) => (
          <Box my={3} key={book.id}>
            <BookCard {...book} />
          </Box>
        ))
      ) : (
        <Grid container spacing={4}>
          {books?.map((book) => (
            <Grid item sm={3} key={book.id}>
              <BookMediaCard />
            </Grid>
          ))}
        </Grid>
      )}
      <TablePagination
        component="div"
        count={totalRecords}
        page={page}
        onChangePage={handleChangePage}
        rowsPerPage={rowsPerPage}
        onChangeRowsPerPage={handleChangeRowsPerPage}
      />{" "}
    </Container>
  );
};

export { SearchBooks };
