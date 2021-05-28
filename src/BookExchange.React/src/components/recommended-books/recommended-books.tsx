import { Box, Typography } from "@material-ui/core";
import { AuthContext } from "context";
import { useFetch } from "hooks";
import React, { useContext, useEffect } from "react";
import { UserService } from "services";
import { useStyles } from "./recommended-books.styles";
import { BookListCard } from "components/cards";

const RecommendedBooks = () => {
  const classes = useStyles();
  const { user } = useContext(AuthContext);

  const {
    data: books,
    fetch: fetchBook,
    isLoading,
  } = useFetch(UserService.GetRecommendedBooks);

  useEffect(() => {
    console.log(user);
    if (!user) {
      return;
    }

    fetchBook(user.id);
  }, [user, fetchBook]);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (!user) {
    return <></>;
  }

  return (
    <div className={classes.root}>
      <Typography variant="h5">Books you may like</Typography>
      {books?.map((book, index) => (
        <Box my={4} key={index}>
          <BookListCard cardItem={book} />
        </Box>
      ))}
    </div>
  );
};

export { RecommendedBooks };
