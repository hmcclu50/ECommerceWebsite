using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;
    using Microsoft.AspNetCore.Authorization;

namespace ECommerceWebsite.Pages.OrderHeaders
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public DetailsModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public OrderHeader OrderHeader { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader = await _context.OrderHeader
                .Include(o => o.customer).FirstOrDefaultAsync(m => m.OrderHeaderID == id);

            if (OrderHeader == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
