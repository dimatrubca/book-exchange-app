import React, { useEffect, useState } from "react";
import { Box, Typography, Paper } from "@material-ui/core";
import { BookCard } from "components/book-card";
import { BookMediaCard } from "components/book-media-card";
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
        listCard={BookCard}
        squareCard={BookMediaCard}
        service={UserService.GetWishedBooks}
      />
    </div>
  );
};

export { WishlistPanel };
