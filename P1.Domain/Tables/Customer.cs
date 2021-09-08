using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P1.Domain
{
    public class Customer
    {
        private string _fullname;
        public Customer(string firstname, string lastname, string phone, DateTime? registrationdate)
        {
            FirstName = firstname;
            LastName = lastname;
            _fullname = firstname + " " + lastname;
            RegistrationDate = registrationdate;
            Phone = phone;
        }
        public Customer(int id, string firstname, string lastname, string phone, DateTime? registrationdate)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            _fullname = firstname + " " + lastname;
            RegistrationDate = registrationdate;
            Phone = phone;
        }
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Customer Name")]
        public string FullName
        {
            get => _fullname;
        }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime? RegistrationDate { get; set; }
    }
}
