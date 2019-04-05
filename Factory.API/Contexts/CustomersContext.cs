using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Contexts
{
    public class CustomersContext: DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public CustomersContext(DbContextOptions<CustomersContext> options)
            : base(options)
        {

        }
    }
}
