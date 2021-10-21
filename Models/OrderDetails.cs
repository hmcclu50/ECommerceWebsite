﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebsite.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderHeaderID { get; set; }
        public OrderHeader order { get; set; }
        public int ProductID { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
