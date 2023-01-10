using System;
using System.Collections.Generic;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main()
        {
            var path = Environment.CurrentDirectory + "//DepartmentJson.json";

            var department = new Department
            {
                DepartmentName = "Power Generation Json",
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

            JsonSerializationHelper.Serialize(path, department);

            var newDepartment = JsonSerializationHelper.Deserialize<Department>(path);

            Console.WriteLine($"Department name: {newDepartment.DepartmentName}");
            foreach (var employee in newDepartment.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
