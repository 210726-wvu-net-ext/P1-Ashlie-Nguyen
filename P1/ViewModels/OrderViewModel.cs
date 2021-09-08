using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using P1.Domain;

namespace P1.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Total Price")]
        [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int Customer { get; set; }
        public int Location { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}