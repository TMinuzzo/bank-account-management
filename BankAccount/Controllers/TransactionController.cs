using BankAccount.API.Models;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Service.Services;
using FluentValidation;
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
                // TODO: Instead of passing attributes from RequestModel, pass a generic type and use Mapper to map between generic and Entity
                var deposit = _transactionService.MakeDeposit(makeDepositModel.Destination, makeDepositModel.Amount);
                var result = _baseDepositService.Add<Deposit, Deposit>(deposit);

                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("withdraw")]
        public IActionResult MakeWithdraw([FromBody] MakeWithdrawModel makeWithdrawModel)
        {
            try
            {
                // TODO: Instead of passing attributes from RequestModel, pass a generic type and use Mapper to map between generic and Entity
                var withdraw = _transactionService.MakeWithdraw(makeWithdrawModel.Source, makeWithdrawModel.Amount);
                var result = _baseWithdrawService.Add<Withdraw, Withdraw>(withdraw);

                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("payment")]
        public IActionResult MakePayment([FromBody] MakePayment makePayment)
        {
            try
            {
                // TODO: Instead of passing attributes from RequestModel, pass a generic type and use Mapper to map between generic and Entity
                var payment = _transactionService.MakePayment(makePayment.Source, makePayment.Destination, makePayment.Amount, makePayment.Description);
                var result = _basePaymentService.Add<Payment, Payment>(payment);

                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
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
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
