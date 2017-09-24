using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopHierarchy.Data
{
   public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<OrderItems> Orders { get; set; } = new List<OrderItems>();

        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}
