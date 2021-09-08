using System.ComponentModel.DataAnnotations;

namespace P1.ViewModels
{
    public class ProductOrderViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public int Product { get; set; }

        public int Order { get; set; }
    }
}