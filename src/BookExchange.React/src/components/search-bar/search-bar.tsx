import React, { useState } from "react";
import { InputAdornment, TextField } from "@material-ui/core";
import { useStyles } from "./search-bar.styles";
import IconButton from "@material-ui/core/IconButton";
import SearchIcon from "@material-ui/icons/Search";

interface SearchBarProps {
  handleSearch: any;
}

const SearchBar = (props: SearchBarProps) => {
  const classes = useStyles();
  const [searchTerm, setSearchTerm] = useState<string>("");

  return (
    <div>
      <TextField
        className={classes.mainSearchbar}
        fullWidth={true}
        variant="outlined"
        label="Search"
        onChange={(e) => setSearchTerm(e.target.value)}
        InputProps={{
          endAdornment: (
            <InputAdornment position="end">
              <IconButton
                onClick={() => {
                  props.handleSearch(searchTerm);
                }}
              >
                <SearchIcon />
              </IconButton>
            </InputAdornment>
          ),
        }}
      />
    </div>
  );
};

export { SearchBar };
