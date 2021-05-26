import { createStyles, makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() =>
  createStyles({
    rightBorder: {
      borderRight: "1px dashed #d9d9d9",
    },
    root: {
      backgroundColor: "#f7f9ff",
      // textAlign: "center",
    },
  })
);

export { useStyles };
