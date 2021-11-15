using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }


    }


}
