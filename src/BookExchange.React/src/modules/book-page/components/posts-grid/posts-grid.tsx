import React, { useCallback, useContext, useEffect, useState } from "react";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import { useSnackbar } from "notistack";

import { Button, SortDirection, Box, Typography } from "@material-ui/core";
import { PostService } from "services/posts.service";
import { PostsFilter } from "filters";
import { useFetch } from "hooks";
import { Post } from "types";
import { useStyles } from "./posts-grid-styles";
import { AuthContext } from "context";
import { UserService } from "services";

interface PostsGridProps {
  bookId: number;
}

const PostsGrid = ({ bookId }: PostsGridProps) => {
  const classes = useStyles();
  const { enqueueSnackbar } = useSnackbar();
  const { user } = useContext(AuthContext);

  const {
    data: data,
    fetch: fetchData,
    isLoading: isDataLoading,
  } = useFetch(PostService.GetPosts);

  useEffect(() => {
    const postFilter: Post.PostsFilter = {
      includeCondition: true,
      includePostedBy: true,
      pageNumber: 1,
      pageSize: 1000,
      sortDirection: "asc",
      bookId: bookId,
    };
    fetchData(postFilter);
  }, []);

  const handleRequestPost = async (postId: number) => {
    if (!user) {
      enqueueSnackbar("Please sign in first", { variant: "error" });
      return;
    }

    try {
      var result = await UserService.RequestPost(user.id, postId);
      enqueueSnackbar("Reqeust sent successfully!", { variant: "success" });
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
    }
  };

  if (isDataLoading || data == null) {
    return <p>Loading...</p>;
  }

  if (!data.data.length)
    return <Typography>There are no book offers</Typography>;

  return (
    <>
      <Typography variant="h5">Book offers: </Typography>

      <TableContainer component={Paper}>
        <Table className={classes.table} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Posted By</TableCell>
              <TableCell>Book Condition</TableCell>
              <TableCell></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.data.map((post) => (
              <TableRow key={post.id}>
                <TableCell component="th" scope="row">
                  {post.postedBy?.username}
                </TableCell>
                <TableCell>{post.condition}</TableCell>
                <TableCell>
                  {" "}
                  <Button
                    onClick={() => {
                      handleRequestPost(post.id);
                    }}
                  >
                    Request
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
};

export { PostsGrid };
