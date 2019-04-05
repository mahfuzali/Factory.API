using Factory.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private ICustomersRepository _customersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository ??
                throw new ArgumentNullException(nameof(customersRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customersEntities = await _customersRepository.GetCustomersAsync();
            return Ok(customersEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customerEntity = await _customersRepository.GetCustomerAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            return Ok(customerEntity);
        }

    }
}
