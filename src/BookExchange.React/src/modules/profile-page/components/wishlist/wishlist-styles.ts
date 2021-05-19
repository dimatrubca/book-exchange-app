import { createStyles, makeStyles, Theme } from "@material-ui/core";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    contactInfoHeader: {
      marginBottom: theme.spacing(1),
    },
  })
);

export { useStyles };
