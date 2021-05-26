import { Grid, Typography, Container, Paper } from "@material-ui/core";
import React from "react";
import { useStyles } from "./header-instructions.styles";
import { InstructionItem, InstructionItemProps } from "./instruction-item";

const instructionsData: InstructionItemProps[] = [
  {
    instructionTitle: "SEARCH",
    instructionText: "30+ buyback vendors",
  },
  {
    instructionTitle: "SEARCH",
    instructionText: "30+ buyback vendors",
  },
  {
    instructionTitle: "SEARCH",
    instructionText: "30+ buyback vendors",
  },
];

const HeaderInstructions = () => {
  const classes = useStyles();

  return (
    <Container>
      <Paper className={classes.root}>
        <Grid container spacing={5} justify="center" alignItems="center">
          <Grid item sm={3} className={classes.rightBorder}>
            <Typography variant="h4">Post Books</Typography>
            <Typography className="instruction-text" variant="body1">
              Books you want to exchange
            </Typography>
          </Grid>
          <Grid item sm={3} className={classes.rightBorder}>
            <Typography className="instruction-title" variant="h4">
              Earn Points
            </Typography>
            <Typography className="instruction-text" variant="body1">
              +1 point for each book you give away
            </Typography>
          </Grid>
          <Grid item sm={3}>
            <Typography className="instruction-title" variant="h4">
              Request Books
            </Typography>
            <Typography className="instruction-text" variant="body1">
              100+ posted books
            </Typography>
          </Grid>
        </Grid>
      </Paper>
    </Container>
  );
};

export { HeaderInstructions };
