import { createStyles, makeStyles, Theme } from "@material-ui/core";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      padding: theme.spacing(2),
    },
    statisticsItem: {
      alignSelf: "center",
    },
  })
);

export { useStyles };
