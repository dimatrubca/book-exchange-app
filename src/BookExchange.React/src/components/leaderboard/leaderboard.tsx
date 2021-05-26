import React from "react";

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

const Leaderboard = () => {
  const classes = useStyles();

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
            <Typography variant="h6">Exchanged Books</Typography>
          </Grid>
        </Grid>

        {[0, 1, 2, 3].map((value) => {
          const labelId = `checkbox-list-secondary-label-${value}`;
          return (
            <ListItem key={value} button>
              <ListItemAvatar>
                <Avatar
                  alt={`Avatar n°${value + 1}`}
                  src={`/static/images/avatar/${value + 1}.jpg`}
                />
              </ListItemAvatar>
              <ListItemText id={labelId} primary={`Line item ${value + 1}`} />
              <ListItemSecondaryAction className={classes.score}>
                <Typography variant="h6">81</Typography>
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
