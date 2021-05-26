import React from "react";
import Button from "@material-ui/core/Button";
import Avatar from "@material-ui/core/Avatar";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemAvatar from "@material-ui/core/ListItemAvatar";
import ListItemText from "@material-ui/core/ListItemText";
import DialogTitle from "@material-ui/core/DialogTitle";
import Dialog from "@material-ui/core/Dialog";
import PersonIcon from "@material-ui/icons/Person";
import AddIcon from "@material-ui/icons/Add";
import Typography from "@material-ui/core/Typography";

import { useStyles } from "./premium-dialog.styles";
import { SubscriptionCard } from "./components";
import { Container, DialogContent, Grid } from "@material-ui/core";

interface PremiumDialogProps {
  open: boolean;
  onClose: () => void;
}

const PremiumDialog = (props: PremiumDialogProps) => {
  const classes = useStyles();
  const { onClose, open } = props;

  const handleClose = () => {
    onClose();
  };

  const handleListItemClick = () => {
    onClose();
  };
  return (
    <Dialog
      onClose={handleClose}
      aria-labelledby="simple-dialog-title"
      open={open}
      className={classes.root}
    >
      <DialogTitle id="simple-dialog-title">Choose your plan</DialogTitle>
      <DialogContent>
        <Grid container spacing={4}>
          <Grid item xs={4}>
            <SubscriptionCard />
          </Grid>
          <Grid item xs={4}>
            <SubscriptionCard />
          </Grid>
          <Grid item xs={4}>
            <SubscriptionCard />
          </Grid>
        </Grid>
      </DialogContent>
    </Dialog>
  );
};

export { PremiumDialog };
