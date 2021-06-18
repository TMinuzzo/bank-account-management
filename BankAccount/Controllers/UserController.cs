using System.Net.Http;
using BankAccount.API.Models;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseUserService;

        public UserController(IBaseService<User> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel user)
        {
            try
            {
                var result = _baseUserService.Add<CreateUserModel, User, UserValidator>(user);
                return Ok(result);
            }
            catch(HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _baseUserService.Get<User>();
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _baseUserService.GetById<User>(id);
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e);
            }
        }




    }
}
