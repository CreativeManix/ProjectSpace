using System;
using System.Collections.Generic;
using System.Text;
using ProjectSpace.Entities;

namespace ProjectSpace.Services.Implementations
{
    internal class EmployeeService : BaseService,IEmployeeService
    {
        public void AddEmployee(Employee employee)
        {
            
            Console.WriteLine("Emp saved");
        }

        public override void Dispose()
        {

        }

        public override void SaveChanges()
        {
            
        }
    }
}
