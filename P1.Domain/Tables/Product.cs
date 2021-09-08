using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P1.Domain
{
    public class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [Display(Name = "Product Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public decimal Price { get; set; }

    }
}
