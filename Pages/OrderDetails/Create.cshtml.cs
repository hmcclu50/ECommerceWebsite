﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Pages.OrderDetails
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
        ViewData["OrderHeaderID"] = new SelectList(_context.Set<OrderHeader>(), "OrderHeaderID", "OrderHeaderID");
            ViewData["ProductID"] = new SelectList(_context.Set<Models.Product>(), "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
