import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import { Link, Typography } from "@material-ui/core";
import HighlightOffIcon from "@material-ui/icons/HighlightOff";
import { useStyles } from "./book-card.styles";
import { Book } from "types";

const BookCard = (book: Book.Book) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <div className={classes.details}>
        <CardContent className={classes.content}>
          <Typography component="h5" variant="h5">
            <Link
              href={"book/" + book.id}
              style={{ textDecoration: "none" }}
              color="inherit"
            >
              {book.title}
            </Link>{" "}
          </Typography>
          <Typography variant="subtitle1" color="textSecondary">
            by {book.authors?.map((a) => a.name).join(", ")}
          </Typography>
          <Typography>ISBN: {book.isbn}</Typography>
          <Typography>
            Categories: {book.categories?.map((c) => c.label).join(", ")}
          </Typography>
        </CardContent>
        <div className={classes.controls}>
          <IconButton aria-label="play/pause">
            <AddCircleIcon className={classes.playIcon} />
          </IconButton>
        </div>
      </div>
      <CardMedia
        className={classes.cover}
        image="https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg"
        title="Live from space album cover"
      />
    </Card>
  );
};

export { BookCard };
