using Microsoft.EntityFrameworkCore;
using Part3RazorPages.Data;

namespace Part3RazorPages.Models;

public static class SeedData    
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Part3RazorPagesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Part3RazorPagesContext>>()))
        {
            if (context == null || context.Product == null)
            {
                throw new ArgumentNullException("Null Part3RazorPagesContext");
            }

            // Look for any products.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            context.Product.AddRange(
                new Product
                {
                    Name = "Rice",
                    Price = 25,
                    Qty = 10,
                },

                new Product
                {
                    Name = "Flour",
                    Price = 15,
                    Qty = 2,
                },

                new Product
                {
                    Name = "Butter",
                    Price = 13,
                    Qty = 11,
                },

                new Product
                {
                    Name = "Juice",
                    Price = 5,
                    Qty = 100,
                },
                new Product
                {
                Name = "Juice Mini",
                    Price = 12,
                    Qty = 52,
                }
            );
            context.SaveChanges();
        }
    }
}