using ECommerceWebsite.Models;
using ECommerceWebsite.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace ECommerceWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var products = new Product[]
            {
                new Product{ProductName="Dell PC",ProductPrice=700, ProductDescription="Dell OptiPlex 3080 Desktop PC"},
                new Product{ProductName="HP Laptop",ProductPrice=600, ProductDescription="HP 17.3 inch Laptop"},
                new Product{ProductName="Acer Monitor",ProductPrice=150, ProductDescription="Acer 24 inch Monitor"},
            };

            var user = new IdentityUser("Admin@test.com");
            var PHasher = new PasswordHasher<IdentityUser>();
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.EmailConfirmed = true;
            user.NormalizedUserName = "Admin@test.com";
            user.PasswordHash = PHasher.HashPassword(user, "Admin69!!");
            context.Users.Add(user);
            context.SaveChanges();



            var role = new IdentityRole("Admin");
            context.Roles.Add(role);
            context.SaveChanges();



            var userRole = new IdentityUserRole<string>();
            userRole.RoleId = role.Id;
            userRole.UserId = user.Id;
            context.UserRoles.Add(userRole);
            context.SaveChanges();


            context.Product.AddRange(products);
            context.SaveChanges();

        }
    }
}