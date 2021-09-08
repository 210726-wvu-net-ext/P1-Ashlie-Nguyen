using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace P1.Data.Models
{
    public partial class ProductOrderEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Product { get; set; }

        [Required]
        public int Order { get; set; }

        public virtual OrderEntity OrderNavigation { get; set; }
        public virtual ProductEntity ProductNavigation { get; set; }
    }
}
