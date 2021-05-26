import React, { useEffect, useState } from "react";
import { Container, Typography } from "@material-ui/core";
import { useLocation } from "react-router-dom";

import { PaymentService } from "../services";

function useQuery() {
  return new URLSearchParams(useLocation().search);
}

const PurchaseCoinsCallback = (props: any) => {
  const [message, setMessage] = useState<string>("Processing payment...");
  let query = useQuery();

  useEffect(() => {
    const finishPayment = async () => {
      console.log("query: ", query);
      const payerId = query.get("PayerID") || "";
      const paymentId = query.get("paymentId") || "";

      console.log(payerId, paymentId);

      try {
        const result = await PaymentService.FinishSinglePayment(
          payerId,
          paymentId
        );
        console.log("result", result);
      } catch (e) {
        console.log(e);
        // redirect to profile page
      }
    };

    finishPayment();
  }, []);

  console.log("Inside finish callback");

  return (
    <Container>
      <Typography>{message}...</Typography>
      <Typography>...</Typography>
    </Container>
  );
};

export { PurchaseCoinsCallback };
