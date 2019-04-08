using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Contexts
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Order { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {

        }
    }
}
