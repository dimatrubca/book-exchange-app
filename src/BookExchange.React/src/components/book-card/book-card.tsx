import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import Typography from "@material-ui/core/Typography";

import { useStyles } from "./book-card.styles";

export type BookCardProps = {
  id: number;
  title: string;
  authors: string[];
  categories: string[];
  isbn: string;
  thumbnailPath?: string;
};

const BookCard = (props: BookCardProps) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <div className={classes.details}>
        <CardContent className={classes.content}>
          <Typography component="h5" variant="h5">
            {props.title}
          </Typography>
          <Typography variant="subtitle1" color="textSecondary">
            by {props.authors.join(", ")}
          </Typography>
          <Typography>ISBN: {props.isbn}</Typography>
          <Typography>Categories: {props.categories.join(", ")}</Typography>
        </CardContent>
        <div className={classes.controls}>
          <IconButton aria-label="play/pause">
            <AddCircleIcon className={classes.playIcon} />
          </IconButton>
        </div>
      </div>
      <CardMedia
        className={classes.cover}
        image={props.thumbnailPath}
        title="Live from space album cover"
      />
    </Card>
  );
};

export { BookCard };
