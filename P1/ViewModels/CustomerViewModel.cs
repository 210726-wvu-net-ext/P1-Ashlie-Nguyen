using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace P1.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Location name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s-]*$")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Location name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s-]*$")]
        public string LastName { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        [RegularExpression(@"\(?[0-9]{3}\)?-?[0-9]{3}-?[0-9]{4}$")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; set; }
    }
}