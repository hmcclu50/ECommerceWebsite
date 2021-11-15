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
    public class CatalogModel : PageModel
    {
        private readonly ECommerceWebsite.Data.ApplicationDbContext _context;

        public CatalogModel(ECommerceWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "prod_name" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "prod_price" : "prod_price";

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
