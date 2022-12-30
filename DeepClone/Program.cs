using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DeepClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var department = new Department
            {
                DepartmentName = "Power Generation",
                Employees = new List<Employee>()
                {
                    new() { EmployeeName = "John" }
                }
            };

            var departmentClone = DeepClone(department);

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

        public static T DeepClone<T>(T value)
        {
            var path = Environment.CurrentDirectory + "//DepartmentJson.json";

            File.WriteAllText(path, JsonSerializer.Serialize(value));

            var file = File.ReadAllBytes(Environment.CurrentDirectory + "//DepartmentJson.json");

            var clonedObject = JsonSerializer.Deserialize<T>(file);

            return clonedObject;
        }
    }
}
