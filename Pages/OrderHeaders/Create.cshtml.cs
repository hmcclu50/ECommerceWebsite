using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Pages.OrderHeaders
{
    public class CreateModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public CreateModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
            return Page();
        }

        [BindProperty]
        public OrderHeader OrderHeader { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderHeader.Add(OrderHeader);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
