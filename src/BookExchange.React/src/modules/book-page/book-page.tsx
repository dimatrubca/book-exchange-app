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
import { Divider } from "@material-ui/core";

import { useDemoData } from "@material-ui/x-grid-data-generator";
import Box from "@material-ui/core/Box";

import React, { useEffect, useState } from "react";
import PersonIcon from "@material-ui/icons/Person";
import AddIcon from "@material-ui/icons/Add";
import ListItemText from "@material-ui/core/ListItemText";

import { useStyles } from "./book-page.styles";
import { BookService } from "../../services";
import { useParams } from "react-router";
import { PostsGrid } from "./components";

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

export interface PostsDialogProps {
  open: boolean;
  selectedValue: string;
  posts: any;
  onClose: (value: string) => void;
}

const emails = ["username@gmail.com", "user02@gmail.com"];

const PostsDialog = (props: PostsDialogProps) => {
  const classes = useStyles();
  const { onClose, selectedValue, open } = props;

  const handleClose = () => {
    onClose(selectedValue);
  };

  const handleListItemClick = (value: string) => {
    onClose(value);
  };

  return (
    <Dialog
      onClose={handleClose}
      aria-labelledby="simple-dialog-title"
      open={open}
    >
      <DialogTitle id="simple-dialog-title">Book offers:</DialogTitle>
      <List>
        {props.posts &&
          props.posts.length &&
          props.posts.map((post: any) => (
            <ListItem
              button
              onClick={() => handleListItemClick(post)}
              key={post.id}
            >
              <ListItemAvatar>
                <Avatar className={classes.avatar}>
                  <PersonIcon />
                </Avatar>
              </ListItemAvatar>
              <ListItemText primary={post.id + " username"} />
              <ListItemText primary={"book condition"} />
              <Button>Send Request</Button>
            </ListItem>
          ))}
        {/* <ListItem
          autoFocus
          button
          onClick={() => handleListItemClick("addAccount")}
        >
          <ListItemAvatar>
            <Avatar>
              <AddIcon />
            </Avatar>
          </ListItemAvatar>
          <ListItemText primary="Add account" />
        </ListItem> */}
      </List>
    </Dialog>
  );
};

interface RouteParams {
  id: string;
}

const BookDetails = (props: any) => {
  const classes = useStyles();
  const [open, setOpen] = useState(false);
  const [selectedValue, setSelectedValue] = useState(emails[1]);
  const [posts, setPosts] = useState([]);

  const { data } = useDemoData({
    dataSet: "Commodity",
    rowLength: 100,
    maxColumns: 6,
  });
  const { id } = useParams<RouteParams>();
  console.log(id);

  useEffect(() => {
    let mounted = true;

    fetch(
      "https://localhost:44348/api/post?" +
        new URLSearchParams({
          bookId: id,
        })
    )
      .then((response) => {
        if (response.ok) {
          return response.json();
        }
        throw response;
      })
      .then((posts) => {
        if (mounted) {
          setPosts(posts);
        }
      })
      .catch((error) => console.log(error));

    return () => {
      mounted = false;
    };
  }, []);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = (value: string) => {
    setOpen(false);
    setSelectedValue(value);
  };

  return (
    <Container>
      <Paper className={classes.bookPaper}>
        <Grid container spacing={4}>
          <Grid item md={3}>
            <img
              src={
                "https://images-na.ssl-images-amazon.com/images/I/A1aDb5U5myL.jpg"
              }
              alt=""
              className={classes.bookCover}
            />
          </Grid>
          <Grid item className={classes.bookInfo} md={9}>
            <Typography
              variant="h5"
              component="h1"
              className={classes.bookTitle}
            >
              Essentialism: The Disciplined Pursuit of Less
            </Typography>
            <Typography>
              {/* <b>Authors:</b> {'props.authors.join(", ")'} */}
            </Typography>
            <Typography>
              <b>Published:</b> {"props.published"}
            </Typography>
            <Typography>
              <b>Author:</b> McKeown, Greg
            </Typography>
            <Typography>
              <b>ISBN:</b> 9780804137409
            </Typography>
            <Typography>
              <b>Publisher:</b> Lorem Ipsum
            </Typography>
            <Typography>
              <b>Description:</b> Lorem Ipsum is simply dummy text of the
              printing and typesetting industry. Lorem Ipsum has been the
              industry's standard dummy text ever since the 1500s, when an
              unknown printer took a galley of type and scrambled it to make a
              type specimen book. It has survived not only five centuries, but
              also the leap into electronic typesetting, remaining essentially
              unchanged. It was popularised in the 1960s with the release of
              Letraset sheets containing Lorem Ipsum passages, and more recently
              with desktop publishing software like Aldus PageMaker including
              versions of Lorem Ipsum.
            </Typography>
            <Box mt={3}>
              <Button
                variant="contained"
                color="primary"
                onClick={handleClickOpen}
                className={classes.rightButton}
              >
                Add To Wishlist
              </Button>
              <Button variant="contained" color="primary">
                Post
              </Button>
            </Box>
            <PostsDialog
              posts={posts}
              selectedValue={selectedValue}
              open={open}
              onClose={handleClose}
            />
          </Grid>
          <Grid item xs={12}>
            <PostsGrid />
          </Grid>
        </Grid>
      </Paper>
      );
    </Container>
  );
};

export { BookDetails };
