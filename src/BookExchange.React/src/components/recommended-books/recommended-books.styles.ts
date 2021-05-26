import React from "react";
import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(2),
  },

  title: {
    marginLeft: theme.spacing(2.5),
    marginBottom: theme.spacing(3),
  },
  header: {
    paddingLeft: theme.spacing(2.5),
    paddingRight: theme.spacing(2.5),
    paddingBottom: theme.spacing(1),
  },
}));
export { useStyles };
