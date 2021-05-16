import {
  Button,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
  Typography,
} from "@material-ui/core";
import React, { useEffect } from "react";
import { useStyles } from "./user-details-styles";
import {
  CountryDropdown,
  RegionDropdown,
  CountryRegionData,
} from "react-country-region-selector";

const UserDetails = () => {
  const classes = useStyles();
  //   const countries = useState();

  //   useEffect(() => {});

  return (
    <Paper className={classes.root}>
      <Typography variant="h2" className={classes.contactInfoHeader}>
        Contact Information
      </Typography>
      <Grid container spacing={5}>
        <Grid item xs={4}>
          <TextField
            disabled={true}
            value={"Dima Trubca"}
            label="Name"
            fullWidth
          ></TextField>
        </Grid>
        <Grid item xs={4}>
          <TextField
            disabled={true}
            value={"dimatrubca@gmail.com"}
            label="Email"
            fullWidth
          ></TextField>
        </Grid>
        <Grid item xs={4}>
          <TextField
            disabled={true}
            value={"+373 69395018"}
            label="Phone number"
            fullWidth
          ></TextField>
        </Grid>
        <Grid item xs={3}>
          <InputLabel id="demo-simple-select-label">Country</InputLabel>

          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select-required"
            value={"1"}
            label="Country"
            fullWidth
          >
            <MenuItem value="">
              <em>None</em>
            </MenuItem>
            <MenuItem value={10}>Ten</MenuItem>
            <MenuItem value={20}>Twenty</MenuItem>
            <MenuItem value={30}>Thirty</MenuItem>
          </Select>
        </Grid>
        <Grid item xs={3}>
          <TextField
            disabled={true}
            value={"+373 69395018"}
            label="Region"
            fullWidth
          ></TextField>
        </Grid>
        <Grid item xs={3}>
          <TextField
            disabled={true}
            value={"+373 69395018"}
            label="City"
            fullWidth
          ></TextField>
        </Grid>
        <Grid item xs={3}>
          <TextField
            disabled={true}
            value={"+373 69395018"}
            label="Street"
            fullWidth
          ></TextField>
        </Grid>
      </Grid>
      <Button variant="contained" color="primary">
        Modify
      </Button>

      <Typography variant="h2">Preferences</Typography>
    </Paper>
  );
};

export { UserDetails };
