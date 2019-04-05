using Factory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Services
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();

        Task<Supplier> GetSupplierAsync(int id);
    }
}
