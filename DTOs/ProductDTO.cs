using System.ComponentModel.DataAnnotations;

namespace APIProduct.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
