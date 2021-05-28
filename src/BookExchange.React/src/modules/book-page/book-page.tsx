import React, { useContext, useEffect, useState } from "react";
import {
  Avatar,
  Button,
  Container,
  Dialog,
  DialogTitle,
  Grid,
  List,
  ListItem,
  ListItemAvatar,
  Paper,
  Typography,
} from "@material-ui/core";
import { useSnackbar } from "notistack";

import { Divider } from "@material-ui/core";
import { UserService } from "services";

import { useDemoData } from "@material-ui/x-grid-data-generator";
import Box from "@material-ui/core/Box";
import Rating from "@material-ui/lab/Rating";

import PersonIcon from "@material-ui/icons/Person";
import AddIcon from "@material-ui/icons/Add";
import ListItemText from "@material-ui/core/ListItemText";

import { useStyles } from "./book-page.styles";
import { BookService } from "../../services";
import { useHistory, useParams } from "react-router";
import { PostsGrid } from "./components";
import { useFetch } from "hooks";
import { AuthContext } from "context";
import { ImageUtils } from "utils";

const API_BASE_URL = `https://localhost:5002/`;

type BookDetailsProps = {
  title: string;
  isbn: string;
  authors: string[];
  categories: string[];
  description: string;
  imagePath: string;
  published: string;
  publisher: string;
};

interface RouteParams {
  id: string;
}

const BookDetails = (props: any) => {
  const classes = useStyles();
  const [open, setOpen] = useState(false);
  const { user } = useContext(AuthContext);
  const history = useHistory();
  const { enqueueSnackbar } = useSnackbar();

  const {
    data: book,
    fetch: fetchBook,
    isLoading,
  } = useFetch(BookService.GetBookById);

  const { id: bookId } = useParams<RouteParams>();

  useEffect(() => {
    if (isNaN(Number(bookId))) {
      return;
    }

    fetchBook(Number(bookId));
    //eslint-disable-next-line
  }, [bookId]);

  const handleAddToWishlist = async () => {
    if (!user) {
      enqueueSnackbar("Please sign in first", { variant: "error" });
      return;
    }

    try {
      var result = await UserService.AddBookToWishlist(user.id, Number(bookId));
      enqueueSnackbar("Book Added To WishList", { variant: "success" });
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
    }
  };

  const handleAddToBookshelf = async () => {
    if (!user || !book) {
      enqueueSnackbar("Please sign in first", { variant: "error" });
      return;
    }

    history.push("/posts/add/" + book.id);
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (book == null) {
    return <p>Invalid book id</p>;
  }

  console.log(ImageUtils.getAbsolutePath(`${book.thumbnailPath}`));
  return (
    <Container>
      <Paper className={classes.bookPaper}>
        <Grid container spacing={4}>
          <Grid item className={classes.bookInfo} md={9}>
            <Typography
              variant="h5"
              component="h1"
              className={classes.bookTitle}
            >
              {book.title}
            </Typography>
            {book.details?.publishedYear && (
              <Typography>
                <b>Published:</b> {book.details?.publishedYear}
              </Typography>
            )}

            <Typography>
              <b>Authors:</b> {book.authors?.map((a) => a.name).join(", ")}
            </Typography>
            <Typography>
              <b>ISBN:</b> {book?.isbn}
            </Typography>
            {book.details?.publisher && (
              <Typography>
                <b>Publisher:</b> {book.details.publisher}
              </Typography>
            )}

            <Typography>
              <b>Description:</b> {book.details?.description}
            </Typography>
            <Grid container>
              <Grid item>
                <Box mt={3}>
                  <Button
                    variant="contained"
                    color="primary"
                    onClick={handleAddToWishlist}
                    className={classes.rightButton}
                  >
                    Add To Wishlist
                  </Button>
                </Box>
              </Grid>
              <Grid item>
                <Box mt={3}>
                  <Button
                    variant="outlined"
                    color="secondary"
                    onClick={handleAddToBookshelf}
                    className={classes.rightButton}
                  >
                    Add To Bookshelf
                  </Button>
                </Box>
              </Grid>
            </Grid>
          </Grid>
          <Grid item md={3}>
            <img
              src={ImageUtils.getAbsolutePath(`${book.thumbnailPath}`)}
              alt=""
              className={classes.bookCover}
            />
          </Grid>

          <Grid item xs={12}>
            <PostsGrid bookId={Number(bookId)} />
          </Grid>
        </Grid>
      </Paper>
    </Container>
  );
};

export { BookDetails };
