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
                new Product{ProductName="Microsft Mouse",ProductPrice=45, ProductDescription="Bluetooth Mouse - Microsoft"},
                new Product{ProductName="Microsft Keyboard",ProductPrice=50, ProductDescription="Bluetooth Keyboard - Microsoft"},
                new Product{ProductName="Logitech Headset",ProductPrice=75, ProductDescription="Bluetooth Headset - Logitech"},
            };

            context.Product.AddRange(products);
            context.SaveChanges();

        }
    }
}