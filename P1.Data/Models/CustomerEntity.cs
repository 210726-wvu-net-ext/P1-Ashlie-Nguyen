using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace P1.Data.Models
{
    public partial class CustomerEntity
    {
        public CustomerEntity()
        {
            Orders = new HashSet<OrderEntity>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
