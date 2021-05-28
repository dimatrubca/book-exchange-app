import { Typography } from "@material-ui/core";
import React, { useEffect } from "react";
import { useStyles } from "./book-card.styles";
import { useFetch } from "hooks";
import { BookService } from "services";
import { useParams } from "react-router";
import { ImageUtils } from "utils";
const BookCard = () => {
  const classes = useStyles();

  const {
    data: book,
    fetch: fetchBook,
    isLoading,
  } = useFetch(BookService.GetBookById);

  const { bookId } = useParams<{ bookId: string }>();
  console.log("Book id: ", bookId);

  useEffect(() => {
    if (isNaN(Number(bookId))) {
      return;
    }

    fetchBook(Number(bookId));
    //eslint-disable-next-line
  }, [bookId]);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (book == null) {
    return <p>Invalid book id</p>;
  }

  console.log(book);

  return (
    <div className={classes.root}>
      <img
        src={ImageUtils.getAbsolutePath(book.thumbnailPath)}
        alt=""
        className={classes.bookCover}
      />
      <div className={classes.bookDetails}>
        <Typography component="h5" variant="h5" className={classes.bookTitle}>
          {book.title}
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Authors:</b> {book.authors?.map((a) => a.name).join(", ")}
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Published:</b> {book?.details?.publishedYear}
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>ISBN:</b> {book?.isbn}
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Average rating:</b> 4.5
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Categories:</b> {book.categories?.map((c) => c.label).join(", ")}
        </Typography>
      </div>
    </div>
  );
};

export { BookCard };
