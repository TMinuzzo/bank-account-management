using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BankAccount.API.Models;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private IBaseService<Deposit> _baseDepositService;

        private IBaseService<User> _baseUserService;

        private TransactionService _transactionService;

        public TransactionController(IBaseService<Deposit> baseDepositService,
                                     IBaseService<User> baseUserService,
                                     TransactionService transactionService)
        {
            _baseDepositService = baseDepositService;
            _baseUserService = baseUserService;
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("deposit")]
        public IActionResult MakeDeposit([FromBody] MakeDepositModel makeDepositModel)
        {
            try
            {
                // TODO: better way to pass parameters to MakeDeposit
                var deposit = _transactionService.MakeDeposit(makeDepositModel.Destination, makeDepositModel.Amount);
                var result = _baseDepositService.Add<Deposit, Deposit>(deposit);

                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("withdraw")]
        public IActionResult MakeWithdraw([FromBody] MakeWithdrawModel makeWithdrawModel)
        {
            return BadRequest();
        }

        [HttpPost]
        [Route("payment")]
        public IActionResult MakePayment([FromBody] MakePayment makePayment)
        {
            return BadRequest();
        }
    }
}
