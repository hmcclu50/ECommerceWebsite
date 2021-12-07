using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWebsite.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public ShoppingCartModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
