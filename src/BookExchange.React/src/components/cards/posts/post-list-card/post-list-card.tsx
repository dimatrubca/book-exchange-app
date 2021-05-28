import React from "react";
import { CardProps } from "../..";
import { ListCardContainer } from "../../containers/list-card-container";
import { Post } from "../../../../types";
import { Typography } from "@material-ui/core";

const PostListCard = ({
  cardItem: post,
  action,
  actionText,
}: CardProps<Post.Post>) => {
  if (post == null) return <p>Not Loaded</p>;
  return (
    <ListCardContainer
      action={() => {
        action?.(post.id);
      }}
      actionText={actionText}
      imagePath={post.book?.thumbnailPath || ""}
    >
      <Typography component="h5" variant="h5">
        {post?.book?.title}
      </Typography>
      <Typography variant="subtitle1" color="textSecondary">
        by {post?.book?.authors?.map((a) => a.name).join(", ")}
      </Typography>
      <Typography>Condition: {post?.condition}</Typography>
      <Typography>
        Categories: {post.book?.categories?.map((c) => c.label).join(", ")}
      </Typography>
    </ListCardContainer>
  );
};

export { PostListCard };
