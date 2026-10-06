namespace ECommerce.API.Entities
{
    public class Product
    {
        public int Id { get; set; } // هذا هو الـ Primary Key المطلوب
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}