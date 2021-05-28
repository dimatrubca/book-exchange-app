import { Link, Typography } from "@material-ui/core";
import React from "react";
import { CardProps } from "../..";
import { Book } from "../../../../types";
import { SquareCardContainer } from "../../containers";

const BookSquareCard = ({
  cardItem: book,
  action,
  actionText,
}: CardProps<Book.Book>) => {
  return (
    <SquareCardContainer
      action={() => {
        action?.(book.id);
      }}
      actionText={actionText}
      imagePath={book.thumbnailPath}
    >
      <Typography gutterBottom variant="h5" component="h2">
        <Link
          href={"book/" + book.id}
          style={{ textDecoration: "none" }}
          color="inherit"
        >
          {book.title}
        </Link>
      </Typography>
      <Typography variant="subtitle1" color="textSecondary">
        by {book.authors?.map((a) => a.name).join(", ")}
      </Typography>
      <Typography>ISBN: {book.isbn}</Typography>
      <Typography>
        Categories: {book.categories?.map((c) => c.label).join(", ")}
      </Typography>
    </SquareCardContainer>
  );
};

export { BookSquareCard };
