using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository ??
                throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productsEntities = await _productsRepository.GetProductsAsync();
            //return Ok(productsEntities);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productsEntities));

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

            //return Ok(productEntities);
            return Ok(_mapper.Map<Product, ProductDTO>(productEntities));
        }
    }
}
