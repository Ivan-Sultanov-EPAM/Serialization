using System;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static void Main()
        {
            var employee = new Employee
            {
                Name = "Alex",
                Position = "Engineer"
            };

            var fileName = "Employee.dat";

            CustomBinarySerializationHelper.Serialize(fileName, employee);

            var newEmployee = CustomBinarySerializationHelper.Deserialize<Employee>(fileName);

            Console.WriteLine(newEmployee.Name);
            Console.WriteLine(newEmployee.Position);
        }
    }
}
