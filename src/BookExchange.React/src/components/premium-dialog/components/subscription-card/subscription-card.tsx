import React from "react";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import { useStyles } from "./subscription-card.styles";
import { List } from "material-ui-icons";
import { ListItem, ListItemText } from "@material-ui/core";

interface SubscriptionCardProps {}

const SubscriptionCard = (props: SubscriptionCardProps) => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <CardActionArea>
        <div className={classes.subscriptionType}>
          <Typography variant="h5">Free</Typography>
        </div>
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            0$ / month
          </Typography>
          <Typography variant="body1">
            Up to <b>20</b> book requests
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary" variant="outlined">
          Choose
        </Button>
      </CardActions>
    </Card>
  );
};

export { SubscriptionCard };
