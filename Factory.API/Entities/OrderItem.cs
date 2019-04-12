using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Entities
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; } 
        //public ICollection<Product> Products { get; set; }
    }
}
