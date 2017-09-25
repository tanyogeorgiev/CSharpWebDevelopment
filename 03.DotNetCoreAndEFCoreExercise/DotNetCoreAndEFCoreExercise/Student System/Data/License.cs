using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentSystem.Data
{
   public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

    }
}
