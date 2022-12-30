using System;
using System.Runtime.Serialization;

namespace CustomBinarySerialization
{
    [Serializable]
    public class Employee : ISerializable
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Employee Name", Name, typeof(string));
            info.AddValue("Employee Position", Position, typeof(string));
        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Employee Name", typeof(string));
            Position = (string)info.GetValue("Employee Position", typeof(string));
        }
    }
}