using System;
using System.Collections.Generic;

namespace XmlSerialization
{
    internal class Program
    {
        static void Main()
        {
            var path = Environment.CurrentDirectory + "//DepartmentXml.xml";
            var department = new Department
            {
                DepartmentName = "Power Generation Xml",
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

            XmlSerializationHelper.Serialize(path, department);
            var newDepartment = XmlSerializationHelper.Deserialize<Department>(path);

            Console.WriteLine($"Department name: {newDepartment.DepartmentName}");
            foreach (var employee in newDepartment.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
