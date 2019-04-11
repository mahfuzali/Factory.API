using AutoMapper;
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
    public class SuppliersController: ControllerBase
    {
        private ISuppliersRepository _suppliersRepository;
        private readonly IMapper _mapper;

        public SuppliersController(ISuppliersRepository suppliersRepository, IMapper mapper)
        {
            _suppliersRepository = suppliersRepository ??
                throw new ArgumentNullException(nameof(suppliersRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliersEntities = await _suppliersRepository.GetSuppliersAsync();
            //return Ok(suppliersEntities);
            return Ok(_mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(suppliersEntities));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplierEntity = await _suppliersRepository.GetSupplierAsync(id);
            if (supplierEntity == null)
            {
                return NotFound();
            }

            //return Ok(supplierEntity);
            return Ok(_mapper.Map<Supplier, SupplierDTO>(supplierEntity));
        }

    }
}
