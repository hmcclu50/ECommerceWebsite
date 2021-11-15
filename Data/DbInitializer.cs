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
                new Product{ProductName="Dell PC",ProductPrice=700, ProductDescription="OptiPlex 3080 Desktop PC - Dell"},
                new Product{ProductName="HP Laptop",ProductPrice=600, ProductDescription="17.3 Inch Laptop - HP"},
                new Product{ProductName="ViewSonic Monitor",ProductPrice=150, ProductDescription="24 Inch Monitor - ViewSonic"},
            };

            context.Product.AddRange(products);
            context.SaveChanges();

        }
    }
}