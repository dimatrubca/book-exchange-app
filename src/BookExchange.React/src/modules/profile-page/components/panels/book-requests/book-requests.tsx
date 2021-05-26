import React from "react";

import { PaginatedView } from "components/paginated-view";
import { PostListCard } from "components/post-list-card";
import { BookMediaCard } from "components/book-media-card";
import { UserService } from "services";
import { PanelProps } from "./../";

const BookRequestsPanel = ({ index, displayIndex }: PanelProps) => {
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

export { BookRequestsPanel };
