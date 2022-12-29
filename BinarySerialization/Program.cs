using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
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

            var fs = new FileStream("DepartmentBinary.dat", FileMode.Create);
            var formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, department);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        static void Deserialize()
        {
            Department department;

            FileStream fs = new FileStream("DepartmentBinary.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                department = (Department)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine($"Department name: {department.DepartmentName}");

            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"Employee name: {employee.EmployeeName}");
            }
        }
    }
}
