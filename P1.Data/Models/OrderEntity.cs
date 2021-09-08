using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace P1.Data.Models
{
    public partial class OrderEntity
    {
        public OrderEntity()
        {
            ProductOrders = new HashSet<ProductOrderEntity>();
        }

        [Required]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int Customer { get; set; }

        [Required]
        public int Location { get; set; }

        public virtual CustomerEntity CustomerNavigation { get; set; }
        public virtual LocationEntity LocationNavigation { get; set; }
        public virtual ICollection<ProductOrderEntity> ProductOrders { get; set; }
    }
}
