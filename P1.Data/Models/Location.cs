using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace P1.Data.Models
{
    public class Location
    {
        [Required]
        public int Id { get; set; }
        public string Store { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Hours { get; set; }

        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}
