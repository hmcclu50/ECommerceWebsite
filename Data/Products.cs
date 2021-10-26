using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Data
{
    public class Products
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Product.Any())
            {
                return;   
            }

            var Product = new Product[]
         {
                new Product{ProductID=1,ProductName="",ProductPrice= 9.99, ProductDescription = " Alyssa is dumb"},
               
         };
        }

    }
}
