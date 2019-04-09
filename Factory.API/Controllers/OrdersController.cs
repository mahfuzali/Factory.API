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
    public class OrdersController : ControllerBase
    {
        private IOrdersRepository _ordersRepository;

        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository ??
                throw new ArgumentNullException(nameof(ordersRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var ordersEntities = await _ordersRepository.GetOrdersAsync();
            return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(ordersEntities));
            //return Ok(ordersEntities);
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

            return Ok(_mapper.Map<Order, OrderDTO>(orderEntities));
            //return Ok(orderEntities);
        }
    }
}
