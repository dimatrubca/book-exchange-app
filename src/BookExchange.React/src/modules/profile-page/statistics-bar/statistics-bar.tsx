import React from "react";
import { Grid, Typography } from "@material-ui/core";
import { useStyles } from "./statistics-bar-styles";
import { collapseTextChangeRangesAcrossMultipleVersions } from "typescript";

interface StatisticsItem {
  name: string;
  count: number;
  path: string;
}

let statisticsData: StatisticsItem[] = [
  {
    name: "Wishlist",
    path: "/",
    count: 14,
  },
  {
    name: "Given Books",
    path: "/",
    count: 14,
  },
  {
    name: "Excahnged Books",
    path: "/",
    count: 14,
  },
  {
    name: "Wishlist",
    path: "/",
    count: 14,
  },
];

const StatisticsBar = () => {
  const classes = useStyles();
  return (
    <Grid container className={classes.root} justify="space-between">
      {statisticsData.map((item) => (
        <Grid item xs={3}>
          <Grid
            container
            direction="column"
            justify="center"
            alignContent="center"
          >
            <Grid item xs={12} className={classes.statisticsItem}>
              <Typography variant="h5" component="span">
                {item.count}
              </Typography>
            </Grid>
            <Grid item xs={12}>
              <Typography>{item.name}</Typography>
            </Grid>
          </Grid>
        </Grid>
      ))}
    </Grid>
  );
};

export { StatisticsBar };
