using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Entities
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
    }
}
