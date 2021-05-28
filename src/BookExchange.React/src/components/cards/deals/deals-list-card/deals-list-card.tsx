import { Typography } from "@material-ui/core";
import React from "react";
import { CardProps } from "../..";
import { Deal } from "../../../../types";
import { ListCardContainer } from "./../../containers";

const DealsListCard = ({
  cardItem: deal,
  action,
  actionText,
}: CardProps<Deal.Deal>) => {
  return (
    <ListCardContainer
      action={() => {
        action?.(deal.id);
      }}
      actionText={actionText}
      imagePath={deal?.post?.book?.thumbnailPath || ""}
    >
      <Typography component="h5" variant="h5">
        {deal?.post?.book?.title}
      </Typography>
      <Typography variant="subtitle1" color="textSecondary">
        Book Condition: {deal?.post?.condition}
      </Typography>
      <Typography>Deal Status: {deal.dealStatus}</Typography>
      <Typography>Book Giver: {deal?.post?.postedBy?.username}</Typography>
      <Typography>Book Taker: {deal?.bookTaker?.username}</Typography>
    </ListCardContainer>
  );
};

export { DealsListCard };
