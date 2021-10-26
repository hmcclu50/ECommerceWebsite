using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderHeaderID { get; set; }
        [Display(Name = "Order")]
        public OrderHeader order { get; set; }
        public int ProductID { get; set; }
        [Display(Name = "Product")]
        public Product product { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
