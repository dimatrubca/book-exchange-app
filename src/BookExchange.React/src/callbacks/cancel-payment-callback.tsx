import React, { useEffect } from "react";
import { Container, Typography } from "@material-ui/core";

import { PaymentService } from "../services";
import { useSnackbar } from "notistack";
import { useHistory } from "react-router";

const CancelPaymentCallback = (props: any) => {
  const { enqueueSnackbar } = useSnackbar();
  const history = useHistory();

  useEffect(() => {
    const cancelPayment = async () => {
      try {
        const result = await PaymentService.CancelPayment();
        enqueueSnackbar("Payment was canceled", { variant: "success" });
      } catch (e) {
        console.log(e);
      }
      history.push("/profile");
    };

    cancelPayment();
  }, []);

  return (
    <Container>
      <Typography>Processing payment...</Typography>
    </Container>
  );
};

export { CancelPaymentCallback };
