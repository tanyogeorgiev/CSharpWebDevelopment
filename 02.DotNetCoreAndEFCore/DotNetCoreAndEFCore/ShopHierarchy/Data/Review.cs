﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy.Data
{
   public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
