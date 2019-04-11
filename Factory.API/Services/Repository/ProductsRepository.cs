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
    public class ProductsRepository : IProductsRepository, IDisposable
    {
        private ProductsContext _context;

        public ProductsRepository(ProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Product.ToListAsync(); 
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
