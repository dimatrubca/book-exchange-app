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

import { useStyles } from "./purchase-coints.styles";
import { Container, DialogContent, Grid } from "@material-ui/core";

import { PaymentService } from "services";

interface PurchaseCoinsDialogProps {
  open: boolean;
  onClose: () => void;
}

const PurchaseCoinsDialog = (props: PurchaseCoinsDialogProps) => {
  const classes = useStyles();
  const { onClose, open } = props;

  const handleClose = () => {
    onClose();
  };

  const handleBuyCoinsClick = async () => {
    try {
      var result = await PaymentService.SinglePayment();
      window.location.replace(result.url); // checkalternatives
    } catch (e) {
      console.log(e);
    }
  };

  return (
    <Dialog
      onClose={handleClose}
      aria-labelledby="simple-dialog-title"
      open={open}
      className={classes.root}
    >
      <DialogTitle id="simple-dialog-title">1 book coin = 0.5$</DialogTitle>
      <DialogContent>
        <Button
          color="primary"
          variant="contained"
          onClick={handleBuyCoinsClick}
        >
          Buy
        </Button>
      </DialogContent>
    </Dialog>
  );
};

export { PurchaseCoinsDialog };
