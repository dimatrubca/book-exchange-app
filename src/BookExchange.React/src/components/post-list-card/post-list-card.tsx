import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import Typography from "@material-ui/core/Typography";
import HighlightOffIcon from "@material-ui/icons/HighlightOff";
import CancelOutlinedIcon from "@material-ui/icons/CancelOutlined";
import { useStyles } from "./post-list-card.styles";
import { Post } from "types";
import { Button, Tooltip } from "@material-ui/core";

// id: number;
// title: string;
// authors: string[];
// categories: string[];
// isbn: string;
// thumbnailPath?: string;

interface CardProps<T> {
  actionText: string | null;
  action: any;
}

const PostListCard = (post: Post.Post) => {
  const classes = useStyles();
  console.log("thumbnail:", post.book?.thumbnailPath);
  return (
    <Card className={classes.root}>
      <div className={classes.details}>
        <CardContent className={classes.content}>
          <Typography component="h5" variant="h5">
            {post.book?.title}
          </Typography>
          <Typography variant="subtitle1" color="textSecondary">
            Owner: {post.postedBy?.username}
          </Typography>
          <Typography>ISBN: {post.book?.isbn}</Typography>
          <Typography>
            Categories: {post.book?.categories?.map((c) => c.label).join(", ")}
          </Typography>
          <Typography>Condition: {post.condition}</Typography>
        </CardContent>
        <div className={classes.controls}>
          <Button size="small" variant="outlined" color="secondary">
            Cancel
          </Button>
          {/* <Tooltip title="Cancel" aria-label="cancel">
            <IconButton aria-label="play/pause">
              <CancelOutlinedIcon className={classes.playIcon} />
            </IconButton>
          </Tooltip> */}
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

export { PostListCard };
