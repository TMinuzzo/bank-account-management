import React, { useState, useEffect } from "react";

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
  InputAdornment,
  Table,
  TableCell,
  TableContainer,
  TableBody,
  TableRow,
  TableHead
} from "@material-ui/core";

import axios from "axios";

import { useStyles } from "../styles.js";
import constants from "../utils/constants.js";

export default function AccountScreen({user}) {
  const classes = useStyles();

  const [operation, setOperation] = useState("Saque");
  const [price, setPrice] = useState(50.00);
  const [history, setHistory] = useState([]);
  const [balance, setBalance] = useState(0);

  const handleChangeOperation = (operation) =>  {
    setOperation(operation)
  }

  const handleChangePrice = (price) => {
    console.log(price)
    setPrice(parseInt(price))
  }

  useEffect(() => {
    setBalance(user.balance)
    updateHistory();
  }, []);

  const handleClickButtonOperation = () => {
    let body = null;
    operation === "Depósito" ? body = {destination: user.id, amount: price} : body = {source: user.id, amount: price}

    console.log(body)
    axios
    .post(constants.MAP_OPTION_TO_URL[operation], body)
    .then((res) => {   
      updateHistory();     
    })
    .catch((err) => console.log("error", err));
  }

  const updateHistory = () => {
    axios
    .get(constants.URLS.GET_HISTORY + user.name)
    .then((res) => {   
      setHistory(res.data)  
      console.log(res.data);
    })
    .catch((err) => console.log("error", err));
  }

  return (
    <React.Fragment>
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Grid container>
            <Typography component="h6" variant="h4" align="left">
              Olá, {user.name}! 
            </Typography>
            <Grid item xs={12}>
            <Typography component="h6" variant="h6" align="left">
              Seu saldo é de: {new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL'}).format(user.balance)}
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
                value={price}
                onChange={(e) => handleChangePrice(e.target.value)}
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
              onClick={handleClickButtonOperation}
            >
              Enviar
            </Button>
          </Grid>
          <TableContainer component={Paper}>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell align="center">Operação</TableCell>
                <TableCell align="center">Valor (R$)</TableCell>
                <TableCell align="center">Data</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {history.map((row) => (
                <TableRow key={constants.OPERATION_ENUM[row.type]}>
                  <TableCell align="center">{constants.OPERATION_ENUM[row.type]}</TableCell>
                  <TableCell align="center" scope="row">{new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL'}).format(row.amount)}</TableCell>
                  <TableCell align="center">{new Date(row.timestamp).toLocaleDateString()}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>      
        </Paper>
      </main>
    </React.Fragment>
  );
}
