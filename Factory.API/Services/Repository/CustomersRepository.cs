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

        public void AddCustomer(Customer customerToAdd)
        {
            if (customerToAdd == null)
            {
                throw new ArgumentNullException(nameof(customerToAdd));
            }

            _context.Add(customerToAdd);
        }

        public async Task<Customer> CheckCustomerExists(Customer customerToAdd)
        {
            if (customerToAdd == null)
            {
                throw new ArgumentNullException(nameof(customerToAdd));
            }

            return await _context.Customer.FindAsync(customerToAdd);
        }
        /**/

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(IEnumerable<int> customerIds)
        {
            return await _context.Customer.Where(b => customerIds.Contains(b.Id)).ToListAsync();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
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
