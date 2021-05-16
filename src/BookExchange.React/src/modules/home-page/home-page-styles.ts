import { createStyles, makeStyles } from "@material-ui/core";
import { blue } from "@material-ui/core/colors";

const useStyles = makeStyles(() =>
  createStyles({
    root: {
      zIndex: -100,
      position: "relative",
      width: "100%",
    },
    topImage: {
      width: "100%",
    },
    aboutContainer: {
      backgroundColor: "#696969",
    },
  })
);

export { useStyles };
