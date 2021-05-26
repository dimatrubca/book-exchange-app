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
import React, { useContext, useEffect, useState } from "react";
import { useStyles } from "./contacts.styles";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import {
  CountryDropdown,
  RegionDropdown,
  CountryRegionData,
} from "react-country-region-selector";
import { AuthContext } from "context";
import { Account, User } from "types";
import { AccountService } from "services";
import { PanelProps } from "./../";

const schema = yup.object().shape({
  firstName: yup.string().required(),
  lastName: yup.string().required(),
  email: yup.string().required(),
  phoneNumber: yup.string().required(),
  country: yup.string().required(),
  region: yup.string().required(),
  city: yup.string().required(),
  street: yup.string().required(),
});

const ContactsPanel = ({ index, displayIndex }: PanelProps) => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);
  const [isUpdatingContacts, setUpdatingContacts] = useState<boolean>(false);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<User.User>({
    resolver: yupResolver(schema),
  });
  //   useEffect(() => {});

  const updateUserDetails = async (data: User.User) => {};

  const handleModifyContacts = () => {
    setUpdatingContacts(true);
  };

  return (
    <Paper className={classes.root} hidden={index !== displayIndex}>
      <Typography variant="h2" className={classes.contactInfoHeader}>
        Contact Information
      </Typography>
      <form
        onSubmit={
          !isUpdatingContacts
            ? handleSubmit(updateUserDetails)
            : handleModifyContacts
        }
      >
        <Grid container spacing={5}>
          <Grid item xs={3}>
            <TextField
              {...register("firstName")}
              disabled={!isUpdatingContacts}
              //   {authContext.user?.firstName ? value={authContext.user?.firstName} : ''}
              label="First Name"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={3}>
            <TextField
              {...register("lastName")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.lastName || "Unknown"}
              label="Last Name"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={6}>
            <TextField
              {...register("userContact.email")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.email || "Unknown"}
              label="Email"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("userContact.phoneNumber")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.phoneNumber || "unknown"}
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
              {...register("userContact.region")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.region || "unknown"}
              label="Region"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={3}>
            <TextField
              {...register("userContact.city")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.city || "unknown"}
              label="City"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={3}>
            <TextField
              {...register("userContact.streetAddress")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.streetAddress || "unknown"}
              label="Street"
              fullWidth
            ></TextField>
          </Grid>
        </Grid>
        <Button variant="contained" color="primary" type="submit">
          {isUpdatingContacts ? "Update" : "Modify"}
        </Button>
      </form>
      <Typography variant="h2">Preferences</Typography>
    </Paper>
  );
};

export { ContactsPanel };
