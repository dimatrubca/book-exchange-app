import React from "react";
import { Container, Paper, Typography, Box } from "@material-ui/core";
import bookImage from "images/Books-Upstairs.jpg";
import book2 from "images/book2.png";
import book6 from "images/book6.png";
import Image from "material-ui-image";

import { useStyles } from "./home-page-styles";
import { HeaderInstructions } from "./components";
import { classicNameResolver } from "typescript";

const HomePage = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      {/* <Paper variant="outlined">
        <img src={book6} style={{ width: "100%" }} />
      </Paper> */}
      <div>
        <img src={book6} className={classes.topImage} />
      </div>
      <HeaderInstructions />
      <Container>
        <Paper>
          <Typography variant="h2">Why use BookExchange?</Typography>
          <Typography variant="body1">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis,
            minus tempora ullam alias iure dolorum? Nesciunt eos ex ratione,
            harum ab omnis officiis voluptas minima obcaecati consequuntur et
            laborum in!
          </Typography>
        </Paper>
      </Container>
      <Container>
        <Typography variant="h2">Recently swapped books</Typography>
      </Container>
      <Container>
        <Typography variant="h2">Top Users</Typography>
      </Container>
      <Container>
        <Typography variant="h2">Top Users</Typography>
      </Container>
    </div>
  );
};

export { HomePage };
