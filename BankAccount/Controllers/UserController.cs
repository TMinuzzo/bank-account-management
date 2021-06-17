using System.Net.Http;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
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
        public IActionResult Create([FromBody] User user)
        {
            try
            {
                var result = _baseUserService.Add<User, User>(user);
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




    }
}
