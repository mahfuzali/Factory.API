using Factory.API.Contexts;
using Factory.API.Entities;
using Factory.API.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Services.Repository
{
    public class OrdersRepository : IOrdersRepository, IDisposable
    {
        private OrdersContext _context;

        public OrdersRepository(OrdersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Order.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Order.Include(o => o.Customer).ToListAsync();
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
