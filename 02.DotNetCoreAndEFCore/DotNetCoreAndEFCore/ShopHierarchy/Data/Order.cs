using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy.Data
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItems> Items { get; set; } = new List<OrderItems>();
    }
}

