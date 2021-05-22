import React, { useEffect, useState } from "react";
import { Box, Typography, Paper } from "@material-ui/core";
import { useStyles } from "./wishlist-styles";
import { BookCard } from "../../../../components/book-card";
import { PaginatedView } from "components/paginated-view";
/*
const books: BookCardProps[] = [
  {
    id: 1,
    title: "Essentialism",
    authors: ["Greg McKeown"],
    categories: ["Self-help"],
    isbn: "9381723333123",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/41TVwg27ujL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 2,
    title: "War and Peace",
    authors: ["Leo Tolstoy"],
    categories: ["Novel"],
    isbn: "9780786112517",
    thumbnailPath: "https://images.penguinrandomhouse.com/cover/9781400079988",
  },
  {
    id: 3,
    title: "A Confession",
    authors: ["Leo Tolstoy"],
    categories: ["Novel", "Fiction"],
    isbn: "9788807900501",
    thumbnailPath:
      "https://images-na.ssl-images-amazon.com/images/I/51ZyeQWzSPL._SX331_BO1,204,203,200_.jpg",
  },
  {
    id: 4,
    title: "The Cossacks",
    authors: ["Greg McKeown"],
    categories: ["Novel", "Fiction", "Novella"],
    isbn: "9780786105236",
    thumbnailPath:
      "https://m.media-amazon.com/images/I/51zJRaQ-0ML._SL500_.jpg",
  },
];*/

const Wishlist = () => {
  //pagination view container
  const classes = useStyles();
  const [page, setPage] = useState<number>(2);
  const [rowsPerPage, setRowsPerPage] = useState<number>(10);
  const [totalRecords, setTotalRecords] = useState<number>(0);
  const [data, setData] = useState<Book.Book[]>();

  const fetchWishlist = () => {};

  return (
    <div>
      <Typography variant="h2" className={classes.contactInfoHeader}>
        Wishlist
      </Typography>

      <PaginatedView />
    </div>
  );
};

export { Wishlist };
