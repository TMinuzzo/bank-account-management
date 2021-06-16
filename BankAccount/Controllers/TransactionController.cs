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
        private IBaseService<Withdraw> _baseWithdrawService;
        private IBaseService<Payment> _basePaymentService;


        private TransactionService _transactionService;

        public TransactionController(IBaseService<Deposit> baseDepositService,
                                     IBaseService<Withdraw> baseWithdrawService,
                                     IBaseService<Payment> basePaymentService,
                                     TransactionService transactionService)
        {
            _baseDepositService = baseDepositService;
            _baseWithdrawService = baseWithdrawService;
            _basePaymentService = basePaymentService;
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
            try
            {
                // TODO: better way to pass parameters to MakeDeposit
                var withdraw = _transactionService.MakeWithdraw(makeWithdrawModel.Source, makeWithdrawModel.Amount);
                var result = _baseWithdrawService.Add<Withdraw, Withdraw>(withdraw);

                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("payment")]
        public IActionResult MakePayment([FromBody] MakePayment makePayment)
        {
            try
            {
                // TODO: better way to pass parameters to MakeDeposit
                var payment = _transactionService.MakePayment(makePayment.Source, makePayment.Destination, makePayment.Amount, makePayment.Description);
                var result = _basePaymentService.Add<Payment, Payment>(payment);

                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("history/{username}")]
        public IActionResult GetHistory(string username)
        {
            try
            {
                var result = _transactionService.GetHistory(username);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }
    }
}
