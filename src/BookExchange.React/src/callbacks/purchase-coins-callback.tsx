import React, { useContext, useEffect, useState } from "react";
import { Container, Typography } from "@material-ui/core";
import { useLocation } from "react-router-dom";
import { useSnackbar } from "notistack";
import { useHistory } from "react-router";

import { PaymentService } from "../services";
import { AuthContext } from "context";

function useQuery() {
  return new URLSearchParams(useLocation().search);
}

const PurchaseCoinsCallback = (props: any) => {
  const [message, setMessage] = useState<string>("Processing payment...");
  const { enqueueSnackbar } = useSnackbar();
  const history = useHistory();
  const authContext = useContext(AuthContext);

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
        enqueueSnackbar("Successful payment", { variant: "success" });
        await authContext.fetchCurrentUser();
      } catch (e) {
        console.log(e);
      }
      history.push("/profile");
    };

    finishPayment();
  }, []);

  console.log("Inside finish callback");

  return (
    <Container>
      <Typography>{message}...</Typography>
    </Container>
  );
};

export { PurchaseCoinsCallback };
