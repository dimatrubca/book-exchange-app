import React from "react";
import { CardProps } from "../..";
import { Post } from "../../../../types";
import { SquareCardContainer } from "../../containers/square-card-container";

const PostSquareCard = ({
  cardItem: post,
  action,
  actionText,
}: CardProps<Post.Post>) => {
  return (
    <SquareCardContainer
      action={() => {
        action?.(post.id);
      }}
      actionText={actionText}
      imagePath={post.book?.thumbnailPath}
    >
      body
    </SquareCardContainer>
  );
};

export { PostSquareCard };
