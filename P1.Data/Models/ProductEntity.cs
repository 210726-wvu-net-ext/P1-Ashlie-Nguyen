using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace P1.Data.Models
{
    public partial class ProductEntity
    {
        public ProductEntity()
        {
            ProductOrders = new HashSet<ProductOrderEntity>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
    }
}
