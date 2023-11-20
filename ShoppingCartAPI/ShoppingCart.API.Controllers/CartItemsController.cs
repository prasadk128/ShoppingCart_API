using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.AP.Infrastructure;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using ShoppingCartAPI.ShoppingCarts.API.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;
        public CartItemsController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartItem_DTO cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                //default setting 1 for quantity
                cartItem.Qunatity = cartItem.Qunatity == 0 ? 1 : cartItem.Qunatity;
                var res = await _cartRepo.AddCartItem(cartItem);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CartItem_DTO cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                Cart res =   await _cartRepo.DeleteCartItem(cartItem);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
        [HttpGet]
        [Route("User")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _cartRepo.GetUserCart(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
    }
}
