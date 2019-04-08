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
    public class OrderItemsRepository : IOrderItemsRepository, IDisposable
    {
        private OrderItemsContext _context;

        public OrderItemsRepository(OrderItemsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<OrderItem> GetOrderItemAsync(int id)
        {
            return await _context.OrderItem
                .Include(o => o.Order)
                    .ThenInclude(c => c.Customer)
                .Include(o => o.Product)
                    .ThenInclude(s => s.Supplier)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            return await _context.OrderItem
                .Include(o => o.Order)
                    .ThenInclude(c => c.Customer)
                .Include(o => o.Product)
                    .ThenInclude(s => s.Supplier)
                .ToListAsync();
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
