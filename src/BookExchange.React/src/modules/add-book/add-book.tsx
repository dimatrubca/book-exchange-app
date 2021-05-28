import {
  Button,
  Grid,
  TextField,
  Typography,
  Paper,
  Container,
} from "@material-ui/core";
import React, { Fragment, useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

import { useStyles } from "./add-book.styles";
import { Author, Category, Book } from "types";
import { BookService } from "../../services/books.service";
import { UploadFile } from "components/upload-file";
import { Autocomplete } from "@material-ui/lab";
import { AuthorsService, CategoryService } from "services";
import { useHistory } from "react-router";
import { useSnackbar } from "notistack";

const schema = yup.object().shape({
  // Title: yup.string().max(100).required("Title is required"),
  // ISBN: yup
  //   .string()
  //   .length(13)
  //   .matches(/^\d+$/, "Only digits allowed")
  //   .required("ISBN must contain 13 digits"),
  // ShortDescription: yup.string().required("Description is required"),
  // Published: yup.string(),
  // PageCount: yup.number(),
  // Authors: yup.string().max(100),
});

const AddBook = () => {
  const classes = useStyles();
  const [authorsOptions, setAuthorsOptions] = useState<Author.Author[]>([]);
  const [categoriesOptions, setCategoriesOptions] = useState<
    Category.Category[]
  >([]);
  const [currentFile, setCurrentFile] = useState();
  const history = useHistory();
  const { enqueueSnackbar } = useSnackbar();

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Book.CreateBook>({
    resolver: yupResolver(schema),
  });

  useEffect(() => {
    const fetchData = async () => {
      try {
        const authors = await AuthorsService.GetAll();
        const categories = await CategoryService.GetAll();

        console.log("authors", authors);
        console.log("categories", categories);

        setAuthorsOptions(authors);
        setCategoriesOptions(categories);
      } catch (e) {
        console.log(e);
      }
    };

    fetchData();
  }, []);

  const onSubmit = async (data: Book.CreateBook) => {
    console.log(data);
    data.image = currentFile;

    try {
      var book = await BookService.AddBook(data);

      enqueueSnackbar("Book Created Successfully", { variant: "success" });
      history.push("/book" + book.id);
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
      history.push("/");
    }
  };

  return (
    <>
      <Container>
        <Paper className={classes.paper}>
          <Typography component="h1" variant="h5" className={classes.pageTitle}>
            Add New Book
          </Typography>

          <form onSubmit={handleSubmit(onSubmit)}>
            <Grid container spacing={3}>
              <Grid item xs={12} sm={4}>
                <TextField
                  {...register("title")}
                  variant="outlined"
                  label="Title"
                  helperText={errors.title?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={3}>
                <TextField
                  {...register("isbn")}
                  variant="outlined"
                  label="ISBN"
                  fullWidth
                  helperText={errors.isbn?.message}
                />
              </Grid>
              <Grid item xs={5}>
                <Controller
                  name="authorsId"
                  control={control}
                  render={({ field: { onChange }, ...props }) => (
                    <Autocomplete
                      multiple
                      {...props}
                      id="authors"
                      options={authorsOptions}
                      getOptionLabel={(option: Author.Author) => option.name}
                      renderOption={(option) => option.name}
                      onChange={(e, data) => onChange(data.map((i) => i.id))}
                      filterSelectedOptions
                      renderInput={(params) => (
                        <TextField
                          {...params}
                          variant="outlined"
                          label="Author"
                        />
                      )}
                    />
                  )}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  {...register("shortDescription")}
                  variant="outlined"
                  multiline
                  label="Short Description"
                  helperText={errors.shortDescription?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  {...register("description")}
                  variant="outlined"
                  multiline
                  label="Description"
                  helperText={errors.shortDescription?.message}
                  fullWidth
                />
              </Grid>

              <Grid item xs={3}>
                <Controller
                  name="categoriesId"
                  control={control}
                  render={({ field: { onChange }, ...props }) => (
                    <Autocomplete
                      multiple
                      {...props}
                      id="book-author"
                      options={categoriesOptions}
                      getOptionLabel={(option: Category.Category) =>
                        option.label
                      }
                      renderOption={(option) => option.label}
                      onChange={(e, data) => onChange(data.map((i) => i.id))}
                      filterSelectedOptions
                      renderInput={(params) => (
                        <TextField
                          {...params}
                          variant="outlined"
                          label="Category"
                        />
                      )}
                    />
                  )}
                />
              </Grid>
              <Grid item xs={12} sm={3}>
                <TextField
                  {...register("publisher")}
                  variant="outlined"
                  label="Publisher"
                  helperText={errors.publisher?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={2}>
                <TextField
                  {...register("pageCount")}
                  type="number"
                  variant="outlined"
                  label="Pages"
                  helperText={errors.pageCount?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12} sm={4}>
                <TextField
                  {...register("publishedYear")}
                  type="number"
                  variant="outlined"
                  label="Publication Year"
                  helperText={errors.pageCount?.message}
                  fullWidth
                />
              </Grid>
              <Grid item xs={12}>
                <UploadFile
                  currentFile={currentFile}
                  setCurrentFile={setCurrentFile}
                />
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
      </Container>
    </>
  );
};

export { AddBook };
