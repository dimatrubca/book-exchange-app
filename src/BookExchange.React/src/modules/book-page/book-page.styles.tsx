import { createStyles, makeStyles } from "@material-ui/core";
import { blue } from "@material-ui/core/colors";
import { TheatersTwoTone } from "@material-ui/icons";

const useStyles = makeStyles((theme) =>
  createStyles({
    bookPaper: {
      padding: theme.spacing(4),
      paddingLeft: theme.spacing(2),
    },
    bookCover: {
      width: "100%",
    },
    avatar: {
      backgroundColor: blue[100],
      color: blue[600],
    },
    bookInfo: {},
    bookTitle: {
      paddingBottom: theme.spacing(1),
    },
    rightButton: {
      marginRight: theme.spacing(2),
    },
  })
);

export { useStyles };
