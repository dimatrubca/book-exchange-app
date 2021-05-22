import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  title: {
    marginBottom: theme.spacing(2),
  },

  flexContainer: {
    display: "flex",
    justifyContent: "space-between",
    flexFlow: "wrap",
  },

  postForm: {
    "&>*": {
      marginBottom: theme.spacing(2),
    },
  },

  bookCard: {
    display: "flex",
  },

  bookTitle: {
    color: theme.palette.secondary.main,
    marginBottom: theme.spacing(1),
  },
  bookCover: {
    width: "200",
    marginRight: theme.spacing(3),
  },
  bookDetails: {},
}));

export { useStyles };
