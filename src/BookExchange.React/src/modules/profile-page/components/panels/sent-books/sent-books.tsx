import React from "react";
import { DealsListCard } from "components/cards";

import { UserService } from "services";
import { PanelProps } from "./../";
import { PaginatedView } from "components/paginated-view";

const SentBooksPanel = ({ index, displayIndex }: PanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Sent Books"
        listCard={DealsListCard}
        squareCard={DealsListCard}
        service={UserService.GetDealsFromUser}
      />
    </div>
    //todo: change to post card
  );
};

export { SentBooksPanel };
