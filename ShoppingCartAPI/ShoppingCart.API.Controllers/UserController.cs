using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartAPI.Infrastructure;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User_DTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var res = await _userRepo.AddUser(value);

                return Ok(res);
            }
            catch (Exception ex)
            {

                // Return a custom error response to the user
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
     
    }
}
