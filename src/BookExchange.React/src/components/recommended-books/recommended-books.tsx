import { Typography } from "@material-ui/core";
import React from "react";
import { useStyles } from "./recommended-books.styles";

const RecommendedBooks = () => {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Typography variant="h5">Books you may like</Typography>
      {/* square cards */}
    </div>
  );
};

export { RecommendedBooks };
