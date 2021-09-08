using System;
using System.ComponentModel.DataAnnotations;

namespace P1.Domain
{
    public class Order
    {
        /*
        private readonly ICustomerRepository _customerrepository;
        private readonly ILocationRepository _locationrepository;

        public Order(ICustomerRepository customerrepository, ILocationRepository locationrepository)
        {
            _customerrepository = customerrepository;
            _locationrepository = locationrepository;
        }
        */
        
        public Order()
        {

        }

        public int Id { get; set; }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
        public int Customer { get; set; }
        public int Location { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
    }
}
