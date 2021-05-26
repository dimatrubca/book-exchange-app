import React from "react";

import {
  Button,
  Container,
  Paper,
  TextField,
  Typography,
} from "@material-ui/core";
import { useParams } from "react-router";
import Grid from "@material-ui/core/Grid";
import { PaperContainer } from "components/paper-container";
import { useStyles } from "./add-post.styles";
import { BookCard } from "./components";
import { PostForm } from "./components";

interface RouteParams {
  bookId: string;
}

const AddPost = () => {
  const classes = useStyles();
  const { bookId } = useParams<RouteParams>();
  console.log(bookId);

  return (
    <PaperContainer>
      <Typography variant="h4" component="h1" className={classes.title}>
        Add to Bookshelf
      </Typography>

      <div className={classes.flexContainer}>
        <PostForm bookId={Number(bookId)} />
        <BookCard />
      </div>
    </PaperContainer>
  );
};

export { AddPost };
