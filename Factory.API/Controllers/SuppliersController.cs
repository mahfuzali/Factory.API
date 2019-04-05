using Factory.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController: ControllerBase
    {
        private ISuppliersRepository _suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository ??
                throw new ArgumentNullException(nameof(suppliersRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliersEntities = await _suppliersRepository.GetSuppliersAsync();
            return Ok(suppliersEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var supplierEntity = await _suppliersRepository.GetSupplierAsync(id);
            if (supplierEntity == null)
            {
                return NotFound();
            }

            return Ok(supplierEntity);
        }

    }
}
