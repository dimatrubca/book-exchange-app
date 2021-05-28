import React, { useEffect, useState } from "react";
import { Grid, Link, Typography } from "@material-ui/core";
import { useStyles } from "./statistics-bar-styles";
import { UserService } from "services";
import { useFetch } from "hooks";

interface StatisticsItem {
  name: string;
  count: number;
  onClick: any;
}

let statisticsData: StatisticsItem[] = [];

interface StatisticsBarProps {
  setDisplayViewIndex: React.Dispatch<React.SetStateAction<number>>;
  userId: number;
}

const StatisticsBar = ({ setDisplayViewIndex, userId }: StatisticsBarProps) => {
  const classes = useStyles();
  const [statisticsData, setStatisticsData] = React.useState<StatisticsItem[]>(
    []
  );

  const {
    data: userStats,
    fetch: fetchUserStats,
    isLoading,
  } = useFetch(UserService.GetUserStats);

  useEffect(() => {
    fetchUserStats(userId);
  }, [fetchUserStats]);

  useEffect(() => {
    if (isLoading || userStats == null) {
      return;
    }

    setStatisticsData([
      {
        name: "Wishlist",
        onClick: () => {
          setDisplayViewIndex(1);
        },
        count: userStats.wishlist,
      },
      {
        name: "Requested Books",
        onClick: () => {
          setDisplayViewIndex(2);
        },
        count: userStats.requested,
      },
      {
        name: "Awaiting",
        onClick: () => {
          setDisplayViewIndex(3);
        },
        count: userStats.awaiting,
      },
      {
        name: "BookShelf",
        onClick: () => {
          setDisplayViewIndex(4);
        },
        count: userStats.bookshelf,
      },
      {
        name: "Requests",
        onClick: () => {
          setDisplayViewIndex(5);
        },
        count: userStats.requests,
      },
      {
        name: "Sent Books",
        onClick: () => {
          setDisplayViewIndex(6);
        },
        count: userStats.sent,
      },
    ]);
  }, [userStats, isLoading]);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <Grid container className={classes.root} justify="space-between">
      {statisticsData.map((item, index) => (
        <Grid item key={index} xs={2}>
          <Grid
            container
            direction="column"
            justify="center"
            alignContent="center"
          >
            <Grid item xs={12} className={classes.statisticsItem}>
              <Link href="#" onClick={item.onClick}>
                <Typography variant="h5" component="span">
                  {item.count}
                </Typography>
              </Link>
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
