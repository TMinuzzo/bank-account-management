import React, { useState } from "react";

import {
  Paper,
  Grid,
  Typography,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Button,
} from "@material-ui/core";

import { useStyles } from "../styles.js";

export default function LoginScreen( { handleClickButton, handleChangeUser, users } ) {
  const classes = useStyles();

  const [userLogin, setUserLogin] = useState("");
  
  const handleChangeUserLogin = (user) => {
    handleChangeUser(user)
    setUserLogin(user);
  };

  return (
    <React.Fragment>
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Grid container>
            <Typography component="h6" variant="h4" align="left">
              Login
            </Typography>
            <Grid item xs={12}>
              <FormControl className={classes.textField}>
                <InputLabel id="demo-simple-select-label">
                  Selecione o User
                </InputLabel>
                <Select
                  id="select-form"
                  value={userLogin}
                  onChange={(e) => handleChangeUserLogin(e.target.value)}
                >
                  {users.map((option) => (
                    <MenuItem key={option.name} value={option}>
                      {option.name}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </Grid>
            <Button
              variant="contained"
              color="primary"
              className={classes.button}
              onClick={handleClickButton}
            >
              Entrar
            </Button>
          </Grid>
        </Paper>
      </main>
    </React.Fragment>
  );
}
