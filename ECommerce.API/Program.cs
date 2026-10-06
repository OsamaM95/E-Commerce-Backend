using ECommerce.API.Data;
using ECommerce.API.Interfaces;
using ECommerce.API.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); builder.Services.AddOpenApi();
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
app.UseMiddleware<ECommerce.API.Middleware.ExceptionMiddleware>();
if (app.Environment.IsDevelopment()) { app.MapOpenApi(); }
app.UseHttpsRedirection();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; var context = services.GetRequiredService<StoreContext>(); var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration or seeding.");
    }
}
app.Run();