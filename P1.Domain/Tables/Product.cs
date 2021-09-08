using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P1.Domain
{
    public class Product
    {
        public Product(string name, string category, DateTime? releaseate, decimal price)
        {
            Name = name;
            Category = category;
            ReleaseDate = releaseate;
            Price = price;
        }
        public Product(int id, string name, string category, DateTime? releaseate, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            ReleaseDate = releaseate;
            Price = price;
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
