import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    "&>*": {
      marginBottom: theme.spacing(2),
    },
    minWidth: "300px",
  },
}));

export { useStyles };
