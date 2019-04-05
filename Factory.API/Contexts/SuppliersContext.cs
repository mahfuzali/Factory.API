using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Contexts
{
    public class SuppliersContext: DbContext
    {
        public DbSet<Supplier> Supplier { get; set; }

        public SuppliersContext(DbContextOptions<SuppliersContext> options)
            :base(options)
        {

        }
    }
}
