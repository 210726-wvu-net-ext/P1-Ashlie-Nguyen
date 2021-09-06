using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P1.Data.Models
{
    public class ProductOrder
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
