using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Pages.OrderDetails
{
    public class DetailsModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public DetailsModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = await _context.OrderDetails
                .Include(o => o.order)
                .Include(o => o.product).FirstOrDefaultAsync(m => m.OrderDetailID == id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
