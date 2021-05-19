import { makeStyles } from "@material-ui/core";
import purple from "@material-ui/core/colors/purple";

const useStyles = makeStyles((theme) => ({
  filterIconsContainer: {
    marginTop: theme.spacing(1),
    marginBottom: theme.spacing(1),
    color: theme.palette.primary.main,
  },

  filterIcon: {
    paddingLeft: theme.spacing(2),
  },
}));

export { useStyles };
