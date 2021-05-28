import React, { useEffect } from "react";

import {
  Avatar,
  Checkbox,
  Grid,
  List,
  ListItem,
  ListItemAvatar,
  Box,
  ListItemSecondaryAction,
  ListItemText,
  ListSubheader,
  Typography,
} from "@material-ui/core";

import { useStyles } from "./leaderboard.styles";
import { UserService } from "services";
import { useFetch } from "hooks";

const Leaderboard = () => {
  const classes = useStyles();

  const {
    data: users,
    fetch: fetchTopUsers,
    isLoading,
  } = useFetch(UserService.GetTopUsers);

  useEffect(() => {
    fetchTopUsers(3);
  }, []);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <div className={classes.root}>
      <Typography variant="h5" className={classes.title}>
        Leaderboard
      </Typography>

      <List dense>
        <Grid container justify="space-between" className={classes.header}>
          <Grid item>
            <Typography variant="h6">Username</Typography>
          </Grid>
          <Grid item>
            <Typography variant="h6">Book Points</Typography>
          </Grid>
        </Grid>

        {users?.map((user, index) => {
          const labelId = `checkbox-list-secondary-label-${index}`;
          return (
            <ListItem key={index} button>
              <ListItemAvatar>
                <Avatar
                // alt={`Avatar n°${value + 1}`}
                // src={`/static/images/avatar/${value + 1}.jpg`}
                />
              </ListItemAvatar>
              <ListItemText id={labelId} primary={`${user.username}`} />
              <ListItemSecondaryAction className={classes.score}>
                <Typography variant="h6">{user.points}</Typography>
              </ListItemSecondaryAction>
            </ListItem>
          );
        })}

        {/* <Grid container>
          <Grid item xs={1}>
            <Grid container justify="center" alignItems="center">
              <Typography variant="h6">Rank</Typography>
            </Grid>{" "}
          </Grid>
          <Grid item xs={9}>
            <Typography variant="h6">Username</Typography>
          </Grid>
          <Grid item xs={2}>
            <Grid container justify="center" alignItems="center">
              <Typography variant="h6">Exchanged Books</Typography>
            </Grid>{" "}
          </Grid>
        </Grid> */}
      </List>
    </div>
  );
};

export { Leaderboard };
