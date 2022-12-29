using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerialization
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

            var writer = new XmlSerializer(typeof(Department));

            var path = Environment.CurrentDirectory + "//DepartmentXml.xml";
            var file = File.Create(path);

            writer.Serialize(file, department);
            file.Close();
        }

        static void Deserialize()
        {
            var reader = new XmlSerializer(typeof(Department));
            var file = new StreamReader(Environment.CurrentDirectory + "//DepartmentXml.xml");

            var department = (Department)reader.Deserialize(file);

            file.Close();

            Console.WriteLine($"Department name: {department.DepartmentName}");

            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
