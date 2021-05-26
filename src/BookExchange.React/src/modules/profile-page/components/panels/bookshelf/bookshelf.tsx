import React from "react";

import { PaginatedView } from "components/paginated-view";
import { PostListCard } from "components/post-list-card";
import { UserService } from "services";
import { PanelProps } from "./../";

const BookShelfPanel = ({ index, displayIndex }: PanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requested Books"
        listCard={PostListCard}
        squareCard={PostListCard}
        service={UserService.GetPostRequests}
      />
    </div>
  );
};

export { BookShelfPanel };
