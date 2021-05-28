import React from "react";

import { RequestListCard } from "components/cards";
import { PaginatedView } from "components/paginated-view";
import { RequestService, UserService } from "services";
import { useSnackbar } from "notistack";

interface RequestedBooksProps {
  index: number;
  displayIndex: number;
}

const RequestedBooksPanel = ({ index, displayIndex }: RequestedBooksProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requested Books"
        listCard={RequestListCard}
        squareCard={RequestListCard}
        service={UserService.GetRequestsFromUser}
      />
    </div>
  );
};

export { RequestedBooksPanel };
