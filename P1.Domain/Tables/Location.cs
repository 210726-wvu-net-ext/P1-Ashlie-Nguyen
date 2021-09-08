using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P1.Domain
{
    public class Location
    {
        public Location(string storename, string phone, string hours, string address, string zipcode, string state, DateTime? openingdate)
        {
            StoreName = storename;
            Phone = phone;
            Hours = hours;
            StreetAddress = address;
            ZipCode = zipcode;
            State = state;
            OpeningDate = openingdate;
        }
        public Location(int id, string storename, string phone, string hours, string address, string zipcode, string state, DateTime? openingdate)
        {
            Id = id;
            StoreName = storename;
            Phone = phone;
            Hours = hours;
            StreetAddress = address;
            ZipCode = zipcode;
            State = state;
            OpeningDate = openingdate;
        }
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string StoreName { get; set; }
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string State { get; set; }

        [Display(Name = "Opening Date")]
        [DataType(DataType.Date)]
        public DateTime? OpeningDate { get; set; }

        public string Hours { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
