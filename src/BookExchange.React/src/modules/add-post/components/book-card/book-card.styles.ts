import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    display: "flex",
  },

  bookTitle: {
    color: theme.palette.secondary.main,
    marginBottom: theme.spacing(1),
  },
  bookCover: {
    maxWidth: 200,
    maxHeight: 300,
    marginRight: theme.spacing(3),
  },
  bookDetails: {},
}));

export { useStyles };
