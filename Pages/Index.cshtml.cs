using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public IndexModel(ECommerceWebsite.Data.ApplicationDbContext context)
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
