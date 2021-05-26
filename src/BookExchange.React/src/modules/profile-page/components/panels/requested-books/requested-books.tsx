import React from "react";

import { PaginatedView } from "components/paginated-view";
import { PostListCard } from "components/post-list-card";
import { UserService } from "services";

interface RequestedBooksProps {
  index: number;
  displayIndex: number;
}

const RequestedBooksPanel = ({ index, displayIndex }: RequestedBooksProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Requested Books"
        listCard={PostListCard}
        squareCard={PostListCard}
        service={UserService.GetRequestedPosts}
      />
    </div>
  );
};

export { RequestedBooksPanel };
