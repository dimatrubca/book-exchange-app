import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiTextField-root": {
      marginBottom: theme.spacing(1),
    },
  },
  pageTitle: {
    marginBottom: theme.spacing(2),
  },
  subTitle: {
    marginBottom: theme.spacing(1),
  },

  button: {
    marginBottom: theme.spacing(5),
  },
}));

export { useStyles };
