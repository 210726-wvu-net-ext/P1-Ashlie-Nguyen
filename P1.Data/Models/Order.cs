using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P1.Data.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public Customer Customer { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal TotalPrice { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public Location Location { get; set; }
    }
}
