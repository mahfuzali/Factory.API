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
    public class OrderItemsController : ControllerBase
    {
        private IOrderItemsRepository _orderItemsRepository;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemsRepository orderItemsRepository, IMapper mapper)
        {
            _orderItemsRepository = orderItemsRepository ??
                throw new ArgumentNullException(nameof(orderItemsRepository));
            _mapper = mapper ??
                throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItemsEntities = await _orderItemsRepository.GetOrderItemsAsync();
            //return Ok(orderItemsEntities);
            return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemDTO>>(orderItemsEntities));

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            var orderItemsEntities = await _orderItemsRepository.GetOrderItemAsync(id);
            if (orderItemsEntities == null)
            {
                return NotFound();
            }

            //return Ok(orderItemsEntities);
            return Ok(_mapper.Map<OrderItem, OrderItemDTO>(orderItemsEntities));

        }
    }
}
