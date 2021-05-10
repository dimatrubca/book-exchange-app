import { Button, Grid, TextField, Typography, Paper } from "@material-ui/core";
import React, { Fragment } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

import { useStyles } from "./add-book.styles";
import { Book } from "../../types";
import { BookService } from "../../services/books.service";

const schema = yup.object().shape({
  Title: yup.string().max(100).required("Title is required"),
  ISBN: yup
    .string()
    .length(13)
    .matches(/^\d+$/, "Only digits allowed")
    .required("ISBN must contain 13 digits"),
  ShortDescription: yup.string().required("Description is required"),
  Published: yup.string(),
  PageCount: yup.number(),
  Authors: yup.string().max(100),
});

const AddBook = () => {
  const classes = useStyles();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Book.Book>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: Book.Book) => {
    alert(data);
    console.log(data);

    await BookService.AddBook(data);
  };

  return (
    <>
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Typography component="h1" variant="h4" align="center">
            Add New Book
          </Typography>
          <Fragment>
            {/* <Typography variant="h6">Fill in the form</Typography> */}
          </Fragment>

          <form onSubmit={handleSubmit(onSubmit)}>
            <Grid container spacing={3}>
              <Grid item xs={12} sm={6}>
                <TextField
                  {...register("Title")}
                  label="Title"
                  helperText={errors.Title?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  {...register("ISBN")}
                  label="ISBN"
                  fullWidth
                  helperText={errors.ISBN?.message}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  {...register("ShortDescription")}
                  label="Short Description"
                  helperText={errors.ShortDescription?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  {...register("Publisher")}
                  label="Publisher"
                  helperText={errors.Publisher?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  {...register("PageCount")}
                  label="Page Count"
                  helperText={errors.PageCount?.message}
                  fullWidth
                />
              </Grid>

              <Grid item xs={12}>
                <TextField {...register("Authors")} label="Authors" fullWidth />
              </Grid>
              <Button
                variant="contained"
                color="primary"
                type="submit"
                className={classes.button}
              >
                Submit
              </Button>
            </Grid>
          </form>
        </Paper>
      </main>
    </>
  );
};

export { AddBook };
