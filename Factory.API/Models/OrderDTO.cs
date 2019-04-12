using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Models
{
    public class OrderDTO
    {
        //public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        //public int CustomerId { get; set; }
        
        public string TotalAmount { get; set; }

        public string Customer { get; set; }
    }
}
