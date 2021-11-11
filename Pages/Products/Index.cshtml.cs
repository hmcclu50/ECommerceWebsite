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

namespace ECommerceWebsite.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public IndexModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Models.Product> Product { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "prod_name" : "prod_desc";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "prod_price" : "";

            CurrentFilter = searchString;

            IQueryable<Product> productsSort = from s in _context.Product
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                productsSort = productsSort.Where(s => s.ProductName.Contains(searchString)
                                       || s.ProductDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "prod_name":
                    productsSort = productsSort.OrderByDescending(s => s.ProductName);
                    break;
                case "prod_price":
                    productsSort = productsSort.OrderByDescending(s => s.ProductPrice);
                    break;
                case "prod_desc":
                    productsSort = productsSort.OrderByDescending(s => s.ProductDescription);
                    break;
                default:
                    productsSort = productsSort.OrderByDescending(s => s.ProductPrice);
                    break;
            }
            
            Product = await productsSort.AsNoTracking().ToListAsync();

        }
    }
}
