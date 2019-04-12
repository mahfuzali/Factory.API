using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using Factory.API.Services.Interface;
using Microsoft.AspNetCore.Http;
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
        [Route("{id}", Name = "GetOrderItem")]
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


        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemForCreation orderItem)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(orderItem);

            var search = _orderItemsRepository.GetOrderItemAsync(orderItemEntity.Id);

            if (search != null)
            {
                return BadRequest("Item already exists");
            }

            _orderItemsRepository.AddOrderItem(orderItemEntity);

            await _orderItemsRepository.SaveChangesAsync();

            await _orderItemsRepository.GetOrderItemAsync(orderItemEntity.Id);

            return CreatedAtRoute("GetOrderItem",
                new { id = orderItemEntity.Id },
                orderItemEntity);
        }


        [HttpPut]
        public async Task<ActionResult> Put(OrderItemForCreation newOrderItem)
        {

            var orderItemEntity = _mapper.Map<OrderItem>(newOrderItem);

            var oldOrder = await _orderItemsRepository.GetOrderItemAsync(orderItemEntity.Id);

            if (oldOrder == null) return NotFound($"Could not found the order item");

            _mapper.Map(newOrderItem, oldOrder);

            if (await _orderItemsRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<OrderItem, OrderItemDTO>(orderItemEntity)); 
            }

            return BadRequest();
        }


        [HttpDelete()]
        public async Task<ActionResult> Delete([FromBody] OrderItemForCreation orderItem)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(orderItem);

            var search = _orderItemsRepository.GetOrderItemAsync(orderItemEntity.Id);

            if (search == null)
            {
                return BadRequest("OrderItem doesn't exists");
            }

            var oldCamp = await _orderItemsRepository.GetOrderItemAsync(search.Id);

            if (oldCamp == null) return NotFound();

            _orderItemsRepository.DeleteOrderItem(oldCamp);

            if (await _orderItemsRepository.SaveChangesAsync())
            {
                return Ok(_mapper.Map<OrderItem, OrderItemDTO>(orderItemEntity));
                //return Ok();
            }

            return BadRequest();
        }


    }
}
