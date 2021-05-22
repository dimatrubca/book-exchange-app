import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  form: {
    width: "100%",
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  btnChoose: {
    marginBottom: theme.spacing(1),
    marginRight: theme.spacing(2),
  },
  fileName: {
    marginBottom: theme.spacing(2),
  },
}));
export { useStyles };
