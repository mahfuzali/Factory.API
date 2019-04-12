using Factory.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Contexts
{
    public class OrderItemsContext : DbContext
    {
        public DbSet<OrderItem> OrderItem { get; set; }

        public OrderItemsContext(DbContextOptions<OrderItemsContext> options)
            : base(options)
        {

        }
    }
}
