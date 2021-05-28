import React from "react";
import { Box, Paper, Tab, Tabs, Typography, useTheme } from "@material-ui/core";
import { useStyles } from "./search-tabs.styles";
import SwipeableViews from "react-swipeable-views";
import { TabPanel } from "../tab-panel";
import { SmartSearch } from "./smart-seach";
import { FilteredSearch } from "./filtered-search";
import { Book } from "types";
interface SearchTabsProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
  isActiveSmartSearch: any;
  setActiveSmartSearch: any;
}

const SearchTabs = (props: SearchTabsProps) => {
  const classes = useStyles();
  const theme = useTheme();

  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setValue(index);
  };

  return (
    <Paper className={classes.root}>
      <Tabs
        value={value}
        onChange={handleChange}
        indicatorColor="primary"
        textColor="primary"
        variant="fullWidth"
      >
        <Tab label="Smart Search" />
        <Tab label="Filtered Search" />
      </Tabs>
      <SwipeableViews
        axis={theme.direction === "rtl" ? "x-reverse" : "x"}
        index={value}
        onChangeIndex={handleChangeIndex}
      >
        <TabPanel value={value} index={0} dir={theme.direction}>
          <SmartSearch
            {...props}
            isActiveSmartSearch={props.isActiveSmartSearch}
            setActiveSmartSearch={props.setActiveSmartSearch}
          />
        </TabPanel>
        <TabPanel value={value} index={1} dir={theme.direction}>
          <FilteredSearch
            {...props}
            isActiveSmartSearch={props.isActiveSmartSearch}
            setActiveSmartSearch={props.setActiveSmartSearch}
          />
        </TabPanel>
      </SwipeableViews>
    </Paper>
  );
};

export { SearchTabs };
