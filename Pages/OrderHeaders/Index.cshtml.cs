using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Pages.OrderHeaders
{
    public class IndexModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public IndexModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderHeader> OrderHeader { get;set; }

        public async Task OnGetAsync()
        {
            OrderHeader = await _context.OrderHeader
                .Include(o => o.customer).ToListAsync();
        }
    }
}
