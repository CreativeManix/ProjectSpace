using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSpace.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public EntityCollection<Employee> Employees { get;  }
    }
}
