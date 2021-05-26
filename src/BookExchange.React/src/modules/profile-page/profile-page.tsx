import {
  Card,
  CardContent,
  CardMedia,
  Container,
  Grid,
  Paper,
  Button,
  Typography,
  Divider,
  Link,
} from "@material-ui/core";
import { AuthContext } from "context";

import React, { useContext, useState } from "react";
import { useStyles } from "./profile-page-styles";

import { StatisticsBar } from "./components/statistics-bar";
import {
  ContactsPanel,
  WishlistPanel,
  RequestedBooksPanel,
  BookRequestsPanel,
  SentBooksPanel,
  AwaitedBooksPanel,
  BookShelfPanel,
} from "./components";

import { PremiumDialog } from "components/premium-dialog";
import { PurchaseCoinsDialog } from "components/purchase-coins-dialog";

const ProfilePage = () => {
  const classes = useStyles();
  const { user } = useContext(AuthContext);
  const [isPremiumDialogOpen, setPremiumDialogOpen] = useState(false);
  const [isPurchaseDialogOpen, setPurchaseDialogOpen] = useState(false);
  const [displayViewIndex, setDisplayViewIndex] = useState<number>(1);

  const handleOpenPremiumDialog = () => {
    setPremiumDialogOpen(true);
  };

  const handleClosePremiumDialog = () => {
    setPremiumDialogOpen(false);
  };

  const handleOpenPurchaseDialog = () => {
    setPurchaseDialogOpen(true);
  };

  const handleClosePurchaseDialog = () => {
    setPurchaseDialogOpen(false);
  };

  console.log("user:", user);
  console.log(user?.firstName);

  if (!user) {
    return <p>User not logged</p>;
  }

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
            <Grid item xs={8}>
              <Grid container>
                <Grid item xs={12}>
                  <Typography>
                    {user?.firstName} {user?.lastName} ({user?.username})
                  </Typography>
                </Grid>
                <Grid item xs={12}>
                  <Typography>Book Coins: {user?.points}</Typography>
                </Grid>
                <Grid item xs={12}>
                  <Link
                    href="#"
                    onClick={() => {
                      setDisplayViewIndex(7);
                    }}
                  >
                    View details
                  </Link>
                </Grid>
              </Grid>
            </Grid>
            <Grid item xs={3}>
              <Button
                variant="outlined"
                color="primary"
                onClick={handleOpenPurchaseDialog}
              >
                Buy Coins
              </Button>
              <Button
                variant="outlined"
                color="secondary"
                onClick={handleOpenPremiumDialog}
              >
                Premium
              </Button>
            </Grid>
          </Grid>

          <Divider />
          <StatisticsBar
            setDisplayViewIndex={setDisplayViewIndex}
            userId={user?.id}
          />
        </Card>

        <WishlistPanel index={1} displayIndex={displayViewIndex} />
        <RequestedBooksPanel index={2} displayIndex={displayViewIndex} />
        <AwaitedBooksPanel index={3} displayIndex={displayViewIndex} />
        <BookShelfPanel index={4} displayIndex={displayViewIndex} />
        <BookRequestsPanel index={5} displayIndex={displayViewIndex} />
        <SentBooksPanel index={6} displayIndex={displayViewIndex} />
        <ContactsPanel index={7} displayIndex={displayViewIndex} />
      </Container>

      <PremiumDialog
        open={isPremiumDialogOpen}
        onClose={handleClosePremiumDialog}
      />

      <PurchaseCoinsDialog
        open={isPurchaseDialogOpen}
        onClose={handleClosePurchaseDialog}
      />
    </div>
  );
};

export { ProfilePage };
