import { fetchApi } from "./fetchApi";
import { Deal } from "types";

const ConfirmDelivery = async (id: number, pageSize: number, page: number) => {
  const requestOptions = {
    method: "PATCH",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    data: JSON.stringify({ DealStatus: "Delivered" }),
    credentials: "include",
  };

  return fetchApi<Deal.Deal>(`/deal`, requestOptions);
};

const DealService = {
  ConfirmDelivery,
};

export { DealService };
