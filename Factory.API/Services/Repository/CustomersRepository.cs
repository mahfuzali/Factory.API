using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factory.API.Contexts;
using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory.API.Services
{
    public class CustomersRepository : ICustomersRepository, IDisposable
    {
        private CustomersContext _context;

        public CustomersRepository(CustomersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }

            }
        }
    }
}
