using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BankAccount.API.Models;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private IBaseService<TransactionBase> _baseTransactionService;

        public TransactionController(IBaseService<TransactionBase> baseTransactionService)
        {
            _baseTransactionService = baseTransactionService;
        }

        [HttpPost]
        [Route("deposit")]
        public IActionResult MakeDeposit([FromBody] MakeDepositModel makeDepositModel) // TODO: use a DTO instead of the User model!
        {
            try
            {
                var result = _baseTransactionService.Add<MakeDepositModel, Deposit>(makeDepositModel);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("withdraw")]
        public IActionResult MakeWithdraw([FromBody] MakeWithdrawModel makeWithdrawModel) // TODO: use a DTO instead of the User model!
        {
            try
            {
                var result = _baseTransactionService.Add<MakeWithdrawModel, Withdraw>(makeWithdrawModel);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("payment")]
        public IActionResult MakePayment([FromBody] MakePayment makePayment) // TODO: use a DTO instead of the User model!
        {
            try
            {
                var result = _baseTransactionService.Add<MakePayment, Payment>(makePayment);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }
    }
}
