import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import IconButton from "@material-ui/core/IconButton";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import Typography from "@material-ui/core/Typography";

import { useStyles } from "./list-card-container.styles";
import { Button } from "@material-ui/core";
import { ImageUtils } from "utils";

interface ListCardProps {
  action?: () => void;
  actionText?: string;
  imagePath: string;
}

const ListCardContainer: React.FC<ListCardProps> = ({
  children,
  action,
  actionText,
  imagePath,
}) => {
  const classes = useStyles();
  return (
    <Card className={classes.root}>
      <div className={classes.details}>
        <CardContent className={classes.content}>{children}</CardContent>
        <div className={classes.controls}>
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
        </div>
      </div>
      <CardMedia
        className={classes.cover}
        image={ImageUtils.getAbsolutePath(imagePath).replaceAll("\\", "/")}
      />
    </Card>
  );
};

export { ListCardContainer };
