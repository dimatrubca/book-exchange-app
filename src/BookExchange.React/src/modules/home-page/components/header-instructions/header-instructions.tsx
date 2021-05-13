import { Grid, Typography, Container } from "@material-ui/core";
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
      <Grid container spacing={10}>
        <Grid item sm={4} className={classes.rightBorder}>
          <Typography variant="h4">SEARCH</Typography>
          <Typography className="instruction-text" variant="body1">
            30+ buyback vendors
          </Typography>
        </Grid>
        <Grid item sm={4} className={classes.rightBorder}>
          <Typography className="instruction-title" variant="h4">
            SEARCH
          </Typography>
          <Typography className="instruction-text" variant="body1">
            30+ buyback vendors
          </Typography>
        </Grid>
        <Grid item sm={4}>
          <Typography className="instruction-title" variant="h4">
            SEARCH
          </Typography>
          <Typography className="instruction-text" variant="body1">
            30+ buyback vendors
          </Typography>
        </Grid>
      </Grid>
    </Container>
  );
};

export { HeaderInstructions };
