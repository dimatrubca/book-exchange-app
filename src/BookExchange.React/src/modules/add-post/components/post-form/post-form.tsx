import React, { useContext, useEffect } from "react";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@material-ui/core";
import { Controller, useForm } from "react-hook-form";
import { Post } from "types";
import { PostService } from "services";
import { useStyles } from "./post-form.styles";
import { useFetch } from "hooks";
import { AuthContext } from "context";
import { VariantType, useSnackbar } from "notistack";

interface PostFormParams {
  bookId: number;
}

const PostForm = ({ bookId }: PostFormParams) => {
  const classes = useStyles();
  const { user } = useContext(AuthContext);
  const { enqueueSnackbar } = useSnackbar();

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Post.CreatePost>();

  const {
    data: conditions,
    fetch: fetchConditions,
    isLoading,
  } = useFetch(PostService.GetBookConditions);

  useEffect(() => {
    fetchConditions();
  }, []);

  const onSubmit = async (data: Post.CreatePost) => {
    data.bookId = bookId;
    data.postedById = user?.id || 0;

    try {
      PostService.CreatePost(data);
      enqueueSnackbar("Post created successfully", { variant: "success" });
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
    }
  };

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <form className={classes.root} onSubmit={handleSubmit(onSubmit)}>
      <Controller
        render={({ field, fieldState: { invalid, error } }) => (
          <FormControl variant="outlined" fullWidth>
            <InputLabel id="demo-simple-select-outlined-label">
              Book Condition
            </InputLabel>
            <Select
              labelId="demo-simple-select-outlined-label"
              id="demo-simple-select-outlined"
              // value={age}
              // onChange={handleChange}
              label="Age"
            >
              {conditions?.map((value, index) => (
                <MenuItem value="key" key={index}>
                  {value}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        )}
        control={control}
        name="condition"
      />
      <Button variant="contained" color="primary" type="submit">
        Submit
      </Button>{" "}
    </form>
  );
};

export { PostForm };
