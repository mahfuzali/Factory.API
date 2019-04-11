using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Models
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal UnitPrice { get; set; }

        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        //public string Supplier { get; set; }
    }
}
