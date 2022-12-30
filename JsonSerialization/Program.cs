using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Serialize();
            Deserialize();
        }

        static void Serialize()
        {
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

            var path = Environment.CurrentDirectory + "//DepartmentJson.json";

            var departmentJson = JsonSerializer.Serialize(department);

            File.WriteAllText(path, departmentJson);
        }

        static void Deserialize()
        {
            var file = File.ReadAllBytes(Environment.CurrentDirectory + "//DepartmentJson.json");

            var department = JsonSerializer.Deserialize<Department>(file);

            Console.WriteLine($"Department name: {department.DepartmentName}");

            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
