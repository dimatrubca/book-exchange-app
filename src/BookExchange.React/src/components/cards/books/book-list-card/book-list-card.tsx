import React from "react";
import { Link, Typography } from "@material-ui/core";

import { CardProps } from "../..";
import { Book } from "../../../../types";
import { ListCardContainer } from "./../../containers";
import { ImageUtils } from "utils";

const BookListCard = ({
  cardItem: book,
  action,
  actionText,
}: CardProps<Book.Book>) => {
  console.log("Book: ", book);
  console.log(book.thumbnailPath);
  return (
    <ListCardContainer
      action={() => {
        action?.(book.id);
      }}
      actionText={actionText}
      imagePath={`${book.thumbnailPath}`}
    >
      <Typography component="h5" variant="h5">
        <Link
          href={"book/" + book.id}
          style={{ textDecoration: "none" }}
          color="inherit"
        >
          {book.title}
        </Link>
      </Typography>
      {book.authors?.length !== 0 && (
        <Typography variant="subtitle1" color="textSecondary">
          by {book.authors.map((a) => a.name).join(", ")}
        </Typography>
      )}

      <Typography>ISBN: {book.isbn}</Typography>
      {book.categories.length !== 0 && (
        <Typography>
          Categories: {book.categories?.map((c) => c.label).join(", ")}
        </Typography>
      )}
    </ListCardContainer>
  );
};

export { BookListCard };
