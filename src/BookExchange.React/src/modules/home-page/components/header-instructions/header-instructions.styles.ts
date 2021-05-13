import { createStyles, makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() =>
  createStyles({
    rightBorder: {
      borderRight: "1px solid black",
    },
  })
);

export { useStyles };
