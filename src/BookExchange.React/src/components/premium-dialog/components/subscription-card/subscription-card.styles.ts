import React from "react";
import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    maxWidth: 250,
    textAlign: "center",
  },
  media: {
    height: 200,
  },
  subscriptionType: {
    backgroundColor: theme.palette.primary.light,
    padding: theme.spacing(2),
    textAlign: "center",
  },
}));

export { useStyles };
