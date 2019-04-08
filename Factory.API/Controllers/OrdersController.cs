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
    public class OrdersController : ControllerBase
    {
        private IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository ??
                throw new ArgumentNullException(nameof(ordersRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var ordersEntities = await _ordersRepository.GetOrdersAsync();
            return Ok(ordersEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orderEntities = await _ordersRepository.GetOrderAsync(id);
            if (orderEntities == null)
            {
                return NotFound();
            }

            return Ok(orderEntities);
        }
    }
}
