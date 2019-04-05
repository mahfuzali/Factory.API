using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [StringLength(30)]
        public string Package { get; set; }

        [Required]
        [Range(0, 1)]
        public int IsDiscontinued { get; set; }

        public Supplier Supplier { get; set; }
    }
}
