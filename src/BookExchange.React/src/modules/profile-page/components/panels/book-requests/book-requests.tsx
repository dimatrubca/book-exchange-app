import React, { useState } from "react";
import { useSnackbar } from "notistack";
import { useHistory } from "react-router";

import { PaginatedView } from "components/paginated-view";
import { RequestListCard } from "components/cards";
import { RequestService, UserService } from "services";
import { PanelProps } from "./../";

const BookRequestsPanel = ({ index, displayIndex }: PanelProps) => {
  const { enqueueSnackbar } = useSnackbar();
  const [updateComponent, setUpdateComponent] = useState<number>(0);
  const history = useHistory();

  const approveRequest = async (requestId: number) => {
    try {
      await RequestService.AcceptRequest(requestId);
      enqueueSnackbar("Request approved successfully! Book awaiting delivery", {
        variant: "success",
      });
      setUpdateComponent(Math.random());
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
    }
  };
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requests"
        listCard={RequestListCard}
        squareCard={RequestListCard}
        service={UserService.GetRequestsToUser}
        cardAction={approveRequest}
        cardActionText="Aprove"
      />
    </div>
  );
};

export { BookRequestsPanel };
