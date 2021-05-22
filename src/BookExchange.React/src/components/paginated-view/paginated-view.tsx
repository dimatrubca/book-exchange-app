import {
  Box,
  Container,
  Grid,
  IconButton,
  TablePagination,
} from "@material-ui/core";
import React, { useEffect, useState } from "react";
import { useStyles } from "./paginated-view.styles";
import ViewComfyIcon from "@material-ui/icons/ViewComfy";
import ReorderIcon from "@material-ui/icons/Reorder";

import { Common } from "types";

interface PaginatedViewProps<TData> {
  listCard: React.FC<{}>;
  squareCard: React.FC<{}>;
  fetchData: (
    page: number,
    rowsPerPage: number
  ) => Common.PaginatedResult<TData>;
}

const PaginatedView = <TData extends { id: number }, T>(
  props: PaginatedViewProps<TData>
) => {
  const [page, setPage] = useState<number>(2);
  const [rowsPerPage, setRowsPerPage] = useState<number>(10);
  const [totalRecords, setTotalRecords] = useState<number>(0);
  const [data, setData] = useState<TData[]>();
  const [isListView, setListView] = useState<boolean>(true);

  const classes = useStyles();

  const ListCard = props.listCard;
  const SquareCard = props.squareCard;

  const handleChangePage = (
    event: React.MouseEvent<HTMLButtonElement> | null,
    newPage: number
  ) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await props.fetchData(page, rowsPerPage);

        setData(result.data);
        setTotalRecords(result.totalRecords);
      } catch (e) {
        console.log(e);
      }

      fetchData();
    };
  }, [page, rowsPerPage]);

  return (
    <Container>
      <Grid
        container
        justify="flex-end"
        className={classes.filterIconsContainer}
      >
        <IconButton
          aria-label="delete"
          onClick={() => {
            setListView(true);
          }}
        >
          <ReorderIcon className={classes.filterIcon} />
        </IconButton>
        <IconButton
          aria-label="delete"
          onClick={() => {
            setListView(false);
          }}
          className={classes.filterIcon}
        >
          <ViewComfyIcon />
        </IconButton>
      </Grid>

      {isListView ? (
        data?.map((item) => (
          <Box my={3} key={item.id}>
            <ListCard {...item} />
          </Box>
        ))
      ) : (
        <Grid container spacing={4}>
          {data?.map((item) => (
            <Grid item sm={3} key={item.id}>
              <SquareCard {...item} />
            </Grid>
          ))}
        </Grid>
      )}

      <TablePagination
        component="div"
        count={totalRecords}
        page={page}
        onChangePage={handleChangePage}
        rowsPerPage={rowsPerPage}
        onChangeRowsPerPage={handleChangeRowsPerPage}
      />
    </Container>
  );
};

export { PaginatedView };
