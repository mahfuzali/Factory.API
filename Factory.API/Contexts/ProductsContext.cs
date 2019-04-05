using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Contexts
{
    public class ProductsContext: DbContext 
    {
        public DbSet<Product> Product { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {

        }
    }
}
