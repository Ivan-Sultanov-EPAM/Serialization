using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonSerialization
{
    [Serializable]
    public class Department
    {
        [JsonPropertyName("Department")]
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}