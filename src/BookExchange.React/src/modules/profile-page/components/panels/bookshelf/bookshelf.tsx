import React from "react";

import { PaginatedView } from "components/paginated-view";
import { PostListCard, PostSquareCard } from "components/cards";
import { UserService } from "services";
import { PanelProps } from "./../";

const BookShelfPanel = ({ index, displayIndex }: PanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requested Books"
        listCard={PostListCard}
        squareCard={PostSquareCard}
        service={UserService.GetUserBookshelf}
      />
    </div>
  );
};

export { BookShelfPanel };
