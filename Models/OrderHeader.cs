using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Models
{
    public class OrderHeader
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public Customer customer { get; set; }
        public DateTime Date { get; set; }
    }
}
