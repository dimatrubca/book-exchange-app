import React, { useCallback, useEffect, useState } from "react";
import {
  DataGrid,
  GridColDef,
  GridFilterModelParams,
  GridSortDirection,
  GridValueGetterParams,
} from "@material-ui/data-grid";

import { XGrid } from "@material-ui/x-grid";

import {
  Button,
  SortDirection,
  Box,
  Typography,
  TableHead,
} from "@material-ui/core";
import { PostService } from "services/posts.service";
import { PostsFilter } from "filters";

const columns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 70 },
  {
    field: "postedBy",
    headerName: "Owner",
    width: 130,
    valueFormatter: (params) => params.row?.postedBy?.username,
  },
  {
    field: "condition",
    headerName: "Condition",
    width: 130,
    valueFormatter: (params) => params.row?.condition?.label,
  },
  {
    field: "timeAdded",
    headerName: "Posted",
    width: 230,
    valueFormatter: (params) => {
      var date = new Date(Date.parse(params.row?.timeAdded));

      var year = date.getFullYear();

      var month = (1 + date.getMonth()).toString();
      month = month.length > 1 ? month : "0" + month;

      var day = date.getDate().toString();
      day = day.length > 1 ? day : "0" + day;
      return day + "/" + month + "/" + year;
    },
  },
  {
    field: "country",
    headerName: "Country",
    width: 130,
  },
];

const sortModel = [
  {
    field: "country",
    sort: "asc" as GridSortDirection,
  },
];

const PostsGrid = () => {
  const [page, setPage] = useState(0);
  const [rows, setRows] = useState([]);
  const [rowCount, setRowCount] = useState<number>(0);
  const [loading, setLoading] = useState<boolean>(false);

  const pageSize = 5;

  const handlePageChange = (params: any) => {
    setPage(params.page);
    console.log("now on page:", params.page);
  };

  const onFilterChange = React.useCallback((params: GridFilterModelParams) => {
    console.log(params.filterModel.items[0].value);
    console.log("...");
    console.log(params);
  }, []);

  useEffect(() => {
    let didCancel = false;

    const fetchPosts = async () => {
      setLoading(true);

      try {
        console.log("fetcing page: ", page);
        const postFilter: PostsFilter = {
          includeCondition: true,
          includePostedBy: true,
          pageNumber: page + 1,
          pageSize: pageSize,
          //  sortBy: " ",
          sortDirection: "asc",
          bookId: 1,
        };

        const { data, totalRecords } = await PostService.GetPostsForBook(
          postFilter
        );

        console.log("fetched posts: ", data);
        if (didCancel) {
          return;
        }

        setRowCount(totalRecords);
        setRows(data);
        console.log(rows);
      } catch (err) {
        console.log("error fethcing posts");
      }
      setLoading(false);
    };

    fetchPosts();

    return () => {
      didCancel = true;
    };
  }, [page]);

  useEffect(() => {
    let active = true;

    async function fetchData() {
      const delay = (ms: number) => new Promise((res) => setTimeout(res, ms));
      await delay(2000);

      if (!active) {
        console.log("Returned");
        return;
      }
      console.log("Finished");
    }

    fetchData();

    return () => {
      active = false;
    };
  }, [page]);

  const handleButton = () => {
    console.log("current page: " + page);
    setPage((prev) => prev + 1);
  };

  return (
    <>
      <Box mb={2}>
        <Typography variant="h5">Request this book:</Typography>
      </Box>
      <div style={{ height: 400, width: "100%" }}>
        <DataGrid
          rows={rows}
          columns={columns}
          pageSize={pageSize}
          rowCount={rowCount}
          //   sortModel={sortModel}
          paginationMode="server"
          onPageChange={handlePageChange}
          filterMode="server"
          onFilterModelChange={onFilterChange}
          loading={loading}
        />
      </div>
    </>
  );
};

export { PostsGrid };
