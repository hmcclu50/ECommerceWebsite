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
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public DeleteModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderHeader = await _context.OrderHeader.FindAsync(id);

            if (OrderHeader != null)
            {
                _context.OrderHeader.Remove(OrderHeader);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
