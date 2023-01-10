using System;
using System.Collections.Generic;

namespace DeepClone
{
    internal class Program
    {
        static void Main()
        {
            var department = new Department
            {
                DepartmentName = "Power Generation",
                Employees = new List<Employee>()
                {
                    new() { EmployeeName = "John" }
                }
            };

            var departmentClone = CloneHelper.DeepClone(department);

            // Change property values of the cloned object to be sure it is deeply cloned
            // and will not affect the original object
            departmentClone.DepartmentName = "Power Generation cloned";
            departmentClone.Employees[0].EmployeeName = "Alex";

            Console.WriteLine("Original Department Object");
            Console.WriteLine($"Department name: {department.DepartmentName}");
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
            Console.WriteLine();

            Console.WriteLine("Cloned Department Object");
            Console.WriteLine($"Department name: {departmentClone.DepartmentName}");
            foreach (var employee in departmentClone.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
