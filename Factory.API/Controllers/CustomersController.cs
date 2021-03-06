﻿using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using Factory.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private ICustomersRepository _customersRepository;

        private readonly IMapper _mapper;

        public CustomersController(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository ??
                throw new ArgumentNullException(nameof(customersRepository));

            _mapper = mapper ??
                throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customersEntities = await _customersRepository.GetCustomersAsync();
            return Ok(_mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customersEntities));
            //return Ok(customersEntities);
        }

        [HttpGet]
        [Route("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customerEntity = await _customersRepository.GetCustomerAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Customer, CustomerDTO>(customerEntity));
            //return Ok(customerEntity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreation customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);

            var search = _customersRepository.CheckCustomerExists(customerEntity);

            if (search != null)
            {
                return BadRequest("Customer already exists");
            }

            _customersRepository.AddCustomer(customerEntity);

            await _customersRepository.SaveChangesAsync();

            await _customersRepository.GetCustomerAsync(customerEntity.Id);

            return CreatedAtRoute("GetCustomer",
                new { id = customerEntity.Id },
                customerEntity);
        }



    }
}
