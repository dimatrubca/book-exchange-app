import React, { useEffect, useState } from "react";
import { Box, Typography, Paper } from "@material-ui/core";
import { BookListCard, BookSquareCard } from "components/cards";
import { PaginatedView } from "components/paginated-view";
import { UserService } from "services";

interface WishlistPanelProps {
  index: number;
  displayIndex: number;
}

const WishlistPanel = ({ index, displayIndex }: WishlistPanelProps) => {
  return (
    <div hidden={displayIndex !== index}>
      <PaginatedView
        title="Wishlist"
        listCard={BookListCard}
        squareCard={BookSquareCard}
        service={UserService.GetWishedBooks}
      />
    </div>
  );
};

export { WishlistPanel };
