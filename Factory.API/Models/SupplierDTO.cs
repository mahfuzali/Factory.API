using Factory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Models
{
    public class SupplierDTO
    {
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
    }
}
