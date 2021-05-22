import { Container, Grid, Paper } from "@material-ui/core";
import React from "react";
import { useStyles } from "./paper-container.styles";

interface PaperContainerProps {
  children: React.ReactNode;
}

const PaperContainer = (props: PaperContainerProps) => {
  const classes = useStyles();

  return (
    <Container>
      <Paper className={classes.paper}>{props.children}</Paper>
    </Container>
  );
};

export { PaperContainer };
