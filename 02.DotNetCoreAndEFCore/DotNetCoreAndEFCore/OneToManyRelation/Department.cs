
namespace OneToManyRelation
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
