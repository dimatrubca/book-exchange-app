import React, { useState } from "react";

// imports
import Button from "@material-ui/core/Button";
import IconButton from "@material-ui/core/IconButton";
import RemoveIcon from "@material-ui/icons/Remove";
import SendIcon from "@material-ui/icons/Send";
import AddIcon from "@material-ui/icons/Add";

import { Container, TextField } from "@material-ui/core";

import { v4 as uuidv4 } from "uuid";

import { useStyles } from "./post-books.styles";

const PostBooks = () => {
  const classes = useStyles();
  const [inputFields, setInputFields] = useState([{ id: uuidv4(), isbn: "" }]);

  const handleSubmit = (e: React.SyntheticEvent) => {
    e.preventDefault();
    console.log("ISBNs", inputFields);
  };

  const handleChangeInput = (
    id: string,
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const newInputFields = inputFields.map((i) => {
      if (id === i.id) {
        i["isbn"] = event.target.value;
      }
      return i;
    });

    setInputFields(newInputFields);
  };

  const handleAddFields = () => {
    setInputFields([...inputFields, { id: uuidv4(), isbn: "" }]);
  };

  const handleRemoveFields = (id: string) => {
    const values = [...inputFields];
    values.splice(
      values.findIndex((value) => value.id === id),
      1
    );
    setInputFields(values);
  };

  return (
    <Container>
      <h2>Post books</h2>
      <form className={classes.root} onSubmit={handleSubmit}>
        {inputFields.map((inputField) => (
          <div key={inputField.id}>
            <TextField
              name="isbn"
              label="ISBN"
              variant="outlined"
              value={inputField.isbn}
              onChange={(event) => handleChangeInput(inputField.id, event)}
            />

            <IconButton
              disabled={inputFields.length === 1}
              onClick={() => handleRemoveFields(inputField.id)}
            >
              <RemoveIcon />
            </IconButton>

            <IconButton onClick={handleAddFields}>
              <AddIcon />
            </IconButton>
          </div>
        ))}

        <Button
          className={classes.button}
          variant="contained"
          color="primary"
          type="submit"
          onClick={handleSubmit}
          endIcon={<SendIcon />}
        >
          Send
        </Button>
      </form>

      {/* <BookCard
        id={1}
        title="Essentialism"
        authors={["Greg McKeown"]}
        categories={["Self development"]}
        isbn="1012223312345"
      /> */}

      {/* <List dense className={classes.root}>
                {[0, 1, 2, 3].map((value) => {
                    const labelId = 1;
                    return (
                        <ListItem key={value} button>
                            <ListItemAvatar
                        </ListItem>
                    );
                })}
            </List> */}
    </Container>
  );
};

export { PostBooks };
