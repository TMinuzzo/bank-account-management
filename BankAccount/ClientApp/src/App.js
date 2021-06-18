import React, { useState, useEffect } from "react";

import LoginScreen from "./components/LoginScreen.jsx";

import { CssBaseline, AppBar, Toolbar, Typography } from "@material-ui/core";
import axios from "axios";

import { useStyles } from "./styles.js";
import AccountScreen from "./components/AccountScreen.jsx";
import constants from "./utils/constants.js";

export default function Account(props) {
  const classes = useStyles(props);

  const initialValue = [{ name: " " }];
  const [users, setUsers] = useState(initialValue);
  const [user, setUser] = useState("");
  const [loginStatus, setLoginStatus] = useState(false);

  useEffect(() => {
    axios
      .get(constants.URLS.GET_USERS)
      .then((res) => {
        setUsers(res.data);
        console.log(res.data);
      })
      .catch((err) => console.log("error", err));
  }, []);

  const handleChangeUser = (user) => {
    setUser(user);
  };

  const handleClickButton = () => {
    setLoginStatus(true);
  };

  return (
    <React.Fragment>
      <CssBaseline />
      <AppBar position="absolute" color="default" className={classes.appBar}>
        <Toolbar>
          <Typography variant="h6" color="inherit" noWrap>
            Conta
          </Typography>
        </Toolbar>
      </AppBar>
      {loginStatus === false ? (
        <LoginScreen
          handleClickButton={handleClickButton}
          handleChangeUser={handleChangeUser}
          users={users}
        />
      ) : (
        <AccountScreen user={user} />
      )}
    </React.Fragment>
  );
}
