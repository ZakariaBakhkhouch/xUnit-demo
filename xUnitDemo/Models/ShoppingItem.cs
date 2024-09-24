using System.ComponentModel.DataAnnotations;

namespace xUnitDemo.Models
{
    public class ShoppingItem
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Manufacturer { get; set; }
    }
}
