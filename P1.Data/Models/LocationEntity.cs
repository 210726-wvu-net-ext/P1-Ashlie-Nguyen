using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace P1.Data.Models
{
    public partial class LocationEntity
    {
        public LocationEntity()
        {
            Orders = new HashSet<OrderEntity>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string State { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OpeningDate { get; set; }

        public string Hours { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
