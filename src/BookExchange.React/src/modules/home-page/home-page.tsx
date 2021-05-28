import React from "react";
import { Container, Paper, Typography, Box } from "@material-ui/core";
import bookImage from "images/Books-Upstairs.jpg";
import book2 from "images/book2.png";
import book6 from "images/book6.png";
import Image from "material-ui-image";

import { useStyles } from "./home-page-styles";
import { HeaderInstructions } from "./components";
import { Leaderboard } from "components/leaderboard";
import { classicNameResolver } from "typescript";
import { RecommendedBooks } from "components/recommended-books";

const HomePage = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      {/* <Paper variant="outlined">
        <img src={book6} style={{ width: "100%" }} />
      </Paper> */}
      <Box mb={10}>
        <Container>
          <Paper>
            <img src={book6} className={classes.topImage} />
          </Paper>
        </Container>
      </Box>

      <Box my={10}>
        <HeaderInstructions />
      </Box>

      <Box my={2}>
        <Container>
          <Paper>
            <Leaderboard />
          </Paper>
        </Container>
      </Box>

      <Box my={2}>
        <Container>
          <RecommendedBooks />
        </Container>
      </Box>

      <Box my={3}>
        <Container>
          <Paper>
            <Typography variant="h2">About Us</Typography>
            <Typography variant="body1">
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis,
              minus tempora ullam alias iure dolorum? Nesciunt eos ex ratione,
              harum ab omnis officiis voluptas minima obcaecati consequuntur et
              laborum in!
            </Typography>
          </Paper>
        </Container>
      </Box>
    </div>
  );
};

export { HomePage };
