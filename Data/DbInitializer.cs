using ECommerceWebsite.Models;
using ECommerceWebsite.Data;
using System;
using System.Linq;

namespace ECommerceWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any products.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{ProductName="Dell PC",ProductPrice=700, ProductDescription="Dell OptiPlex 3080 Desktop PC"},
                new Product{ProductName="HP Laptop",ProductPrice=600, ProductDescription="HP 17.3 inch Laptop"},
                new Product{ProductName="Acer Monitor",ProductPrice=150, ProductDescription="Acer 24 inch Monitor"},
            };

            context.Product.AddRange(products);
            context.SaveChanges();

        }
    }
}