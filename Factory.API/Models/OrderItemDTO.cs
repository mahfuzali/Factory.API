using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public OrderDTO Order { get; set; }

        public ProductDTO Product { get; set; }

        //public ICollection<ProductDTO> Products { get; set; }
    }
}
