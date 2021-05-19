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
import { AuthContext } from "context";

import React, { useContext } from "react";
import { useStyles } from "./profile-page-styles";

import { StatisticsBar } from "./statistics-bar";
import { Contacts, Wishlist } from "./components";

const ProfilePage = () => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);
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
                  <Typography>
                    Vlad Barcareanu ({authContext.user?.username})
                  </Typography>
                </Grid>
                <Grid item>
                  <Typography>
                    Book Coins: {authContext.user?.points}
                  </Typography>
                </Grid>
              </Grid>
            </Grid>
          </Grid>

          <Divider />
          <StatisticsBar />
        </Card>
        <Wishlist />
      </Container>
    </div>
  );
};

export { ProfilePage };
