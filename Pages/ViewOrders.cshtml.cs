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
    public class ViewOrdersAdminModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public ViewOrdersAdminModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders.ToListAsync();
        }
    }
}
