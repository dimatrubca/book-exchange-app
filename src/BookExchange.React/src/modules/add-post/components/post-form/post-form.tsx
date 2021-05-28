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
import Condition from "yup/lib/Condition";
import { Autocomplete } from "@material-ui/lab";
import { useHistory } from "react-router";

interface PostFormParams {
  bookId: number;
}

const PostForm = ({ bookId }: PostFormParams) => {
  const classes = useStyles();
  const { user } = useContext(AuthContext);
  const { enqueueSnackbar } = useSnackbar();
  const history = useHistory();

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
    console.log("on submit post", data);
    if (!user) return;

    data.bookId = bookId;
    data.postedById = user?.id;

    try {
      await PostService.CreatePost(data);
      enqueueSnackbar("Book added to bookshelf", { variant: "success" });
      history.push("/profile");
    } catch (e) {
      enqueueSnackbar(e.message, { variant: "error" });
    }
  };

  if (isLoading || !conditions) {
    return <p>Loading...</p>;
  }

  return (
    <form className={classes.root} onSubmit={handleSubmit(onSubmit)}>
      <Controller
        name="condition"
        control={control}
        render={({ field: { onChange }, ...props }) => (
          <Autocomplete
            {...props}
            id="condition"
            options={conditions}
            // getOptionLabel={(option: Condition.Condition) => option.label}
            // renderOption={(option) => option.label}
            onChange={(e, data) => onChange(data)}
            filterSelectedOptions
            renderInput={(params) => (
              <TextField {...params} variant="outlined" label="Condition" />
            )}
          />
        )}
      />
      <Button variant="contained" color="primary" type="submit">
        Submit
      </Button>{" "}
    </form>
  );
};

export { PostForm };
