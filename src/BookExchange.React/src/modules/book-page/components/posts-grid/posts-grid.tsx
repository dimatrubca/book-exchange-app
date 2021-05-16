import React, { useEffect, useState } from "react";
import {
  DataGrid,
  GridColDef,
  GridSortDirection,
  GridValueGetterParams,
} from "@material-ui/data-grid";
import { Button, SortDirection } from "@material-ui/core";
import { PostService, PostFilter } from "services/posts.service";

const columns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 70 },
  { field: "owner", headerName: "Owner", width: 130 },
  { field: "condition", headerName: "Condition", width: 130 },
  { field: "postTime", headerName: "Posted", width: 130 },
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

const rows = [
  {
    id: 1,
    condition: "Snow",
    owner: "Jon",
    postTime: new Date("3-2-2015").toLocaleDateString(),
    country: "Finland",
  },
  {
    id: 2,
    condition: "Lannister",
    owner: "Cersei",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Moldova",
  },
  {
    id: 3,
    condition: "Lannister",
    owner: "Jaime",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Moldova",
  },
  {
    id: 4,
    condition: "Stark",
    owner: "Arya",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Romania",
  },
  {
    id: 5,
    condition: "Targaryen",
    owner: "Daenerys",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Russia",
  },
  {
    id: 6,
    condition: "Melisandre",
    owner: null,
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Moldova",
  },
  {
    id: 7,
    condition: "Clifford",
    owner: "Ferrara",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Romania",
  },
  {
    id: 8,
    condition: "Frances",
    owner: "Rossini",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Romania",
  },
  {
    id: 9,
    condition: "Roxie",
    owner: "Harvey",
    postTime: new Date(2010, 7, 5).toLocaleDateString(),
    country: "Moldova",
  },
];
const PostsGrid = () => {
  const [page, setPage] = useState(1);
  const [rows, setRows] = useState([]);
  const [loading, setLoading] = useState<boolean>(false);

  const handlePageChange = (params: any) => {
    setPage(params.page);
  };

  useEffect(() => {
    let didCancel = false;

    const fetchPosts = async () => {
      setLoading(true);

      try {
        const postFilter: PostFilter = {
          pageNumber: 1,
          pageSize: 10,
          sortBy: " ",
          sortDirection: "asc",
          bookId: 1,
        };
        const posts = await PostService.GetPostsForBook(postFilter);
        if (didCancel) {
          return;
        }

        setRows(posts.data);
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
    <div style={{ height: 400, width: "100%" }}>
      <DataGrid
        rows={rows}
        columns={columns}
        pageSize={5}
        checkboxSelection
        sortModel={sortModel}
      />
      <Button onClick={handleButton}>Click</Button>
    </div>
  );
};

export { PostsGrid };
