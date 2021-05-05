import React from "react";
import Dialog from "@material-ui/core/Dialog";
import { SignUpForm } from "../sign-up-form";

const ModalDialog = ({ open, handleClose }: any) => {
  return (
    // props received from App.js
    <Dialog open={open} onClose={handleClose}>
      {/* // form to be created */}
      <SignUpForm handleClose={handleClose} />
    </Dialog>
  );
};

export { ModalDialog };
