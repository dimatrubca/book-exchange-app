import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import Typography from "@material-ui/core/Typography";
import HighlightOffIcon from "@material-ui/icons/HighlightOff";
import { useStyles } from "./book-card.styles";
import { Book } from "types";

// id: number;
// title: string;
// authors: string[];
// categories: string[];
// isbn: string;
// thumbnailPath?: string;

const BookCard = (book: Book.Book) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <div className={classes.details}>
        <CardContent className={classes.content}>
          <Typography component="h5" variant="h5">
            {book.title}
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
        image={book.thumbnailPath}
        title="Live from space album cover"
      />
    </Card>
  );
};

export { BookCard };
