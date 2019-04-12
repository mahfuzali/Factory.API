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

        public void AddOrderItem(OrderItem orderToAdd)
        {
            if (orderToAdd == null)
            {
                throw new ArgumentNullException(nameof(orderToAdd));
            }

            _context.Add(orderToAdd);
        }

        public void DeleteOrderItem(OrderItem orderToDelete)
        {
            if (orderToDelete == null)
            {
                throw new ArgumentNullException(nameof(orderToDelete));
            }

            _context.Remove(orderToDelete);
        }

        public async Task<OrderItem> CheckOrderItemExists(OrderItem orderItemToAdd)
        {
            if (orderItemToAdd == null)
            {
                throw new ArgumentNullException(nameof(orderItemToAdd));
            }

            return await _context.OrderItem.FindAsync(orderItemToAdd);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
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
