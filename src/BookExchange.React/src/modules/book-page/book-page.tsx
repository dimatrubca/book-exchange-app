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
  Typography,
} from "@material-ui/core";
import { DataGrid } from "@material-ui/data-grid";
import { useDemoData } from "@material-ui/x-grid-data-generator";

import React, { useEffect, useState } from "react";
import PersonIcon from "@material-ui/icons/Person";
import AddIcon from "@material-ui/icons/Add";
import ListItemText from "@material-ui/core/ListItemText";

import { useStyles } from "./book-page.styles";
import { BookService } from "../../services";
import { useParams } from "react-router";

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
      {console.log(posts)}
      <div>
        <Grid container spacing={10}>
          <Grid item md={3}>
            <img src={"props.imagePath"} alt="" className={classes.bookCover} />
          </Grid>
          <Grid item md={9}>
            <Typography variant="h5">{"props.title"}</Typography>
            <Typography>
              {/* <b>Authors:</b> {'props.authors.join(", ")'} */}
            </Typography>
            <Typography>
              <b>Published:</b> {"props.published"}
            </Typography>
            <Typography>
              <b>Publisher:</b> {"props.publisher"}
            </Typography>
            <Typography>
              <b>ISBN:</b> {"props.isbn"}
            </Typography>

            <Button
              variant="contained"
              color="primary"
              onClick={handleClickOpen}
            >
              Request
            </Button>
            <br />
            <br />
            <Button variant="contained" color="primary">
              Post
            </Button>
            <PostsDialog
              posts={posts}
              selectedValue={selectedValue}
              open={open}
              onClose={handleClose}
            />
          </Grid>
        </Grid>
      </div>
      <div style={{ height: 400, width: "100%" }}>
        <DataGrid
          {...data}
          filterModel={{
            items: [
              {
                columnField: "commodity",
                operatorValue: "contains",
                value: "rice",
              },
            ],
          }}
        />
      </div>
      );
    </Container>
  );
};

export { BookDetails };
