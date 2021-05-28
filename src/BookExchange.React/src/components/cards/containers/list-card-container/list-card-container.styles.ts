import { createStyles, makeStyles, Theme } from "@material-ui/core";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      display: "flex",
      justifyContent: "space-between",
      minHeight: 200,
    },
    details: {
      display: "flex",
      flexDirection: "column",
    },
    content: {
      flex: "1 0 auto",
    },
    cover: {
      width: 150,
    },
    controls: {
      display: "flex",
      alignItems: "center",
      paddingLeft: theme.spacing(2),
      paddingBottom: theme.spacing(1),
    },
  })
);

export { useStyles };
