import React from "react";
import { Grid, Typography } from "@material-ui/core";

export type InstructionItemProps = {
  instructionTitle: string;
  instructionText: string;
};

const InstructionItem = (props: InstructionItemProps) => {
  return (
    <>
      {console.log("inside item", props)}
      <Grid item sm={4}>
        <Typography className="instruction-title" variant="h4">
          {props.instructionTitle}1
        </Typography>
        <Typography className="instruction-text" variant="body1">
          {props.instructionText}1
        </Typography>
      </Grid>
    </>
  );
};

export { InstructionItem };
