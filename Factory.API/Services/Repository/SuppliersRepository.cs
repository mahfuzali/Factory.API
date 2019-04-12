using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factory.API.Contexts;
using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory.API.Services
{
    public class SuppliersRepository : ISuppliersRepository, IDisposable
    {
        private SuppliersContext _context;

        public SuppliersRepository(SuppliersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            // .Include(p => p.Products)
            return await _context.Supplier
                .Include(p => p.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _context.Supplier.Include(p => p.Products).ToListAsync();
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
