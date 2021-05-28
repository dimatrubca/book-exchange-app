import { fetchApi } from "./fetchApi";
import { Payment } from "types";

const FinishSinglePayment = (payerId: string, paymentId: string) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      payerId: payerId,
      paymentId: paymentId,
    }),
  };

  return fetchApi(`/payment/finish-payment`, requestOptions);
};

const CancelPayment = () => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  };
  return fetchApi(`/payment/cancel`, requestOptions);
};

const SinglePayment = (userId: number, amount: number) => {
  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      userId: userId,
      amount: amount,
    }),
  };

  return fetchApi<Payment.ApprovePayment>(
    "/payment/singlePayment",
    requestOptions
  );
};

const PaymentService = {
  SinglePayment,
  FinishSinglePayment,
  CancelPayment,
};

export { PaymentService };
