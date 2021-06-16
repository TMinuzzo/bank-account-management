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
  TextField,
  InputAdornment
} from "@material-ui/core";

import { useStyles } from "../styles.js";

export default function AccountScreen({user}) {
  const classes = useStyles();

  const [operation, setOperation] = useState("Saque");


  const handleChangeOperation = (operation) =>  {
    setOperation(operation)
  }

  return (
    <React.Fragment>
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Grid container>
            <Typography component="h6" variant="h4" align="left">
              Olá, {user}! 
            </Typography>
            <Grid item xs={12}>
            <Typography component="h6" variant="h6" align="left">
              Seu saldo é: 
            </Typography>
            </Grid>
            <Grid item xs={12}>
              <FormControl className={classes.textField}>
                <InputLabel id="demo-simple-select-label">
                  Selecione a operação
                </InputLabel>
                <Select
                  id="select-form"
                  value={operation}
                  onChange={(e) => handleChangeOperation(e.target.value)}
                >
                    <MenuItem key={1} value="Depósito">
                      Depósito
                    </MenuItem>
                    <MenuItem key={2} value="Saque">
                      Saque
                    </MenuItem>
                    <MenuItem key={3} value="Pagamento">
                      Pagamento
                    </MenuItem>
                </Select>
              </FormControl>
              <TextField
                className={classes.textField}
                label="Valor"
                id="standard-adornment-amount"
                //value={product.price}
                //onChange={handleChangePrice}
                InputProps={{
                startAdornment: (
                    <InputAdornment position="start">$</InputAdornment>
                ),
                }}
                />
            </Grid>
            <Button
              variant="contained"
              color="primary"
              className={classes.button}
              //onClick={handleClickButton}
            >
              Enviar
            </Button>
            <Button
              variant="contained"
              color="primary"
              className={classes.button}
              //onClick={handleClickButton}
            >
              Mostrar Histórico
            </Button>
          </Grid>
        </Paper>
      </main>
    </React.Fragment>
  );
}
