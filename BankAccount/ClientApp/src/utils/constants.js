const OPERATION_ENUM = {
  0: "Saque",
  1: "Depósito",
  2: "Pagamento",
};

const BASE_URL = "https://localhost:44323/api/";

const URLS = {
  GET_USERS: BASE_URL + "user/",
  MAKE_DEPOSIT: BASE_URL + "transaction/deposit/",
  MAKE_WITHDRAW: BASE_URL + "transaction/withdraw/",
  MAKE_PAYMENT: BASE_URL + "transaction/payment/",
  GET_HISTORY: BASE_URL + "transaction/history/",
};

const MAP_OPTION_TO_URL = {
  Depósito: URLS.MAKE_DEPOSIT,
  Saque: URLS.MAKE_WITHDRAW,
  Pagamento: URLS.MAKE_PAYMENT,
};

export default { URLS, MAP_OPTION_TO_URL, OPERATION_ENUM };
