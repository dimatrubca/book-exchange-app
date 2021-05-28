import { fetchApi } from "./fetchApi";
import { Request } from "types";

const AcceptRequest = async (id: number) => {
  const requestOptions = {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ Status: "Approved" }),
  };

  return fetchApi<Request.Request>(`/request/${id}`, requestOptions);
};

const RejectRequest = async (id: number) => {
  const requestOptions = {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ Status: "Rejected" }),
  };

  return fetchApi<Request.Request>(`/request/${id}`, requestOptions);
};

const RequestService = {
  AcceptRequest,
  RejectRequest,
};

export { RequestService };
