﻿

namespace OneToManyRelation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        public int ManagerId { get; set; }
        public Employee Manager { get; set; }

        public List<Employee> ManagerTeam { get; set; }

    }
}
