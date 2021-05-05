import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() => ({
    header: {
        // backgroundColor: "#400CCC",
        paddingRight: "79px",
        paddingLeft: "85px",

        "@media (max-width: 900px)": {
            paddingLeft: 0,
          },
      },

    logo: {
        fontFamily: 'Open Sans',
    },

    menuButton: {
        fontFamily: "Open Sans, sans-serif",
        fontWeight: 700,
        size: "18px",
        marginLeft: "38px",
     },

     toolbar: {
        display: "flex",
        justifyContent: "space-between",
      },
}));

export { useStyles }