using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Infrastructure;
using ShoppingCartAPI.ShoppingCart.AP.Infrastructure;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCartAPI.ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product_DTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var res = await _productRepo.AddProduct(product);
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
