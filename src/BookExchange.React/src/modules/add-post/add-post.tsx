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
interface RouteParams {
  bookId: string;
}

const AddPost = () => {
  const classes = useStyles();
  const { bookId } = useParams<RouteParams>();
  console.log(bookId);

  const BookCard = (
    <div className={classes.bookCard}>
      <img
        src={"https://m.media-amazon.com/images/I/51V0MmBCHLS._SL300_.jpg"}
        alt=""
        className={classes.bookCover}
      />
      <div className={classes.bookDetails}>
        <Typography component="h5" variant="h5" className={classes.bookTitle}>
          Live From Space
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Author:</b> McMeekin, Sean
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Published:</b> 2020
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>ISBN:</b> 9781541672796
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Average rating:</b> 4.5
        </Typography>
        <Typography variant="subtitle1" color="textSecondary">
          <b>Categories:</b> Fiction, Novel
        </Typography>
      </div>
    </div>
  );

  return (
    <PaperContainer>
      <Typography variant="h4" component="h1" className={classes.title}>
        Add to Bookshelf
      </Typography>

      <div className={classes.flexContainer}>
        <div>
          <form className={classes.postForm}>
            <TextField variant="outlined" label="Condition" fullWidth />
            <TextField variant="outlined" label="Status" fullWidth />
            <Button variant="contained" color="primary" type="submit">
              Submit
            </Button>{" "}
          </form>
        </div>
        <div>{BookCard}</div>
      </div>
    </PaperContainer>
  );
};

export { AddPost };
