using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static void Main()
        {
            var fileName = "Employee.dat";
            var formatter = new BinaryFormatter();

            Serialize(fileName, formatter);
            Deserialize(fileName, formatter);
        }

        public static void Serialize(string fileName, IFormatter formatter)
        {
            var employee = new Employee
            {
                Name = "Alex",
                Position = "Engineer"
            };

            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, employee);
            s.Close();
        }

        public static void Deserialize(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            var employee = (Employee)formatter.Deserialize(s);

            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Position);
        }
    }
}
