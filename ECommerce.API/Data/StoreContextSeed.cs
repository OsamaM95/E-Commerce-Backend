using ECommerce.API.Entities;
namespace ECommerce.API.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product> { new Product { Name = "iPhone 15", Description = "Apple Smartphone", Price = 999 }, new Product { Name = "MacBook Pro", Description = "Apple Laptop M3", Price = 1999 }, new Product { Name = "AirPods Pro", Description = "Noise Canceling Earbuds", Price = 249 } };
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}