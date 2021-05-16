import {
  Card,
  CardContent,
  CardMedia,
  Container,
  Grid,
  Paper,
  Typography,
  Divider,
} from "@material-ui/core";

import React from "react";
import { useStyles } from "./profile-page-styles";

import { StatisticsBar } from "./statistics-bar";
import { UserDetails } from "./user-details";

const ProfilePage = () => {
  const classes = useStyles();

  return (
    <div>
      <Container>
        <Card className={classes.topCard}>
          <Grid container spacing={2} className={classes.root}>
            <Grid item xs={1}>
              <CardMedia
                className={classes.profileImage}
                component="img"
                title="Live from space album cover"
                image="https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg"
              />
            </Grid>
            <Grid item>
              <Grid container>
                <Grid item xs={12}>
                  <Typography>Vlad Barcareanu (lastReflect)</Typography>
                </Grid>
                <Grid item>
                  <Typography>Book Coins: 14</Typography>
                </Grid>
              </Grid>
            </Grid>
          </Grid>

          <Divider />
          <StatisticsBar />
        </Card>
        <UserDetails />
      </Container>
    </div>
  );
};

export { ProfilePage };
