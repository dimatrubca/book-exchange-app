import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import { useStyles } from "./square-card-container.styles";
import { ImageUtils } from "utils";

interface SquareCardContainerProps {
  action?: () => void;
  actionText?: string;
  imagePath: string | undefined;
}

const SquareCardContainer: React.FC<SquareCardContainerProps> = ({
  action,
  actionText,
  imagePath,
  children,
}) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <CardActionArea>
        {imagePath && (
          <CardMedia
            className={classes.media}
            image={ImageUtils.getAbsolutePath(imagePath)}
            title="Contemplative Reptile"
          />
        )}

        <CardContent className={classes.cardContent}>{children}</CardContent>
      </CardActionArea>
      <CardActions>
        {action && actionText && (
          <Button
            variant="outlined"
            color="secondary"
            size="small"
            onClick={action}
          >
            {actionText}
          </Button>
        )}
      </CardActions>
    </Card>
  );
};

export { SquareCardContainer };
