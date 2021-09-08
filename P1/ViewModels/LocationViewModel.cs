using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace P1.ViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel() {}

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Location Name")]
        [StringLength(50, ErrorMessage = "Location name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-.#]*$")]
        public string StoreName { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        [RegularExpression(@"\(?[0-9]*\)?[0-9]{3}-?[0-9]{6}$")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string StreetAddress { get; set; }

        [Required]
        [MinLength(2)]
        public string State { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Zip Code")]
        [StringLength(11, ErrorMessage = "Zip Code cannot be longer than 10 digits.")]
        [RegularExpression(@"^[0-9]*-?[0-9]*$")]
        public string ZipCode { get; set; }

        [StringLength(50, ErrorMessage = "Hours cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\n\t-.#]*$")]
        public string Hours { get; set; }

        [Display(Name = "Opening Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? OpeningDate { get; set; }
    }
}