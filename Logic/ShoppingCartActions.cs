using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceWebsite.Models;
using ECommerceWebsite.Data;

namespace ECommerceWebsite.Logic
{
    /* Could not figure out how to get HttpContext.Current functioning
       Referencing: https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/shopping-cart
     */


    /*
    public class ShoppingCartActions : IDisposable
    {
        
        public string ShoppingCartID { get; set; }

        private ApplicationDbContext _db;

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartID = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartID == ShoppingCartID
                && c.ProductID == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemID = Guid.NewGuid().ToString(),
                    ProductID = id,
                    CartID = ShoppingCartID,
                    Product = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        
        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartID = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartID == ShoppingCartID).ToList();
        } 
    
        public decimal GetTotal()
        {
          ShoppingCartId = GetCartId();

          decimal? total = decimal.Zero;
          total = (decimal?)(from cartItems in _db.ShoppingCartItems
                             where cartItems.CartId == ShoppingCartId
                             select (int?)cartItems.Quantity *
                             cartItems.Product.UnitPrice).Sum();
          return total ?? decimal.Zero;
        }     
     */
}