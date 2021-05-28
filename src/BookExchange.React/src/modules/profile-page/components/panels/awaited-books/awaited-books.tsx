import React from "react";

import { PaginatedView } from "components/paginated-view";
import { DealsListCard } from "components/cards";
import { UserService } from "services";
import { PanelProps } from "./../";

const AwaitedBooksPanel = ({ index, displayIndex }: PanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requested Books"
        listCard={DealsListCard}
        squareCard={DealsListCard}
        service={UserService.GetDealsToUser}
      />
    </div>
  );
};

export { AwaitedBooksPanel };
