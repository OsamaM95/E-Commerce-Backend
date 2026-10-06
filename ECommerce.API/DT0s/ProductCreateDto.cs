using System.ComponentModel.DataAnnotations;
namespace ECommerce.API.DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Name is required")][MaxLength(100)] public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.1, 999999, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public string PictureUrl { get; set; } = string.Empty;

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int ProductBrandId { get; set; }
    }
}