using System;
using System.Collections.Generic;

namespace BinarySerialization
{
    internal class Program
    {
        static void Main()
        {
            var path = "DepartmentBinary.dat";
            var department = new Department
            {
                DepartmentName = "Power Generation Binary",
                Employees = new List<Employee>()
                {
                    new() { EmployeeName = "John" },
                    new() { EmployeeName = "Mike" },
                    new() { EmployeeName = "Anna" },
                    new() { EmployeeName = "Shaun" },
                    new() { EmployeeName = "Nick" },
                    new() { EmployeeName = "Maria" },
                    new() { EmployeeName = "David" },
                    new() { EmployeeName = "Jake" },
                }
            };

            BinarySerializationHelper.Serialize(path, department);

            var newDepartment = BinarySerializationHelper.Deserialize<Department>(path);

            Console.WriteLine($"Department name: {newDepartment.DepartmentName}");
            foreach (var employee in newDepartment.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
