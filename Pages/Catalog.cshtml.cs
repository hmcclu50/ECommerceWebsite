using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebsite.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public CatalogModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
