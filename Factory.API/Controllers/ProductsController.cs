using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factory.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ??
                throw new ArgumentNullException(nameof(productsRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntities = await _productsRepository.GetProductsAsync();
            return Ok(productsEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productEntities = await _productsRepository.GetProductAsync(id);
            if (productEntities == null)
            {
                return NotFound();
            }

            return Ok(productEntities);
        }
    }
}
