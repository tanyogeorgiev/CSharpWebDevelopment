﻿namespace ShopHierarchy.Data
{
    public class OrderItems
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
