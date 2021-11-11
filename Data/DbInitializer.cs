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
                new Product{ProductName="Test Product 11",ProductPrice=10, ProductDescription="Test Product 1"},
                new Product{ProductName="Test Product 22",ProductPrice=15, ProductDescription="Test Product 2"},
                new Product{ProductName="Test Product 3",ProductPrice=20, ProductDescription="Test Product 3"},
            };

            context.Product.AddRange(products);
            context.SaveChanges();

        }
    }
}