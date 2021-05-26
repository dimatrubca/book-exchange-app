import React, { useEffect } from "react";
import { Container, Typography } from "@material-ui/core";

import { PaymentService } from "../services";

const PurchaseCoinsCallback = (props: any) => {
  useEffect(() => {
    const cancelPayment = async () => {
      try {
        const result = PaymentService.CancelPayment();
        console.log("result", result);
      } catch (e) {
        console.log(e);
        // redirect to profile page
      }
    };

    cancelPayment();
  }, []);

  return (
    <Container>
      <Typography>Processing payment...</Typography>
    </Container>
  );
};

export { PurchaseCoinsCallback };
