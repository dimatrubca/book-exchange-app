import { PaginatedView } from "components/paginated-view";
import React from "react";
import { PostListCard } from "components/post-list-card";
import { BookMediaCard } from "components/book-media-card";
import { UserService } from "services";
import { PanelProps } from "./../";

const AwaitedBooksPanel = ({ index, displayIndex }: PanelProps) => {
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

export { AwaitedBooksPanel };
