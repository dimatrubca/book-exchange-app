import React from "react";
import { BookCard } from "components/book-card";
import { BookMediaCard } from "components/book-media-card";
import { PaginatedView } from "components/paginated-view";
import { UserService } from "services";
import { PanelProps } from "./../";

const SentBooksPanel = ({ index, displayIndex }: PanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Sent Books"
        listCard={BookCard}
        squareCard={BookMediaCard}
        service={UserService.GetWishedBooks}
      />
    </div>
    //todo: change to post card
  );
};

export { SentBooksPanel };
