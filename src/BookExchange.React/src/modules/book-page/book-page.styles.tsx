import { createStyles, makeStyles } from "@material-ui/core";
import { blue } from "@material-ui/core/colors";

const useStyles = makeStyles( () => 
    createStyles({
        bookCover: {
            width: "100%"
        },
        avatar: {
            backgroundColor: blue[100],
            color: blue[600],
        }
    })
);


export { useStyles }
