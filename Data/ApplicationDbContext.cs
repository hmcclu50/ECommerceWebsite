using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ECommerceWebsite.Models.Customer> Customer { get; set; }
        public DbSet<ECommerceWebsite.Models.OrderDetail> OrderDetails { get; set; }
        public DbSet<ECommerceWebsite.Models.OrderHeader> OrderHeader { get; set; }
        public DbSet<ECommerceWebsite.Models.Product> Product { get; set; }
    }
}
